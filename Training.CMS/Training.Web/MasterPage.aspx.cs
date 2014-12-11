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
    public partial class MasterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initialize();
        }

        private void initialize()
        {
            DataTable datasource = ServiceFactory.GetMovieService().GetMovies("s", true);
            ChooseMovieType.DataSource = datasource;
            ChooseMovieType.DataTextField = "Id";
            ChooseMovieType.DataValueField = "Id";
            ChooseMovieType.DataBind();
            //ConsilientMovies.DataSource = datasource;
            //ConsilientMovies.DataBind();
        }
    }
}