using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class DdlPlanos : System.Web.UI.UserControl
    {
        public int Id_plano
        {
            get
            {
                return Convert.ToInt32(lista.SelectedValue);
            }
            set
            {
                lista.SelectedValue = Convert.ToString(value);
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

        public string Text
        {
            get
            {
                return lista.SelectedItem.Text;
            }            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var p = new PlanoBLL();
                lista.DataSource = p.GetAll("nome");
                lista.Items.Insert(0, new ListItem("selecione um plano...", "0"));
                lista.DataBind();
            }
        }
    }
}