using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.BLL;

namespace Medusa.Controles
{
    public partial class Endereco : System.Web.UI.UserControl
    {
        public Medusa.DAL.Endereco Value
        {
            get 
            {
                Medusa.DAL.Endereco ender = new DAL.Endereco();
                ender.logradouro = this.cTextoLogradouro.Text;
                ender.numero = this.cTextoNumero.Text;
                ender.complemento = this.cTextoComplemento.Text;
                ender.bairro = this.cTextoBairro.Text;
                ender.cidade = this.cTextoCidade.Text;
                ender.uf = this.cTextoUF.Text;                
                ender.cep = this.cTextoCep.Text;    
                return ender; 
            }
            set 
            {
                if (value == null)
                    value = new DAL.Endereco();

                this.cTextoLogradouro.Text = value.logradouro;
                this.cTextoNumero.Text = value.numero;
                this.cTextoComplemento.Text = value.complemento;
                this.cTextoBairro.Text = value.bairro;
                this.cTextoUF.Text = value.uf;               
                this.cTextoCidade.Text = value.cidade;                
                this.cTextoCep.Text = value.cep;
                         
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvLogradouro.ValidationGroup;
            }
            set
            {

                rfvLogradouro.ValidationGroup = value;
                rfvBairro.ValidationGroup = value;
                rfvNumero.ValidationGroup = value;
                rfvCep.ValidationGroup = value;
                rfvCidade.ValidationGroup = value;
                rfvUF.ValidationGroup = value;             

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