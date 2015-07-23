using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class DdlUF : System.Web.UI.UserControl
    {
        public string uf
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
                UFBLL u = new UFBLL();
                lista.DataSource = u.GetAll("uf");
                lista.Items.Insert(0, new ListItem("selecione um uf", "0"));
                lista.DataBind();
            }
        }
    }
}