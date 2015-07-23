using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.DAL;
using Medusa.BLL;
using Medusa.LIB;
using System.Linq.Expressions;
using System.Reflection;

namespace Medusa.Sistemas.Comum
{
    public partial class Frequencia : PageCrud<FrequenciaBLL>
    {
        private Dictionary<StatusFrequencia, System.Drawing.Color> dicColor = new Dictionary<StatusFrequencia, System.Drawing.Color>
        {
            {StatusFrequencia.LIBERAR , System.Drawing.Color.Green},
           {StatusFrequencia.AVISAR , System.Drawing.Color.Yellow},
           {StatusFrequencia.BLOQUEAR , System.Drawing.Color.Red}
        };

        protected override void Page_Load(object sender, EventArgs e)
        {
            // chave primária da tabela
            PRIMARY_KEY = "id_frequencia";
            //valor da chave primária
            PkValue = 0;
            // painel do grid
            pGrid = new Panel();
            // painel do formulário de alteração
            pCadastro = panelCadastro;
            // gridview
            _grid = new GridView();
            lbMsg = lblMsg;
            _btAlterar = new Button();
            _btAlterar0 = new Button();
            _btInserir = new Button();
            _btInserir0 = btInserir0;
            _btExcluir = new Button();
            _btExcluir0 = new Button();
            _ddlSize = new DropDownList();
            _ddlMode = new DropDownList();
            _ddlOptions = new DropDownList();
            _txtProcura = new TextBox();
            _btProcurar = new Button();
            _ckFilter = new CheckBox();
            _dataListFiltros = new DataList();

            if (!IsPostBack)
            {

               
                    if (SecurityBLL.GetCurrentId_usuario() == 0)
                        Response.Redirect("~/Home.aspx");
                    SetAdd();
                    this.txtRa.Focus();
                
            }
        }

        protected override void Get()
        {
            this.txtRa.Text = "";
            imgFoto.ImageUrl = "";
            imgFoto.DataBind();
           
            
            this.cTextoObs.Text = "";
            lbNome.Text = "";
            this.grid.DataSource = new List<StatusContrato>();
            this.grid.DataBind();
        }

        protected override void Set()
        {
            if (SecurityBLL.GetCurrentId_usuario() == 0)
                Response.Redirect("~/Home.aspx");
            else
            {
                ObjBLL.ObjEF.id_cliente = Convert.ToInt32(this.txtCodigo.Text);
                ObjBLL.ObjEF.data = DateTime.Now;
                ObjBLL.ObjEF.id_usuario = SecurityBLL.GetCurrentId_usuario();
            }
        }

        protected void txtRa_TextChanged(object sender, EventArgs e)
        {
            
            var ra = 0;
            if (!int.TryParse(txtRa.Text, out ra)) return;
            var cliBLL = new ClienteBLL();
            cliBLL.GetPorRa(Convert.ToInt32(txtRa.Text));
            if (cliBLL.ObjEF.id_cliente != 0)
            {
                txtCodigo.Text = cliBLL.ObjEF.id_cliente.ToString();
                lbNome.Text = cliBLL.ObjEF.nome;
                imgFoto.ImageUrl = cliBLL.ObjEF.foto;
                imgFoto.DataBind();                 

                this.cTextoObs.Text = cliBLL.ObjEF.obs;
                this.btInserir0.Focus();


                var ds = cliBLL.GetStatus();
                grid.DataSource = ds.Where(it => it.status != StatusFrequencia.TERMINADO);
                grid.DataBind();

                
                gridServicos.DataSource = cliBLL.GetServicos();
                gridServicos.DataBind();


            }
            else
            {
                Get();
                txtRa.Focus();
                    
            }
        }

        protected override void btInserir_Click(object sender, EventArgs e)
        {
            Set();
            ObjBLL.Add();
            if (ObjBLL.SaveChanges())
            {
                txtRa.Focus();
                msg("inclusão efetuada");
                Get();
            }
            else
                msgError("erro inclusão");
        }

        protected override void btCancelar_Click(object sender, EventArgs e)
        {
            txtRa.Text = "0";
            Get();
            txtRa.Text = String.Empty;
            txtRa.Focus();

        }

        //protected override void grid_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (!(e.Row.DataItem != null & e.Row.RowType.Equals(DataControlRowType.DataRow))) return;

        //    var sc = (StatusContrato)e.Row.DataItem;
        //    var lbStatus = (Label)e.Row.FindControl("lbStatus");

        //    lbStatus.Text = sc.ToString();
        //    lbStatus.BackColor = dicColor[sc.status];
        //    lbStatus.ForeColor = System.Drawing.Color.White;
        //}

     
    }
}