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
    public partial class Planos : PageCrud<PlanoBLL>
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            // chave primária da tabela
            PRIMARY_KEY = "id_plano";
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

                base.Page_Load(sender, e);
            }
        }

        protected override void Get()
        {
            ObjBLL.Get(PkValue);
            this.txtCodigo.Text = Convert.ToString(ObjBLL.ObjEF.id_plano);
            this.cTextoNome.Text = ObjBLL.ObjEF.nome;
            this.cTextoDescricao.Text = ObjBLL.ObjEF.descricao;
            this.cInteiroMeses.Value = ObjBLL.ObjEF.meses;
            this.cInteiroAcessos.Value = ObjBLL.ObjEF.acessos;
            this.cInteiroTolerancia.Value = ObjBLL.ObjEF.tolerancia;
            this.txtInicio.Text = Convert.ToString(ObjBLL.ObjEF.inicio);
            this.txtTermino.Text = Convert.ToString(ObjBLL.ObjEF.termino);
            this.ckStatus.Checked = ObjBLL.ObjEF.status;
            this.cValor1.Value = ObjBLL.ObjEF.valor;
            this.cDdlModalidades1.Id_modalidade = ObjBLL.ObjEF.id_modalidade;
        }

        protected override void Set()
        {
            ObjBLL.ObjEF.id_plano = Convert.ToInt32(this.txtCodigo.Text);
            ObjBLL.ObjEF.nome = this.cTextoNome.Text;
            ObjBLL.ObjEF.descricao = this.cTextoDescricao.Text;

            ObjBLL.ObjEF.meses = this.cInteiroMeses.Value.GetValueOrDefault();
            ObjBLL.ObjEF.acessos = this.cInteiroAcessos.Value.GetValueOrDefault();
            ObjBLL.ObjEF.tolerancia = this.cInteiroTolerancia.Value.GetValueOrDefault();
            
            var hora = this.txtInicio.Text.Split(':');
            ObjBLL.ObjEF.inicio = new TimeSpan(Convert.ToInt32(hora[0]), Convert.ToInt32(hora[1]), 0);

            hora = this.txtTermino.Text.Split(':');
            ObjBLL.ObjEF.termino = new TimeSpan(Convert.ToInt32(hora[0]), Convert.ToInt32(hora[1]), 0);

            this.txtTermino.Text = Convert.ToString(ObjBLL.ObjEF.termino);
            ObjBLL.ObjEF.status = this.ckStatus.Checked;
            ObjBLL.ObjEF.valor = this.cValor1.Value.GetValueOrDefault();

            ObjBLL.ObjEF.id_modalidade = this.cDdlModalidades1.Id_modalidade;
        }




    }
}