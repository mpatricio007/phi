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
using AjaxControlToolkit;
using System.IO;

namespace Medusa.Sistemas.Comum
{
    public partial class Clientes : PageCrud<ClienteBLL>
    {
        private ContratoBLL contratoBLL;
        private ServicoClienteBLL servicoClienteBLL;
        private PagamentoBLL pagamentoBLL;
        protected override void Page_Load(object sender, EventArgs e)
        {
            // chave primária da tabela
            PRIMARY_KEY = "id_cliente";
            //valor da chave primária
            PkValue = Convert.ToInt32(this.txtCodigo.Text);
            // painel do grid
            pGrid = new Panel();
            // painel do formulário de alteração
            pCadastro = new Panel();
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
        
                var p = new PlanoBLL();
                lista.DataSource = p.GetAll("nome");
                lista.Items.Insert(0, new ListItem("selecione um plano...", "0"));
                lista.DataBind();
                
            }
        }

        protected override void Get()
        {
            ObjBLL.Get(PkValue);
            this.txtCodigo.Text = Convert.ToString(ObjBLL.ObjEF.id_cliente);
            this.txtRA.Text = Convert.ToString(ObjBLL.ObjEF.ra);
            this.cTextoNome.Text = ObjBLL.ObjEF.nome;
            this.cDdlSexo1.Value = ObjBLL.ObjEF.sexo;
            if (ObjBLL.ObjEF.dtNascto != DateTime.MinValue)
                this.cDataNascto.Value = ObjBLL.ObjEF.dtNascto;
            else
                this.cDataNascto.Text = String.Empty;
            this.cEmail1.Value = ObjBLL.ObjEF.email;            
            this.cEnder1.Value = ObjBLL.ObjEF.endereco;
            this.cTelefoneTel.Value = ObjBLL.ObjEF.telefone;
            this.cTelefoneCelular.Value = ObjBLL.ObjEF.celular;
            this.cTelefoneEmer.Value = ObjBLL.ObjEF.tel_emergencia;
            this.cTextoContatoEmer.Text = ObjBLL.ObjEF.contato_emergencia;
            this.txtResponsavel.Text = ObjBLL.ObjEF.responsavel;
            this.cCPF1.Value = ObjBLL.ObjEF.cpf;
            this.txtRG.Text = ObjBLL.ObjEF.rg;
            this.cTextoObs.Text = ObjBLL.ObjEF.obs;
            this.ckVip.Checked = ObjBLL.ObjEF.vip;
            this.cTelefoneComercial.Value = ObjBLL.ObjEF.comercial;
            this.AsyncFileUpload1.Visible = false;
            this.spanUploading.Visible = false;
            this.imgFoto.ImageUrl = ObjBLL.ObjEF.foto;
            this.imgFoto.DataBind();

            lbId_cliente.Text = Convert.ToString(ObjBLL.ObjEF.id_cliente);
            lbNome.Text = ObjBLL.ObjEF.nome;

            lbId_aluno_servico.Text = Convert.ToString(ObjBLL.ObjEF.id_cliente);
            lbNomeServico.Text = ObjBLL.ObjEF.nome;


            lbId_clienteFreq.Text = Convert.ToString(ObjBLL.ObjEF.id_cliente);
            lbNomeFreq.Text = ObjBLL.ObjEF.nome;

            lbId_clientePagto.Text = Convert.ToString(ObjBLL.ObjEF.id_cliente);
            lbNomePagto.Text = ObjBLL.ObjEF.nome;
           
        }

        protected override void Set()
        {
            ObjBLL.ObjEF.id_cliente = Convert.ToInt32(this.txtCodigo.Text);
            //ObjBLL.ObjEF.ra = this.cInteiro1.Value.GetValueOrDefault();
            ObjBLL.ObjEF.nome = this.cTextoNome.Text;
            ObjBLL.ObjEF.sexo = this.cDdlSexo1.Value;
            ObjBLL.ObjEF.dtNascto = this.cDataNascto.Value.GetValueOrDefault();
            ObjBLL.ObjEF.email = this.cEmail1.Value;            
            ObjBLL.ObjEF.endereco = this.cEnder1.Value;
            ObjBLL.ObjEF.telefone = this.cTelefoneTel.Value;
            ObjBLL.ObjEF.celular = this.cTelefoneCelular.Value;
            ObjBLL.ObjEF.tel_emergencia = this.cTelefoneEmer.Value;
            ObjBLL.ObjEF.contato_emergencia = this.cTextoContatoEmer.Text;
            ObjBLL.ObjEF.responsavel = this.txtResponsavel.Text;
            ObjBLL.ObjEF.cpf = this.cCPF1.Value;
            ObjBLL.ObjEF.rg = this.txtRG.Text;
            ObjBLL.ObjEF.obs = this.cTextoObs.Text;
            ObjBLL.ObjEF.vip = this.ckVip.Checked;
            ObjBLL.ObjEF.comercial = this.cTelefoneComercial.Value;
            ObjBLL.up = new BLL.Upload();
            ObjBLL.up.file = (HttpPostedFile)Session["file"];
            Session.Remove("file");
            
        }

        protected void ProcessUpload(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            Session["file"] = AsyncFileUpload1.PostedFile;
        }

        protected void lkAddFile_Click(object sender, EventArgs e)
        {
            this.AsyncFileUpload1.Visible = true;
            this.spanUploading.Visible = true;
        }

        protected override void btInserir_Click(object sender, EventArgs e)
        {
            Set();
            ObjBLL.Add();
            if (ObjBLL.SaveChanges())
            {
                SetModify();
                msg("inclusão efetuada");
                PkValue = ObjBLL.ObjEF.id_cliente;
                Get();
            }
            else
                msgError("erro inclusão");            
            
        }

        protected override void SetView()
        {
            base.SetView();
            tabs.ActiveTab = tpProcurar;
            tpCadastro.Visible = false;
            tpContratos.Visible = false;
            tpPagamentos.Visible = false;
            tpServicos.Visible = false;
            tpFrequencia.Visible = false;
        }

        protected override void SetAdd()
        {
            base.SetAdd();
            tabs.ActiveTab = tpCadastro;
            tpCadastro.Visible = true;
            tpContratos.Visible = false;
            tpPagamentos.Visible = false;
            tpServicos.Visible = false;
            tpFrequencia.Visible = false;
        }

        protected override void SetModify()
        {
            base.SetModify();
            tabs.ActiveTab = tpCadastro;
            tpCadastro.Visible = true;
            tpContratos.Visible = true;
            tpPagamentos.Visible = true;
            tpServicos.Visible = true;
            tpFrequencia.Visible = true;
        }

        protected void tabs_ActiveTabChanged(object sender, EventArgs e)
        {

            switch (tabs.ActiveTab.ID)
            {
                case ("tpProcurar"):
                    {
                        SetGrid();
                        SetView();
                        break;
                    }

                case ("tpCadastro"):
                    {                        
                        break;
                    }
                case ("tpContratos"):
                    {
                        SetGridContrato();
                        SetAddContrato();
                        contratoBLL = new ContratoBLL();
                        this.txtId_contrato.Text = "0";
                        GetContrato();
                        break;
                    }
                case ("tpServicos"):
                    {
                        SetGridServico();
                        SetAddServico();
                        servicoClienteBLL = new ServicoClienteBLL();
                        this.txtId_servico.Text = "0";
                        GetServico();
                        break;
                    }
                case ("tpPagamentos"):
                    {
                        SetGridPagamento();
                        SetAddPagamento();
                        break;
                    }
                case ("tpFrequencia"):
                    {
                        cDataDeFrequencia.Value = DateTime.Now.AddMonths(-1);
                        cDataAteFrequencia.Value = DateTime.Now;
                        SetGridFreq();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }        
        
        #region contrato
        protected void msgContrato(string msg)
        {
            lbMsgContrato.BackColor = System.Drawing.Color.Green;
            lbMsgContrato.ForeColor = System.Drawing.Color.White;
            lbMsgContrato.Text = string.Format("* {0} !", msg);
        }

        protected virtual void msgErrorContrato(string msg)
        {
            lbMsgContrato.BackColor = System.Drawing.Color.Red;
            lbMsgContrato.ForeColor = System.Drawing.Color.White;
            lbMsgContrato.Text = string.Format("* {0} !?", msg);
        }
       
        protected void GetContrato()
        {            
            contratoBLL.Get(Convert.ToInt32(txtId_contrato.Text));
            this.txtId_contrato.Text = Convert.ToString(contratoBLL.ObjEF.id_contrato);
            this.lista.SelectedValue = Convert.ToString(contratoBLL.ObjEF.id_plano);
            this.cDataInicio.Value = contratoBLL.ObjEF.inicio;            
            this.cTextoObs0.Text = contratoBLL.ObjEF.obs;
            this.ckStatus.Checked = contratoBLL.ObjEF.status;
            this.cValorDescPer.Value = contratoBLL.ObjEF.desconto_per;
            this.cValorDescValor.Value = contratoBLL.ObjEF.desconto_valor;
            this.cDataTermino.Value = contratoBLL.ObjEF.termino;
        }

        protected void SetContrato()
        {
            contratoBLL.ObjEF.id_contrato = Convert.ToInt32(this.txtId_contrato.Text);
            contratoBLL.ObjEF.id_plano = Convert.ToInt32(this.lista.SelectedValue);
            contratoBLL.ObjEF.inicio = this.cDataInicio.Value.GetValueOrDefault();            
            contratoBLL.ObjEF.obs = this.cTextoObs0.Text;
            contratoBLL.ObjEF.status = this.ckStatus.Checked;
            contratoBLL.ObjEF.id_cliente = Convert.ToInt32(this.txtCodigo.Text);
            contratoBLL.ObjEF.desconto_per = this.cValorDescPer.Value;
            contratoBLL.ObjEF.desconto_valor = this.cValorDescValor.Value;
            contratoBLL.ObjEF.termino = this.cDataTermino.Value.GetValueOrDefault();
        }

        protected void btInserirContrato_Click(object sender, EventArgs e)
        {
            contratoBLL = new ContratoBLL();
            SetContrato();
            contratoBLL.Add();
            
                if (contratoBLL.SaveChanges())
                    msgContrato("inclusão efetuada");
                else
                    msgErrorContrato("erro inclusão");
            
            this.txtId_contrato.Text = "0";
            GetContrato();
            SetGridContrato();
        }

        protected void btAlterarContrato_Click(object sender, EventArgs e)
        {
            contratoBLL = new ContratoBLL();
            contratoBLL.Get(Convert.ToInt32(this.txtId_contrato.Text));
            SetContrato();
            contratoBLL.Update();
            if (contratoBLL.SaveChanges())
                msgContrato("alteração efetuada");
            else
                msgErrorContrato("erro alteração");
            this.txtId_contrato.Text = "0";
            GetContrato();
            SetGridContrato();
            SetAddContrato();
        }

        protected void btExcluirContrato_Click(object sender, EventArgs e)
        {
            contratoBLL = new ContratoBLL();
            contratoBLL.Get(Convert.ToInt32(this.txtId_contrato.Text));
            contratoBLL.Delete();
            if (contratoBLL.SaveChanges())
                msgContrato("exclusão efetuada");
            else
                msgErrorContrato("erro exclusão");
            GetContrato();
            SetAddContrato();
            SetGridContrato();
        }

        protected void btCancelarContrato_Click(object sender, EventArgs e)
        {
            SetGridContrato();
            SetAddContrato();
            contratoBLL = new ContratoBLL();
            this.txtId_contrato.Text = "0";
            GetContrato();
        }

        protected virtual void SetAddContrato()
        {
            lbMsgContrato.Text = String.Empty;    
            btInserirContrato.Visible = true;            
            btAlterarContrato.Visible = false;            
            btExcluirContrato.Visible = false;
            pGerarPagamentos.Visible = false;
            cDataTermino.Enabled = false;
            cDataTermino.EnableValidator = false;
        }

        protected virtual void SetModifyContrato()
        {
            lbMsgContrato.Text = String.Empty;
           
            btInserirContrato.Visible = false;
            btAlterarContrato.Visible = true;           
            btExcluirContrato.Visible = true;
            pGerarPagamentos.Visible = true;
            cDataTermino.Enabled = true;
            cDataTermino.EnableValidator = true;
        }    

        protected virtual void SetGridContrato()
        {
            Get();
            gridContratos.DataKeyNames = new string[] { "id_contrato" };
            gridContratos.DataSource = ObjBLL.ObjEF.Contratos;
            gridContratos.DataBind();
        }

        protected void gridContratos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            contratoBLL = new ContratoBLL();
            this.txtId_contrato.Text = Convert.ToString(gridContratos.DataKeys[e.NewEditIndex]["id_contrato"]);
            GetContrato();
            gridContratos.DataBind();
            SetModifyContrato();
            e.Cancel = true;

            lbMsgContrato.Text = String.Empty;
            cInteiroParcelas.Value = null;
            cDataGerarPagtos.Value = null;
                 
        }

        protected void btNewContrato_Click(object sender, EventArgs e)
        {
            contratoBLL = new ContratoBLL();
            this.txtId_contrato.Text = "0";
            GetContrato();
            SetAddContrato();
        }

        protected void btGerarPagtos_Click(object sender, EventArgs e)
        {
            contratoBLL = new ContratoBLL();
            contratoBLL.Get(Convert.ToInt32(this.txtId_contrato.Text));
            if (contratoBLL.ObjEF.status)
                if (contratoBLL.GerarPagamentos(cInteiroParcelas.Value.GetValueOrDefault(), cDataGerarPagtos.Value.GetValueOrDefault()))
                {
                    lbMsgGerarPagamentos.Text = "pagamentos gerados com sucesso!";
                    lbMsgGerarPagamentos.BackColor = System.Drawing.Color.Red;
                    lbMsgGerarPagamentos.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    lbMsgGerarPagamentos.Text = "erro!";
                    lbMsgGerarPagamentos.BackColor = System.Drawing.Color.Red;
                    lbMsgGerarPagamentos.ForeColor = System.Drawing.Color.White;
                }
            else
            {
                lbMsgGerarPagamentos.Text = "contrato inativo!";
                lbMsgGerarPagamentos.BackColor = System.Drawing.Color.Red;
                lbMsgGerarPagamentos.ForeColor = System.Drawing.Color.White;
            }
            this.txtId_contrato.Text = "0";
            GetContrato();
            SetGridContrato();
            SetAddContrato();
        }
        #endregion

        #region servico
        protected void msgServico(string msg)
        {
            lbMsgServico.BackColor = System.Drawing.Color.Green;
            lbMsgServico.ForeColor = System.Drawing.Color.White;
            lbMsgServico.Text = string.Format("* {0} !", msg);
        }

        protected virtual void msgErrorServico(string msg)
        {
            lbMsgServico.BackColor = System.Drawing.Color.Red;
            lbMsgServico.ForeColor = System.Drawing.Color.White;
            lbMsgServico.Text = string.Format("* {0} !?", msg);
        }

        protected void GetServico()
        {
            servicoClienteBLL.Get(Convert.ToInt32(txtId_servico.Text));
            this.txtId_servico.Text = Convert.ToString(servicoClienteBLL.ObjEF.id_servico_cliente);
            this.cDdlServico1.Id_servico = servicoClienteBLL.ObjEF.id_servico;
            this.cDataServico.Value = servicoClienteBLL.ObjEF.data;
            this.cDataServicoTermino.Value = servicoClienteBLL.ObjEF.data_termino;
            this.cTextoObsServico.Text = servicoClienteBLL.ObjEF.obs;            
            this.cValorDescontoPerServico.Value = servicoClienteBLL.ObjEF.desconto_per;
            this.cValorDescServico.Value = servicoClienteBLL.ObjEF.desconto_valor;
        }

        protected void SetServico()
        {
            servicoClienteBLL.ObjEF.id_servico_cliente = Convert.ToInt32(this.txtId_servico.Text);
            servicoClienteBLL.ObjEF.id_servico = this.cDdlServico1.Id_servico;
            servicoClienteBLL.ObjEF.data = this.cDataServico.Value.GetValueOrDefault();
            servicoClienteBLL.ObjEF.data_termino = this.cDataServicoTermino.Value;
            servicoClienteBLL.ObjEF.obs = this.cTextoObsServico.Text;            
            servicoClienteBLL.ObjEF.id_cliente = Convert.ToInt32(this.txtCodigo.Text);
            servicoClienteBLL.ObjEF.desconto_per = this.cValorDescontoPerServico.Value;
            servicoClienteBLL.ObjEF.desconto_valor = this.cValorDescServico.Value;
            
            var s = new ServicoBLL();
            s.Get(servicoClienteBLL.ObjEF.id_servico);

            servicoClienteBLL.ObjEF.total = s.ObjEF.valor *
                                            (1 - servicoClienteBLL.ObjEF.desconto_per.GetValueOrDefault()/100) -
                                            servicoClienteBLL.ObjEF.desconto_valor.GetValueOrDefault();
        }

        protected void btInserirServico_Click(object sender, EventArgs e)
        {
            servicoClienteBLL = new ServicoClienteBLL();
            SetServico();
            servicoClienteBLL.Add();
            if (servicoClienteBLL.SaveChanges())
                msgServico("inclusão efetuada");
            else
                msgErrorServico("erro inclusão");
            this.txtId_servico.Text = "0";
            GetServico();
            SetGridServico();
        }

        protected void btAlterarServico_Click(object sender, EventArgs e)
        {
            servicoClienteBLL = new ServicoClienteBLL();
            servicoClienteBLL.Get(Convert.ToInt32(this.txtId_servico.Text));
            SetServico();
            servicoClienteBLL.Update();
            if (servicoClienteBLL.SaveChanges())
                msgServico("alteração efetuada");
            else
                msgErrorServico("erro alteração");
            this.txtId_servico.Text = "0";
            GetServico();
            SetGridServico();
            SetAddServico();
        }

        protected void btExcluirServico_Click(object sender, EventArgs e)
        {
            servicoClienteBLL = new ServicoClienteBLL();
            servicoClienteBLL.Get(Convert.ToInt32(this.txtId_servico.Text));
            servicoClienteBLL.Delete();
            if (servicoClienteBLL.SaveChanges())
                msgServico("exclusão efetuada");
            else
                msgErrorServico("erro exclusão");
            GetServico();
            SetAddServico();
            SetGridServico();
        }

        protected void btCancelarServico_Click(object sender, EventArgs e)
        {
            SetGridServico();
            SetAddServico();
            servicoClienteBLL = new ServicoClienteBLL();
            this.txtId_servico.Text = "0";
            GetServico();
        }

        protected virtual void SetAddServico()
        {
            lbMsgServico.Text = String.Empty;
            btInserirServico.Visible = true;
            btAlterarServico.Visible = false;
            btExcluirServico.Visible = false;
        }

        protected virtual void SetModifyServico()
        {
            lbMsgServico.Text = String.Empty;

            btInserirServico.Visible = false;
            btAlterarServico.Visible = true;
            btExcluirServico.Visible = true;

        }

        protected virtual void SetGridServico()
        {
            Get();
            gridServicos.DataKeyNames = new string[] { "id_servico_cliente" };
            gridServicos.DataSource = ObjBLL.ObjEF.Servicos;
            gridServicos.DataBind();
        }

        protected void gridServicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            servicoClienteBLL = new ServicoClienteBLL();
            this.txtId_servico.Text = Convert.ToString(gridServicos.DataKeys[e.NewEditIndex]["id_servico_cliente"]);
            GetServico();
            gridServicos.DataBind();
            SetModifyServico();
            e.Cancel = true;
        }

        protected void btNewServico_Click(object sender, EventArgs e)
        {
            servicoClienteBLL = new ServicoClienteBLL();
            this.txtId_servico.Text = "0";
            GetServico();
            SetAddServico();
        }
        #endregion

        #region frequencia
        protected virtual void SetGridFreq()
        {
            gridFrequncia.Visible = true;

            ObjBLL.Get(PkValue);
            gridFrequncia.DataSource = ObjBLL.ObjEF.Frequencias.Where(it => it.data >= cDataDeFrequencia.Value.GetValueOrDefault()
                & it.data <= cDataAteFrequencia.Value.GetValueOrDefault().AddHours(24)).OrderByDescending(it => it.data);
            gridFrequncia.DataBind();
        }

        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            SetGridFreq();
        }
        #endregion


        #region pagamento
        protected void msgPagamento(string msg)
        {
            lbMsgPagamento.BackColor = System.Drawing.Color.Green;
            lbMsgPagamento.ForeColor = System.Drawing.Color.White;
            lbMsgPagamento.Text = string.Format("* {0} !", msg);
        }

        protected virtual void msgErrorPagamento(string msg)
        {
            lbMsgPagamento.BackColor = System.Drawing.Color.Red;
            lbMsgPagamento.ForeColor = System.Drawing.Color.White;
            lbMsgPagamento.Text = string.Format("* {0} !?", msg);
        }

        protected void GetPagamento()
        {
            pagamentoBLL.Get(Convert.ToInt32(txtId_pagamento.Text));
            this.txtId_pagamento.Text = Convert.ToString(pagamentoBLL.ObjEF.id_pagamento);
            this.txtId_contratoPagto.Text = Convert.ToString(pagamentoBLL.ObjEF.id_contrato);
            this.lbDataVencto.Text = Util.DateToString(pagamentoBLL.ObjEF.data_vencto);
            this.lbValorPagto.Text = String.Format("{0:N2}",Convert.ToString(pagamentoBLL.ObjEF.valor));
            this.lbUsuarioLancto.Text = pagamentoBLL.ObjEF.id_usuario_lancto != 0 ? pagamentoBLL.ObjEF.UsuarioLancto.nome : String.Empty;
            this.lbDataPagto.Value = pagamentoBLL.ObjEF.data_pagto;
            this.lbUsuarioBaixa.Text = pagamentoBLL.ObjEF.id_usuario_baixa.HasValue ? pagamentoBLL.ObjEF.UsuarioBaixa.nome : String.Empty;
            this.cDdlForma1.Id_forma = 0;
            this.cTextoNUmPagto.Text = String.Empty;
        }

        protected void SetPagamento()
        {
            pagamentoBLL.ObjEF.id_pagamento = Convert.ToInt32(this.txtId_pagamento.Text);
            pagamentoBLL.ObjEF.id_forma = this.cDdlForma1.Id_forma;
            pagamentoBLL.ObjEF.num = this.cTextoNUmPagto.Text;
            pagamentoBLL.ObjEF.data_pagto = this.lbDataPagto.Value;
        }

        protected void btExcluirPagamento_Click(object sender, EventArgs e)
        {
            pagamentoBLL = new PagamentoBLL();
            pagamentoBLL.Get(Convert.ToInt32(this.txtId_pagamento.Text));
            pagamentoBLL.Delete();
            if (pagamentoBLL.SaveChanges())
                msgPagamento("exclusão efetuada");
            else
                msgErrorPagamento("erro exclusão");
            GetPagamento();
            SetAddPagamento();
            SetGridPagamento();
        }

        protected void btCancelarPagamento_Click(object sender, EventArgs e)
        {
            SetGridPagamento();
            SetAddPagamento();
            pagamentoBLL = new PagamentoBLL();
            this.txtId_pagamento.Text = "0";
            GetPagamento();
        }

        protected virtual void SetAddPagamento()
        {
            lbMsgPagamento.Text = String.Empty;           
            btExcluirPagamento.Visible = false;
        }

        protected virtual void SetModifyPagamento()
        {
            lbMsgPagamento.Text = String.Empty;           
            btExcluirPagamento.Visible = true;

        }

        protected virtual void SetGridPagamento()
        {
            Get();
            pagamentoBLL = new PagamentoBLL();
            gridPagamentos.DataKeyNames = new string[] { "id_pagamento" };
            gridPagamentos.DataSource = pagamentoBLL.GetPagamentos(Convert.ToInt32(this.txtCodigo.Text));
            gridPagamentos.DataBind();
        }

        protected void gridPagamentos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pagamentoBLL = new PagamentoBLL();
            this.txtId_pagamento.Text = Convert.ToString(gridPagamentos.DataKeys[e.NewEditIndex]["id_pagamento"]);
            GetPagamento();
            gridPagamentos.DataBind();
            SetModifyPagamento();
            e.Cancel = true;
        }

        protected void btBaixaPagto_Click(object sender, EventArgs e)
        {
            pagamentoBLL = new PagamentoBLL();
            pagamentoBLL.Get(Convert.ToInt32(this.txtId_pagamento.Text));
            SetPagamento();
            this.cDdlForma1.Id_forma = pagamentoBLL.ObjEF.id_forma.GetValueOrDefault();
            this.cTextoNUmPagto.Text = pagamentoBLL.ObjEF.num;


            if (pagamentoBLL.BaixaPagto())
            {
                msgPagamento("baixa efetuada");
                this.txtId_pagamento.Text = "0";
                GetPagamento();
                SetGridPagamento();
                SetAddPagamento();
            }
            else
                msgErrorPagamento("erro baixa");
           
            
        }

        protected void btCancelarBaixa_Click(object sender, EventArgs e)
        {
            pagamentoBLL = new PagamentoBLL();
            pagamentoBLL.Get(Convert.ToInt32(this.txtId_pagamento.Text));
            SetPagamento();
            this.cDdlForma1.Id_forma = pagamentoBLL.ObjEF.id_forma.GetValueOrDefault();
            this.cTextoNUmPagto.Text = pagamentoBLL.ObjEF.num;


            if (pagamentoBLL.BaixaPagto())
            {
                msgPagamento("baixa cancelada!");
                this.txtId_pagamento.Text = "0";
                GetPagamento();
                SetGridPagamento();
                SetAddPagamento();
            }
            else
                msgErrorPagamento("erro");
        }

        #endregion


       

        

        
    }
}