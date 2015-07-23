using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.LIB;

namespace Medusa.Controles
{
    public partial class Inteiro : System.Web.UI.UserControl
    {

        

        public int? Value
        {
            get 
            {
                return Util.StringToInteiro(txtInteiro.Text);
            }
            set 
            {

                txtInteiro.Text = Util.InteiroToString(value);
            }
        }

        public string Text
        {
            get
            {
                return txtInteiro.Text;
            }
            set
            {
                txtInteiro.Text = value;

            }
        }

        public bool EnableValidator
        {
            get
            {
                return rfvInteiro.Enabled;
            }
            set
            {
                rfvInteiro.Enabled = value;
                          
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvInteiro.ValidationGroup;
            }
            set
            {

                rfvInteiro.ValidationGroup = value;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.RegisterStyleSheet(StyleSheet, Common.GetHost() + "Shared/StyleSheet/jquery.css");
                Common.RegisterStyleSheet(StyleSheet, Common.GetHost() + "Shared/StyleSheet/jquery.dateentry.css");
                Common.RegisterStyleSheet(StyleSheet, Common.GetHost() + "Shared/StyleSheet/jquery.timeentry.css");
            }
        }
    }
}