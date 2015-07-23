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

namespace Medusa.Sistemas.Admin
{
    public partial class Menus : PageCrud<MenuBLL>
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            // chave primária da tabela
            PRIMARY_KEY = "id_menu";
            //valor da chave primária
            PkValue = Convert.ToInt32(this.txtCodigo.Text);
            // painel do grid
            pGrid = panelGrid;
            // painel do formulário de alteração
            pCadastro = panelCadastro;
            // gridview
            _grid = grid;
            lbMsg = lblMsg;
            _btAlterar = btAlterar;
            _btAlterar0 = btAlterar0;
            _btInserir = btInserir;
            _btInserir0 = btInserir0;
            _btExcluir = btExcluir;
            _btExcluir0 = btExcluir0;
            _ddlSize = ddlSize;
            _ddlMode = ddlMode;
            _ddlOptions = ddlOptions;
            _txtProcura = txtProcura;
            _btProcurar = btSearch;
            _ckFilter = ckFilter;
            _dataListFiltros = DataListFiltros;

            if (!IsPostBack)
            {
                SistemaBLL sistema = new SistemaBLL();

                this.ddlSistema.DataTextField = "nome";
                this.ddlSistema.DataValueField = "id_sistema";

                this.ddlSistema.DataSource = sistema.GetAll("nome");
                this.ddlSistema.DataBind();

                this.ddlSistema.Items.Add(new ListItem("selecione um sistema...", "0"));

                
                base.Page_Load(sender, e);
            }
        }

        protected override void Get()
        {
            ObjBLL.Get(PkValue);
            this.txtCodigo.Text = Convert.ToString(ObjBLL.ObjEF.id_menu);
            this.cTextoNome.Text = ObjBLL.ObjEF.nome;
            this.cTextoDescricao.Text = ObjBLL.ObjEF.descricao;
            this.ddlSistema.SelectedValue = Convert.ToString(ObjBLL.ObjEF.id_sistema);
            this.cInteiro1.Value = ObjBLL.ObjEF.ordem;

            SetAddPag();
            gridPag.DataBind();
        }

        protected override void Set()
        {
            ObjBLL.ObjEF.id_menu = Convert.ToInt32(this.txtCodigo.Text);
            ObjBLL.ObjEF.nome = this.cTextoNome.Text;
            ObjBLL.ObjEF.descricao = this.cTextoDescricao.Text;
            ObjBLL.ObjEF.id_sistema = Convert.ToInt32(this.ddlSistema.SelectedValue);
            ObjBLL.ObjEF.ordem = this.cInteiro1.Value.GetValueOrDefault();
        }

        protected override void btCancelar_Click(object sender, EventArgs e)
        {
            base.btCancelar_Click(sender, e);
            panelPaginas.Visible = false;
        }

        protected void gridPag_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GetPagina(Convert.ToInt32(gridPag.DataKeys[e.NewEditIndex]["id_menu_paginas"].ToString()));
            SetModifyPag();
            e.Cancel = true;
        }

        protected void GetPagina(Int32 id_pagina)
        {
            MenuPaginaBLL mpBLL = new MenuPaginaBLL();
            mpBLL.Get(id_pagina);
            this.txtId_mp.Text = Convert.ToString(mpBLL.ObjEF.id_menu_paginas);
            this.cDdlPagina1.Id_pagina = Convert.ToString(mpBLL.ObjEF.id_pagina);
            this.chkLeitura.Checked = mpBLL.ObjEF.leitura;
            this.chkGravacao.Checked = mpBLL.ObjEF.gravacao;
            this.cOrdem.Value = mpBLL.ObjEF.ordem;
        }

        protected void SetPagina(MenuPaginaBLL mpBLL)
        {
            mpBLL.ObjEF.id_menu_paginas = Convert.ToInt32(this.txtId_mp.Text);
            mpBLL.ObjEF.id_menu = Convert.ToInt32(PkValue);
            mpBLL.ObjEF.id_pagina = Convert.ToInt32(this.cDdlPagina1.Id_pagina);
            mpBLL.ObjEF.leitura = this.chkLeitura.Checked;
            mpBLL.ObjEF.gravacao = this.chkGravacao.Checked;
            mpBLL.ObjEF.ordem = this.cOrdem.Value.GetValueOrDefault();
       }

        protected void btSalvaPag_Click(object sender, EventArgs e)
        {
            MenuPaginaBLL mpBLL = new MenuPaginaBLL();
            mpBLL.Get(Convert.ToInt32(this.txtId_mp.Text));
            SetPagina(mpBLL);
            mpBLL.Update();
            mpBLL.SaveChanges();
            gridPag.DataBind();
        }

        protected void btInserePag_Click(object sender, EventArgs e)
        {
            MenuPaginaBLL mpBLL = new MenuPaginaBLL();            
            SetPagina(mpBLL);
            mpBLL.Add();
            mpBLL.SaveChanges();
            GetPagina(0);
            gridPag.DataBind();
        }

        protected void gridPag_DataBinding(object sender, EventArgs e)
        {
            if (Convert.ToInt32(PkValue) != 0)
            {
                panelPaginas.Visible = true;
                gridPag.DataKeyNames = new string[] { "id_menu_paginas" };
                ObjBLL.Get(PkValue);
                gridPag.DataSource = ObjBLL.ObjEF.MenuPaginas;                
            }
            else panelPaginas.Visible = false;
        }

        protected void btExcluiPag_Click(object sender, EventArgs e)
        {
            MenuPaginaBLL mpBLL = new MenuPaginaBLL();
            mpBLL.Get(Convert.ToInt32(this.txtId_mp.Text));
            mpBLL.Delete();
            if (mpBLL.SaveChanges())
                msg("exclusão efetuada");
            else
                msgError("erro exclusão");
            GetPagina(0);
            gridPag.DataBind();
        }

        protected virtual void SetAddPag()
        {
            lbMsg.Text = String.Empty;
            btSalvaPag.Visible = false;
            btInserePag.Visible = true;
            btExcluiPag.Visible = false;
        }

        protected virtual void SetModifyPag()
        {
            lbMsg.Text = String.Empty;
            btSalvaPag.Visible = true;
            btInserePag.Visible = false;
            btExcluiPag.Visible = true;
        }

        protected override void SetAdd()
        {
            base.SetAdd();
            panelPaginas.Visible = false;
        }

        protected override void SetModify()
        {
            base.SetModify();
            panelPaginas.Visible = true;
        }

        protected override void btProcurar_Click(object sender, EventArgs e)
        {
            base.btProcurar_Click(sender, e);
            panelPaginas.Visible = false;
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}