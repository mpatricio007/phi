using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class DdlSexo : System.Web.UI.UserControl
    {
        public string Value
        {
            get
            {
                return listaSexos.SelectedValue;
            }
            set
            {

                listaSexos.SelectedValue = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return cvSexo.ValidationGroup;
            }
            set
            {
                cvSexo.ValidationGroup = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                listaSexos.Items.Insert(0, new ListItem("selecione um sexo...", "0"));
                listaSexos.DataBind();
            }
        }
    }
}