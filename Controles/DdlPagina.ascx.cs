using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class DdlPagina : System.Web.UI.UserControl
    {
        public string Id_pagina
        {
            get 
            {      
                return lista.SelectedValue; 
            }
            set
            {
                lista.SelectedValue = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return cv.ValidationGroup;
            }
            set
            {                
                cv.ValidationGroup = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PaginaBLL p = new PaginaBLL();
                lista.DataSource = p.GetAll("url");
                lista.Items.Insert(0, new ListItem("selecione uma página...", "0"));
                lista.DataBind();
            }
        }
    }
}