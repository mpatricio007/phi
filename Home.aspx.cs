using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Medusa.BLL;
using Medusa.DAL;

using System.IO;
using Medusa.LIB;

namespace Medusa
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
         
         
        }

        protected void btEntrar_Click(object sender, EventArgs e)
        {   
            string saida = String.Empty;
            var user = SecurityBLL.Login(this.txtLogin.Text, this.txtSenha.Text, out saida);            
            this.lblMsg.Text = saida;
            if (user != null)
            {
                Session["id_sistema"] = user.id_sistema;
                Session["id_usuario"] = user.id_pessoa;
                FormsAuthentication.RedirectFromLoginPage(user.nome, false);
                Response.Redirect(string.Format("{0}/{1}", "~", user.Sistema.Pagina.url));
            }

        }

      
    }
}