﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Service;
using System.Data;

namespace Training.Web
{
    public partial class HomePage : System.Web.UI.Page
    {
        private readonly IMovieService MovieService = ServiceFactory.GetMovieService();
        private static int ListviewSelectedIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initialize();
            }
        }

        private void initialize()
        {
            DataTable getmovies = MovieService.GetMovies("全部", "");
            DataTable datasource = ServiceFactory.GetMovieTypeService().GetMovieTypes();
            ChooseMovieType.DataSource = datasource;
            ChooseMovieType.DataTextField = "TypeName";
            ChooseMovieType.DataValueField = "Id";
            ChooseMovieType.DataBind();
            ConsilientMovies.DataSource = getmovies;
            ConsilientMovies.DataBind();
        }

        private void ShowQueryResult()
        {
            var type = ChooseMovieType.SelectedItem.Text;
            var actor = InputActor.Text;
            DataTable source = MovieService.GetMovies(type, actor);
            ConsilientMovies.DataSource = source;
            ConsilientMovies.DataBind();
        }

        protected void SubmitCondition_Click(object sender, EventArgs e)
        {
            ShowQueryResult();
        }

        protected void ChooseMovieType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowQueryResult();
        }

        protected void ConsilientMovies_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            ListviewSelectedIndex = e.NewSelectedIndex;
            Response.Redirect("MovieDetails.aspx", true);
        }

        public int GetListviewSelectedIndex()
        {
            return ListviewSelectedIndex;
        }

    }
}