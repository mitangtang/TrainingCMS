﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Domain;
using Training.Service;

namespace Training.Web
{
    public partial class MovieMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSourceBand();
            }
        }

        private void DataSourceBand()
        {
            var movieService = new MovieService();
            MovieGridView.DataSource = movieService.GetMovies();
            MovieGridView.DataKeyNames = new string[] { "Id" };
            MovieGridView.DataBind(); 
        }

        protected void MovieGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string movieId = MovieGridView.DataKeys[e.RowIndex].Value.ToString();
            var movie = new Movie()
            {
                Id = Convert.ToInt32(movieId)
            };
            var movieServie = new MovieService();
            movieServie.DeleteMovie(movie);
            DataSourceBand();
        }

        protected void MovieGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string movieId = MovieGridView.DataKeys[e.RowIndex].Value.ToString();
            var movie = new Movie()
            {
                Id = Convert.ToInt32(movieId)
            };
            var movieServie = new MovieService();
            movieServie.UpdateMovie(movie);
            MovieGridView.EditIndex = -1;
            DataSourceBand();
        }

        protected void MovieGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            MovieGridView.EditIndex = e.NewEditIndex;
            DataSourceBand();
        }

        protected void MovieGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MovieGridView.EditIndex = -1;
            DataSourceBand();
        }

        protected void MovieGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00FFFF',this.style.fontWeight='';");
                
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
            }
        }

        protected void MovieGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MovieGridView.PageIndex = e.NewPageIndex;
            DataSourceBand();
        }


        protected void MovieGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // If multiple ButtonField column fields are used, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "UpdateButton")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);
                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = MovieGridView.Rows[index];
                TableCell contactId = selectedRow.Cells[0];
                //string contact = contactId.Text;
                //// Display the selected author.
                //LabelTest.Text = "You selected " + contact + ".";
                //Response.Redirect("AddMovie.aspx");
                string querystr = contactId.Text;
                Response.Redirect("UpdateMovie.aspx?MovieId=" + querystr);
            }
        }

      

    }
}