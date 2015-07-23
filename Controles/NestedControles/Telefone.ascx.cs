using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medusa.Controles
{
    public partial class Telefone : System.Web.UI.UserControl
    {
        public DAL.Telefone Value
        {
            get
            {
                return new DAL.Telefone(txt.Text);
            }
            set
            {
                if (value == null)
                    value = new DAL.Telefone();
                txt.Text = value.value;

            }
        }

     
        public bool EnableValidator
        {
            get
            {
                return rfv.Enabled;
            }
            set
            {
                rfv.Enabled = value;

            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfv.ValidationGroup;
            }
            set
            {                
                rfv.ValidationGroup = value;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
    }
}