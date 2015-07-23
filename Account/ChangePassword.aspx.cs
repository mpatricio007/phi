using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.LIB;
using Medusa.BLL;

namespace WebMedusa.Account
{
    public partial class ChangePassword : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.Page_Load(sender, e);
            }
        }

        protected void btAlterarSenha_Click(object sender, EventArgs e)
        {
            this.lbLog.Text = SecurityBLL.AlterarSenha(this.txtSenha.Text, this.txtNewSenha.Text);
        }
    }
}
