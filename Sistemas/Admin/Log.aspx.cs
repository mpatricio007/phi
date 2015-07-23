using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Medusa.LIB;
using Medusa.BLL;

namespace Medusa.Sistemas.Admin
{
    public partial class Log :PageCrud<LogSistemaBLL>
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            // chave primária da tabela
            PRIMARY_KEY = "id_log";
            //valor da chave primária
            PkValue = Convert.ToInt32(this.lbId_log.Text);
            // painel do grid
            pGrid = panelGrid;
            // painel do formulário de alteração
            pCadastro = panelCadastro;
            // gridview
            _grid = grid;
            lbMsg = new Label();
            _btAlterar = new Button();
            _btAlterar0 = new Button();
            _btInserir = new Button();
            _btInserir0 = new Button();
            _btExcluir = new Button();
            _btExcluir0 = new Button();
            _ddlSize = ddlSize;
            _ddlMode = ddlMode;
            _ddlOptions = ddlOptions;
            _txtProcura = txtProcura;

            _btProcurar = btSearch;
            _ckFilter = ckFilter;
            _dataListFiltros = DataListFiltros;

            if (!IsPostBack)
            {
                
                base.Page_Load(sender, e);
            }
        }

        protected override void Get()
        {
            ObjBLL.Get(PkValue);
            this.lbId_log.Text = Convert.ToString(ObjBLL.ObjEF.id_log);
            this.lbAcao.Text = ObjBLL.ObjEF.acao;
            this.lbEntidade.Text = ObjBLL.ObjEF.entidade;
            this.lbIp.Text = ObjBLL.ObjEF.ip;
            this.lbUsuario.Text = ObjBLL.ObjEF.Usuario.nome;
            this.lbData.Text = Util.DateToString(ObjBLL.ObjEF.data);
            this.lbId_entidade.Text = Convert.ToString(ObjBLL.ObjEF.id_entidade);
            this.lbDescricao.Text = ObjBLL.ObjEF.descricao;

            entidade.InnerHtml = ObjBLL.GetEntidade();
        }

        protected override void Set()
        {           

        }
    }
}