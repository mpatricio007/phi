using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class ControleCPF : System.Web.UI.UserControl
    {
        public string Value
        {
            get
            {
                return this.txtCpf.Text.Replace(".","").Replace("-","");
            }
            set
            {

                this.txtCpf.Text = value;
            }
        }

        private bool isValid;

        public bool IsValid
        {
            get 
            {
                cvCpf_ServerValidate(null, null);
                return isValid; 
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
                return cvCpf.ValidationGroup;
            }
            set
            {
                cvCpf.ValidationGroup = value;
                txtCpf.ValidationGroup = value;

            }
        }

        protected void cvCpf_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CPF cpf = new CPF(this.txtCpf.Text);
            args.IsValid = cpf.IsValid;
            isValid = args.IsValid;            
        }
    }
}