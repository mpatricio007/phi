using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class ControleCNPJ : System.Web.UI.UserControl
    {

        private bool isValid;

        public bool IsValid
        {
            get { return isValid; }
        }

        public string GetCnpj()
        {
            return this.txtCnpj.Text;
        }

        public void SetCnpj(string cnpj)
        {
            this.txtCnpj.Text = cnpj;
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
                cvCnpj.ValidationGroup = value;
                rfv.ValidationGroup = value;

            }
        }

         protected void cvCnpj_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CNPJ cnpj = new CNPJ(this.txtCnpj.Text);
            args.IsValid = cnpj.IsValid;
            isValid = args.IsValid;
        }
    }
}