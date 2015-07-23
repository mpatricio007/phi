using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.LIB;

namespace Medusa.Controles
{
    public partial class Data : System.Web.UI.UserControl
    {
        public DateTime? Value
        {
            get 
            {
                return Util.StringToDate(txtData.Text);
            }
            set 
            {
                txtData.Text = Util.DateToString(value);
                
            }
        }

        public string Text
        {
            get
            {
                return txtData.Text;
            }
            set
            {
                txtData.Text = value;

            }
        }


        public bool EnableValidator
        {
            get
            {
                return rfvData.Enabled;
            }
            set
            {
                rfvData.Enabled = value;
                      
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvData.ValidationGroup;
            }
            set
            {
                rfvData.ValidationGroup = value;

            }
        }

        public bool Enabled
        {
            get
            {
                return txtData.Enabled;
            }
            set
            {
                txtData.Enabled = value;
            }
        }

        public int Width
        {
            get
            {
                return Convert.ToInt16(txtData.Width);
            }
            set
            {

                txtData.Width = value;

            }
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PlaceHolder StyleSheet = (PlaceHolder)Page.Master.Master.FindControl("StyleSheet");
                Common.RegisterStyleSheet(StyleSheet, Common.GetHost() + "Shared/StyleSheet/jquery.css");
                Common.RegisterStyleSheet(StyleSheet, Common.GetHost() + "Shared/StyleSheet/jquery.dateentry.css");
                Common.RegisterStyleSheet(StyleSheet, Common.GetHost() + "Shared/StyleSheet/jquery.timeentry.css");
                BasePage.setTextDateEntry(txtData, BasePage.TextboxDateEntryType.Full, true, true, "-100:+50");
            }
        }
    }
}