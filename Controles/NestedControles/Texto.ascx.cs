using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medusa.Controles
{
    public partial class Texto : System.Web.UI.UserControl
    {
        public string Text
        {
            get
            {
                return txt.Text;
            }
            set
            {
                txt.Text = value;

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

        public Unit Width
        {
            get
            {
                return txt.Width;
            }
            set
            {
                txt.Width = value;

            }
        }

        public Unit Height
        {
            get
            {
                return txt.Height;
            }
            set
            {
                txt.Height = value;

            }
        }

        public int MaxLength
        {
            get
            {
                return txt.MaxLength;
            }
            set
            {
                txt.MaxLength = value;

            }
        }


        public TextBoxMode TextMode
        {
            get
            {
                return txt.TextMode;
            }
            set
            {
                txt.TextMode = value;

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
            
        }
        public override void Focus()
        {
            this.txt.Focus();
        }
    }
}