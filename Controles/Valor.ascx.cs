using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.LIB;

namespace Medusa.Controles
{
    public partial class Valor : System.Web.UI.UserControl
    {

        

        public Decimal? Value
        {
            get 
            {
                return Util.StringToDecimal(txtValor.Text);
            }
            set 
            {
                txtValor.Text = Util.DecimalToString(value);                
            }
        }

        public string Text
        {
            get
            {
                return txtValor.Text;
            }
            set
            {
                txtValor.Text = value;

            }
        }

        public bool EnableValidator
        {
            get
            {
                return rfvValor.Enabled;
            }
            set
            {
                rfvValor.Enabled = value;
                          
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvValor.ValidationGroup;
            }
            set
            {

                rfvValor.ValidationGroup = value;

            }
        }

        public int Width
        {
            get
            {
                return Convert.ToInt16(txtValor.Width);
            }
            set
            {

                txtValor.Width = value;

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