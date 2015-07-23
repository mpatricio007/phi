using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class DdlCidade : System.Web.UI.UserControl
    {
        public string cidade
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
                CidadeBLL c = new CidadeBLL();
                lista.DataSource = c.GetAll("cidade");
                lista.Items.Insert(0, new ListItem("selecione uma cidade...", "0"));
                lista.DataBind();
            }
        }
    }
}