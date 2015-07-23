using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class DdlModalidades : System.Web.UI.UserControl
    {
        public int Id_modalidade
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
                var p = new ModalidadeBLL();
                lista.DataSource = p.GetAll("nome");
                lista.Items.Insert(0, new ListItem("selecione uma modalidade...", "0"));
                lista.DataBind();
            }
        }
    }
}