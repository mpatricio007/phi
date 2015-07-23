using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Medusa.BLL;

namespace WebExtrato
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id_sistema = Convert.ToInt32(Session["id_sistema"]);
                SistemaBLL sisBLL = new SistemaBLL();
                sisBLL.Get(id_sistema);
                menu.InnerHtml = sisBLL.CreateHtmlMenu();
            }
        }
    }
}