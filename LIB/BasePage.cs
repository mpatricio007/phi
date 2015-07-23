
#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Authentication;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Medusa.BLL;

#endregion Libraries

namespace Medusa.LIB
{

    /// <summary>
    /// BasePage, para ser usada como base em web forms.
    /// Desenvolvido por Alex(sandro) S Pimenta Dez/2009.
    /// Pode ser utilizado como quiserem, se tiverem ideias de melhorar
    /// mandem atualizações e ideias para alex@alexpimenta.com
    /// Alguns comentários estão em inglês, porque prefiro escrever em inglês quando desenvolvo
    /// Mas como eu peguei da minha aplicação de modelo para postar no blog, resolvi escrever os 
    /// novos comentários em português mesmo.
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        private bool? seguranca;

        protected bool? Seguranca
        {
            get 
            {
                if (!seguranca.HasValue)
                    seguranca = true;
                return seguranca; 
            }
            set { seguranca = value; }
        }

        #region Enums
        /// <summary>
        /// Enum usado no método de entrada de Data
        /// </summary>
        [Label("Tipos de entrada para entrada de Data")]
        public enum TextboxDateEntryType
        {
            [Label("Completo")]
            Full = 3,
            [Label("Spinner")]
            Spinner = 1,
            [Label("Picker")]
            Picker = 2
        }
        #endregion Enums

        #region Constants
        /// <summary>
        /// Constante usada internamente, usada nos métodos para enviar cósigo javascript (usando JQuery)
        /// Abre o código JQuery $(document).ready(function() {
        /// </summary>
        private const String sJQueryIni = "$(document).ready(function() { \n";
        /// <summary>
        /// Constante usada internamente, usada nos métodos para enviar cósigo javascript (usando JQuery)
        /// Fecha o código JQuery $(document).ready(function() {
        /// </summary>
        private const String sJQueryEnd = "\n});\n";
        private const String MensagemAguarde = "Aguarde. Processando...";
        #endregion Constants

        #region Fields
        private static String _DialogScriptCommand = String.Empty;
        private static List<String> _UsedKeys = new List<String>();
        private static List<String> _ScriptRegistring = new List<String>();
        #endregion Fields

        #region Eventos

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                if (Seguranca.Value)
                {
                    if (Session["id_usuario"] != null)
                    {
                        bool bGravacao = false;
                        if (!SecurityBLL.GetPermission(this.ToString(), out bGravacao))
                        {
                            Response.Redirect("~/AcessoNegado.aspx");
                        }
                        else
                        {
                            ContentPlaceHolder cphMain = (ContentPlaceHolder)Page.Master.Master.FindControl("cphMain").FindControl("MainContent");
                            int i = 0;
                            string divId = "dGravacao";
                            while (true)
                            {
                                HtmlGenericControl div = (HtmlGenericControl)cphMain.FindControl(i == 0 ? divId : divId + Convert.ToString(i));
                                if (div != null)
                                {
                                    div.Visible = bGravacao;
                                    i += 1;
                                }
                                else
                                    break;
                            }
                        }

                    }
                    else
                        Response.Redirect("~/Home.aspx");
                }

                
            
            }
        }
        
        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            
        }
        #endregion OnInit

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            this.AddJavaScripts();

            base.OnLoad(e);
        }
        #endregion OnLoad

        #region OnLoadComplete
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            StringBuilder Script = new StringBuilder();
            foreach (String Item in _ScriptRegistring) { Script.Append(Item); }
            if (!String.IsNullOrEmpty(Script.ToString()))
            {
                Script = Script.Replace("\n", " ")
                               .Replace("jQuery", "$")
                               .Replace(" $(", "$(")
                               .Replace("\", \"", "\",\"")
                               .Replace("', '", "','")
                               .Replace(": ", ":")
                               .Replace("{ ", "{")
                               .Replace(" }", "}")
                               .Replace(" ;", ";")
                               .Replace(", false", ",false")
                               .Replace(", true", ",true")
                               .Replace(" ,", ",");
                RegisterScriptToPage("RegistringGeneralScript", JQueryFormat(Script.ToString()));
            }
        }
        #endregion OnLoadComplete

        #endregion

        #region Métodos Básicos

        /*  
         * Criado por ASP 2008/09/14 - Funciona nos ambientes Ajax ou não Ajax
         *  os métodos abaixo exigem o javascript helper.js
         */

        #region AddJavaScripts
        private void AddJavaScripts()
        {
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "jquery", ResolveUrl("~/Shared/Javascript/jquery-1.4.2.min.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "core", ResolveUrl("~/Shared/Javascript/ui/ui.core.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "dialog", ResolveUrl("~/Shared/Javascript/ui/ui.dialog.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "draggable", ResolveUrl("~/Shared/Javascript/ui/ui.draggable.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "resizable", ResolveUrl("~/Shared/Javascript/ui/ui.resizable.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "datepicker", ResolveUrl("~/Shared/Javascript/ui/ui.datepicker.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "datepickerBR", ResolveUrl("~/Shared/Javascript/ui/ui.datepicker-pt-BR.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "accordion", ResolveUrl("~/Shared/Javascript/ui/ui.accordion.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "thickbox", ResolveUrl("~/Shared/Javascript/ui/ui.thickbox.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "MaskedEdit", ResolveUrl("~/Shared/Javascript/ui/ui.MaskedEdit.js"));

            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "helper", ResolveUrl("~/Shared/Javascript/helper.js"));

            /* Entrada de Data */
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "dateentry", ResolveUrl("~/Shared/Javascript/libs/jquery.dateentry.min.js"));
            /* Abaixo, formatada a entrada de dados para pt-BR - 
             * Caso haja a necessidade de adaptação do sistemas para outras culturas 
             * consultar: http://keith-wood.name/dateEntry.html
             */
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "dateentryBR", ResolveUrl("~/Shared/Javascript/libs/jquery.dateentry-br.js"));

            /* http://github.com/plentz/jquery-maskmoney */
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "currencyentry", ResolveUrl("~/Shared/Javascript/libs/jquery.maskMoney.0.2.js"));

            /* Entrada de Hora */
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "timeentry", ResolveUrl("~/Shared/Javascript/libs/jquery.timeentry.min.js"));
            /* Abaixo, formatada a entrada de dados para pt-BR - 
             * Caso haja a necessidade de adaptação do sistemas para outras culturas 
             * consultar: http://keith-wood.name/dateEntry.html
             */
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "timeentryPT", ResolveUrl("~/Shared/Javascript/libs/jquery.timeentry-pt.js"));

            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "bgiframe", ResolveUrl("~/Shared/Javascript/libs/jquery.bgiframe.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "dimensions", ResolveUrl("~/Shared/Javascript/libs/jquery.dimensions.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "Tooltip", ResolveUrl("~/Shared/Javascript/libs/jquery.tooltip.js"));

            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "SpryMenuBar", ResolveUrl("~/Shared/Javascript/MenuBar/SpryMenuBar.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "Script", ResolveUrl("~/Shared/Javascript/Script.js"));
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "Loading", ResolveUrl("~/Shared/Javascript/Loading.js"));

            #region Aguarde Processando
            /* Fundamentais para disponibilizar a mensagem de processamento */
            ScriptManager.RegisterClientScriptInclude(this, typeof(String), "blockUI", ResolveUrl("~/Shared/Javascript/ui/jquery.blockUI.js"));
            String Script = "\nfunction showWaiting(){$.blockUI({message:'<h1><img src=\"";
            Script += String.Concat(Common.GetHost(), "Shared/images/ajax-loader.gif") + "\" alt=\"\" /> ";
            Script += String.Concat(MensagemAguarde, "</h1>',css:{border:'none',padding:'15px',backgroundColor:'#000',");
            Script += "'-webkit-border-radius':'10px','-moz-border-radius':'10px',opacity:.5,color:'#fff'}});";
            Script += "setTimeout($.unblockUI, 10000);}";
            Script += "function hideWaiting(){$.unblockUI();}\n";
            RegisterScriptToPage("PLSWAITFUNCTION", Script);
            #endregion Aguarde Processando

        }
        #endregion AddJavaScripts

        #region JQueryFormat
        public static String JQueryFormat(String Script)
        {
            return String.Concat(sJQueryIni, Script, sJQueryEnd);
        }
        #endregion JQueryFormat

        #region RegisterScriptToPage
        private static void RegisterScriptToPage(String ScriptName, String Script)
        {
            ScriptName = String.Concat("JQUERYSCRIPT", ScriptName.ToUpper(), System.Guid.NewGuid().ToString().ToUpper()).Replace("_", "").Replace("-", "");
            _UsedKeys.Add(ScriptName);
            Page _Page = (Page)HttpContext.Current.Handler;
            try
            {
                if (ScriptManager.GetCurrent(_Page).EnablePartialRendering)
                {
                    ScriptManager.RegisterStartupScript(_Page, _Page.GetType(), ScriptName, Script, true);
                }
                else
                {
                    _Page.ClientScript.RegisterStartupScript(_Page.GetType(), ScriptName, Script, true);
                }
            }
            catch 
            {
                _Page.ClientScript.RegisterStartupScript(_Page.GetType(), ScriptName, Script, true);
            }
        }

        /// <summary>
        /// Envia uma instrução Javascript definida em sScript para a página corrente
        /// </summary>
        /// <param name="sScript">Instruções Javascript</param>
        public static void RegisterScriptToPage(String sScript)
        {
            RegisterScriptToPage("RegisterScriptToHtml", sScript);
        }
        #endregion RegisterScriptToPage

        #region ShowAlert
        /// <summary>
        /// Alias para ShowMessage, abre uma caixa modal com uma mensagem
        /// </summary>
        /// <param name="page"></param>
        /// <param name="message"></param>
        public void SetMessage(System.Web.UI.Page page, string message)
        {
            ShowAlert(message);
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        /// <param name="Title">Título da Janela</param>
        /// <param name="oFocus">Foca no objeto ao clicar em Ok ou fechar</param>
        public static void ShowAlert(String Message, String Title, Control oFocus)
        {
            _ScriptRegistring.Add(ShowAlertToString(Message, Title, oFocus));
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog (o título será "Atenção")
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        /// <param name="Title">Título da Janela</param>
        public static void ShowAlert(String Message, String Title)
        {
            ShowAlert(Message, (Title == String.Empty ? "Atenção" : Title), null);
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog (o título será "Atenção")
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        public static void ShowAlert(String Message)
        {
            ShowAlert(Message, "Atenção", null);
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog (o título será "Atenção")
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        /// <param name="Title">Título da Janela</param>
        /// <param name="oFocus">Foca no objeto ao clicar em Ok ou fechar</param>
        public static String ShowAlertToString(String Message, String Title, Control oFocus)
        {
            return String.Concat("showJQueryAlert('",
                Message.Replace("'", "´").Replace("\r", "\n").Replace("\n", "<br />"), "','",
                (Title == String.Empty ? "Atenção" : Title), "'",
                (oFocus != null ? ",'document.getElementById(\"" + oFocus.ClientID + "\").focus(); $(\\'#dialog\\').dialog(\"close\");'" : ""), ");");
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog (o título será "Atenção")
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        /// <param name="Title">Título da Janela</param>
        public static String ShowAlertToString(String Message, String Title)
        {
            return ShowAlertToString(Message, Title, null);
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog (o título será "Atenção")
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        public static String ShowAlertToString(String Message)
        {
            return ShowAlertToString(Message, "Atenção", null);
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        /// <param name="Title">Título da Janela</param>
        /// <param name="Title">URL Para redirecionar</param>
        public static void ShowAlertAndRedirect(String Message, String Title, String stURL)
        {
            _ScriptRegistring.Add(ShowAlertAndRedirectToString(Message, Title, stURL));
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        /// <param name="Title">Título da Janela</param>
        /// <param name="Title">URL Para redirecionar</param>
        public static void ShowAlertAndRedirect(String Message, String stURL)
        {
            ShowAlertAndRedirect(Message, "Atenção", stURL);
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog (o título será "Atenção")
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        /// <param name="Title">Título da Janela</param>
        public static String ShowAlertAndRedirectToString(String Message, String Title, String stURL)
        {
            return String.Concat("showJQueryAlert('",
                Message.Replace("'", "´").Replace("\r", "\n").Replace("\n", "<br />"), "','",
                (Title == String.Empty ? "Atenção" : Title), "','",
                "top.window.location.replace(\\'", stURL, "\\');');");
        }

        /// <summary>
        /// Envia um alert, usando os recursos do JQuery Dialog (o título será "Atenção")
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada</param>
        /// <param name="Title">Título da Janela</param>
        /// <param name="Title">URL Para redirecionar</param>
        public static String ShowAlertAndRedirectToString(String Message, String stURL)
        {
            return ShowAlertAndRedirectToString(Message, "Atenção", stURL);
        }
        #endregion ShowAlert

        #region ShowConfirm
        /// <summary>
        /// Mostra caixa de confirmação
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada (questionamento)</param>
        /// <param name="Title">Título da caixa</param>
        /// <param name="Function">O que será executado no caso de confirmação positiva, caso a confirmação seja negativa fecha a caixa.</param>
        public static void ShowConfirm(String Message, String Title, String Function)
        {
            _ScriptRegistring.Add(ShowConfirmToString(Message, Title, Function));
        }

        /// <summary>
        /// Retorna uma string com o código para abrir uma caixa de confirmação
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Title"></param>
        /// <param name="Function"></param>
        /// <returns></returns>
        public static String ShowConfirmToString(String Message, String Title, String Function)
        {
            return String.Concat("showJQueryConfirm('", Message.Replace("'", "´").Replace("\r", "\n").Replace("\n", "<br />"), "','", Title, "','", Function.Replace("'", "\\'"), "');");
        }
        #endregion ShowConfirm

        #region ShowYesNo
        /// <summary>
        /// Mostra caixa de confirmação Com botões Sim ou Não
        /// </summary>
        /// <param name="Message">Mensagem a ser mostrada (questionamento)</param>
        /// <param name="Title">Título da caixa</param>
        /// <param name="Function">O que será executado no caso de confirmação positiva, caso a confirmação seja negativa fecha a caixa.</param>
        public static void ShowYesNo(String Message, String Title, String Function)
        {
            _ScriptRegistring.Add(ShowConfirmToString(Message, Title, Function));
        }

        /// <summary>
        /// Retorna uma string com o código para abrir uma caixa de confirmação
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Title"></param>
        /// <param name="Function"></param>
        /// <returns></returns>
        public static String ShowYesNoToString(String Message, String Title, String Function)
        {
            return String.Concat("showJQueryYesNo('", Message.Replace("'", "´").Replace("\r", "\n").Replace("\n", "<br />"), "','", Title, "','", Function.Replace("'", "\\'"), "');");
        }
        #endregion ShowYesNo

        #region FormatDoPost
        /// <summary>
        /// Monta o comando para fazer um determinado PostBack. Será realizado um postback e executar o evento de click do controle responsável.
        /// </summary>
        /// <param name="pControl">Controle responsável pelo PostBack</param>
        /// <returns>Retorna uma String com o comando montado</returns>
        public static String FormatDoPost(Control pControl)
        {
            return String.Concat("__doPostBack(document.getElementById('", pControl.ClientID, "').name, '');");
        }
        #endregion FormatDoPost

        #region setTextDateEntry
        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Data (dd/mm/aaaa)
        /// </summary>
        /// <param name="pControl">Controle Textbox</param>
        /// <param name="pType">Tipo de controle</param>
        /// <param name="ChangeYear">Indica se deverá mostrar um select de anos</param>
        /// <param name="ChangeMonth">Indica se deverá mostrar um select de meses</param>
        /// <param name="YearRange">Faixa de anos a ser mostrado, padrão é -10:+10, formato -n:+n</param>
        public static void setTextDateEntry(Control TextControl, TextboxDateEntryType DateEntryType, Boolean ChangeYear, Boolean ChangeMonth, String YearRange)
        {
            if (!(TextControl is System.Web.UI.WebControls.TextBox)) return;
            ((System.Web.UI.WebControls.TextBox)TextControl).Width = new System.Web.UI.WebControls.Unit(80);
            YearRange = String.IsNullOrEmpty(YearRange) ? "-10:+10" : YearRange;
            String sScript = String.Concat("$('#", TextControl.ClientID, "').dateEntry({");
            if (DateEntryType == TextboxDateEntryType.Full || DateEntryType == TextboxDateEntryType.Spinner)
            {
                sScript += String.Concat("spinnerImage:'", Common.GetHost(), "Shared/StyleSheet/images/dateEntrySpinners/spinnerGreen.png',");
                sScript += String.Concat("spinnerBigImage:'", Common.GetHost(), "Shared/StyleSheet/images/dateEntrySpinners/spinnerGreenBig.png'");
            }
            sScript += "});\n";
            if (DateEntryType == TextboxDateEntryType.Full || DateEntryType == TextboxDateEntryType.Picker)
            {
                sScript += String.Concat("$('#", TextControl.ClientID, "').datepicker({showOtherMonths: true,");
                sScript += String.Concat("navigationAsDateFormat: true,");
                if (ChangeYear) { sScript += String.Concat("changeYear: true,"); }
                if (ChangeMonth) { sScript += String.Concat("changeMonth: true,"); }
                sScript += String.Concat("yearRange: '", YearRange, "'});");
            }
            _ScriptRegistring.Add(sScript);
        }
        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Data (dd/mm/aaaa)
        /// </summary>
        /// <param name="pControl">Controle Textbox</param>
        /// <param name="pType">Tipo de controle</param>
        public static void setTextDateEntry(Control TextControl, TextboxDateEntryType DateEntryType)
        {
            setTextDateEntry(TextControl, DateEntryType, true, true, "-10:+10");
        }

        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Data (dd/mm/aaaa)
        /// </summary>
        /// <param name="pControl">Controle Textbox</param>
        public static void setTextDateEntry(Control TextControl)
        {
            setTextDateEntry(TextControl, TextboxDateEntryType.Picker, true, true, "-10:+10");
        }
        #endregion setTextDateEntry

        #region setTextTimeEntry
        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Hora (HH:mm)
        /// </summary>
        /// <param name="pControl">Controle Textbox</param>
        /// <param name="bSpinner">Indica se mostra ou não os botões de spinner</param>
        public static void setTextTimeEntry(Control pControl, Boolean bSpinner)
        {
            if (!(pControl is System.Web.UI.WebControls.TextBox)) return;
            ((System.Web.UI.WebControls.TextBox)pControl).Width = new System.Web.UI.WebControls.Unit(50);
            String sScript = String.Concat("$('#", pControl.ClientID, "').timeEntry({show24Hours: true");
            if (bSpinner)
            {
                sScript += String.Concat(",spinnerImage:'", Common.GetHost(), "Shared/StyleSheet/images/dateEntrySpinners/spinnerGreen.png'");
                sScript += String.Concat(",spinnerBigImage:'", Common.GetHost(), "Shared/StyleSheet/images/dateEntrySpinners/spinnerGreenBig.png'");
            }
            sScript += "});";
            _ScriptRegistring.Add(sScript);
        }

        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Hora (HH:mm)
        /// </summary>
        /// <param name="pControl">Controle Textbox</param>
        public static void setTextTimeEntry(Control pControl)
        {
            setTextTimeEntry(pControl, true);
        }
        #endregion setTextTimeEntry

        #region setTextCurrencyEntry
        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Numerários (R$ n.nnn,nn)
        /// </summary>
        /// <param name="Control">Controle Textbox</param>
        /// <param name="ShowSymbol">Indica se mostra ou não o Símbolo R$</param>
        /// <param name="Precision">Indica a precisão, número de casas decimais</param>
        /// <param name="MaxLength">Indica tamanho máximo para entrada de dados</param>
        public static void setTextCurrencyEntry(Control pControl, Boolean ShowSymbol, Int16? Precision, Int32? MaxLength)
        {
            if (!(pControl is System.Web.UI.WebControls.TextBox)) return;
            Precision = Precision == null ? Convert.ToInt16(2) : Precision;
            MaxLength = MaxLength == null ? 14 : (MaxLength == 0 ? 14 : MaxLength);
            ((System.Web.UI.WebControls.TextBox)pControl).Style.Add(HtmlTextWriterStyle.Direction, "rtl");
            String sScript = String.Concat("$('#", pControl.ClientID, "').maskMoney({");
            sScript += String.Concat("maxLength: ", MaxLength.ToString(), ",");
            if (ShowSymbol)
            {
                sScript += String.Concat("showSymbol: true, ");
            }
            sScript += String.Concat("precision: ", Precision);
            sScript += "});\n";

            _ScriptRegistring.Add(sScript);
        }

        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Numerários (R$ n.nnn,nn)
        /// </summary>
        /// <param name="Control">Controle Textbox</param>
        /// <param name="ShowSymbol">Indica se mostra ou não o Símbolo R$</param>
        /// <param name="Precision">Indica a precisão, número de casas decimais</param>
        public static void setTextCurrencyEntry(Control pControl, Boolean ShowSymbol, Int16 Precision)
        {
            setTextCurrencyEntry(pControl, ShowSymbol, Precision, 11 - (Precision > 9 ? Precision - (Precision - 9) : Precision));
        }

        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Numerários (n.nnn,nn)
        /// </summary>
        /// <param name="pControl">Controle Textbox</param>
        public static void setTextCurrencyEntry(Control pControl)
        {
            setTextCurrencyEntry(pControl, false, 2, 9);
        }

        /// <summary>
        /// Ajusta um TextBox para tratar entrada de Numerários (n.nnn,nn)
        /// </summary>
        /// <param name="pControl">Controle Textbox</param>
        public static void setTextNumericEntry(Control pControl)
        {
            setTextCurrencyEntry(pControl, false, 0, 7);
        }
        #endregion setTextCurrencyEntry

        #region Accordion Methods

        #region setAccordion
        /// <summary>
        /// Prepara um div para ser tratado como Accordion
        /// </summary>
        /// <param name="DivID">ID cliente do DIV principal que receberá o tratamento do Accordion</param>
        public static void setAccordion(String DivID)
        {
            String sScript = String.Concat("$(\"#", DivID, "\").accordion({ autoHeight: false, alwaysOpen: false, active: false });");
            _ScriptRegistring.Add(sScript);
        }
        #endregion setAccordionEntry

        #region AccordionEnabled
        public static void AccordionEnabled(HtmlGenericControl Control, Boolean EnabledState)
        {
            String ChangeAccordionState = "";
            ChangeAccordionState += String.Concat("$(\"#", Control.ClientID, "\").attr(\"disabled\", ", (EnabledState ? "\"disabled\"" : "\"\""), ");\n");
            ChangeAccordionState += String.Concat("$(\"#", Control.ClientID, " a:first\").attr(\"disabled\", ", (EnabledState ? "\"disabled\"" : "\"\""), ");\n");
            ChangeAccordionState += String.Concat("$(\"#", Control.ClientID, "\").parent().accordion(\"activate\", false);");
            _ScriptRegistring.Add(ChangeAccordionState);
        }
        #endregion AccordionEnabled

        #endregion Accordion Methods

        #region setWaitingMessage
        public static void setWaitingMessage(System.Web.UI.WebControls.LinkButton Control)
        {
            Control.Attributes.Add("onclick", "showWaiting();");
        }

        public static void setWaitingMessage(System.Web.UI.WebControls.Button Control)
        {
            Control.Attributes.Add("onclick", "showWaiting();");
        }

        public static void setWaitingMessage(System.Web.UI.HtmlControls.HtmlButton Control)
        {
            Control.Attributes.Add("onclick", "showWaiting();");
        }

        public static void setWaitingMessage(System.Web.UI.HtmlControls.HtmlLink Control)
        {
            Control.Attributes.Add("onclick", "showWaiting();");
        }
        #endregion setWaitingMessage

        #region PrepareDialog
        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel
        /// </summary>
        /// <param name="Title">Window Title</param>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        /// <param name="TargetPanel">Panel Empty used to append Dialog Panel - Solve problems with Ajax x JQuery</param>
        /// <param name="Top">Window Position Top</param>
        /// <param name="Left">Window Position Left</param>
        /// <param name="Width">Window Width</param>
        /// <param name="Height">Window Height</param>
        /// <param name="Modal">Indicates whether dialog is modal or not</param>
        /// <param name="Resizable">Indicates whether dialog can be resizable by user</param>
        public static void PrepareDialog(String Title, Panel EditFormDialog, object ButtonAssign,
            Panel TargetPanel, Int32 Top, Int32 Left, Int32 Width, Int32 Height, Boolean Modal, Boolean Resizable)
        {
            try
            {
                Control ScopeTarget = (Control)EditFormDialog;
                Title = String.IsNullOrEmpty(Title) ? ((Page)HttpContext.Current.Handler).Title : Title;
                TargetPanel.Style.Add(HtmlTextWriterStyle.ZIndex, "3001");
                TargetPanel.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                TargetPanel.Style.Add(HtmlTextWriterStyle.Top, "1px");

                String Script = "$('#" + EditFormDialog.ClientID + "').dialog({\n";
                Script += "autoOpen:false,\nheight:" + Height.ToString() + ",\nwidth:" + Width.ToString() + ",\n";
                Script += "modal:" + Modal.ToString().ToLower() + ",\n";
                if (Modal)
                {
                    Script += "overlay:{ backgroundColor:'#000', opacity:0.5 },\n";
                }
                Script += "resizable:" + Resizable.ToString().ToLower() + ",\n";
                Script += "bgiframe:true,\ntitle:'" + Title + "',\ncloseOnEscape:true\n});\n";
                Script += "$('#" + EditFormDialog.ClientID + "').parent().appendTo('#" + TargetPanel.ClientID + "');\n";

                _DialogScriptCommand = "";
                _DialogScriptCommand += "$('#" + EditFormDialog.ClientID + "').dialog('option','position',[";
                //_DialogScriptCommand += String.Concat(Left == 0 ? "$(this).position().left+$(this).width()" : Left.ToString(), ",");
                //_DialogScriptCommand += String.Concat(Top == 0 ? "$(this).position().top-$(document).scrollTop()+$('#" + EditFormDialog.ClientID + "').outerHeight()" : Top.ToString());

                _DialogScriptCommand += String.Concat(Left == 0 ? "100" : Left.ToString(), ",");
                _DialogScriptCommand += String.Concat(Top == 0 ? "100" : Top.ToString());

                _DialogScriptCommand += "]);";

                _DialogScriptCommand += "$('#" + EditFormDialog.ClientID + "').dialog('open');";
                if (ButtonAssign is Button)
                {
                    ((Button)ButtonAssign).OnClientClick = String.Concat(_DialogScriptCommand, "return false;");
                }
                if (ButtonAssign is ImageButton)
                {
                    ((ImageButton)ButtonAssign).OnClientClick = String.Concat(_DialogScriptCommand, "return false;");
                }
                if (ButtonAssign is LinkButton)
                {
                    ((LinkButton)ButtonAssign).OnClientClick = String.Concat(_DialogScriptCommand, "return false;");
                }
                _ScriptRegistring.Add(Script);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel
        /// </summary>
        /// <param name="Title">Window Title</param>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        /// <param name="Top">Window Position Top</param>
        /// <param name="Left">Window Position Left</param>
        /// <param name="Width">Window Width</param>
        /// <param name="Height">Window Height</param>
        /// <param name="Modal">Indicates whether dialog is modal or not</param>
        /// <param name="Resizable">Indicates whether dialog can be resizable by user</param>
        public static void PrepareDialog(String Title, Panel EditFormDialog, object ButtonAssign,
            Int32 Top, Int32 Left, Int32 Width, Int32 Height, Boolean Modal, Boolean Resizable)
        {
            Panel TargetPanel = null;
            Control ScopeTarget = (Control)EditFormDialog;
            while (TargetPanel == null && ScopeTarget != null)
            {
                if (ScopeTarget.FindControl("pnlEmptyDiv") is Panel) TargetPanel = (Panel)ScopeTarget.FindControl("pnlEmptyDiv");
                ScopeTarget = ScopeTarget.Parent;
            }
            if (TargetPanel == null)
            {
                throw new Exception("PrepareDialog Error -> Missing a panel called \"pnlEmptyDiv\".");
            }
            PrepareDialog(Title, EditFormDialog, ButtonAssign, TargetPanel, Top, Left, Width, Height, Modal, Resizable);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel
        /// </summary>
        /// <param name="Title">Window Title</param>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        /// <param name="Width">Window Width</param>
        /// <param name="Height">Window Height</param>
        /// <param name="Modal">Indicates whether dialog is modal or not</param>
        /// <param name="Resizable">Indicates whether dialog can be resizable by user</param>
        public static void PrepareDialog(String Title, Panel EditFormDialog, object ButtonAssign, Int32 Width, Int32 Height, Boolean Modal, Boolean Resizable)
        {
            Panel TargetPanel = null;
            Control ScopeTarget = (Control)EditFormDialog;
            while (TargetPanel == null && ScopeTarget != null)
            {
                if (ScopeTarget.FindControl("pnlEmptyDiv") is Panel) TargetPanel = (Panel)ScopeTarget.FindControl("pnlEmptyDiv");
                ScopeTarget = ScopeTarget.Parent;
            }
            if (TargetPanel == null)
            {
                throw new Exception("PrepareDialog Error -> Missing a panel called \"pnlEmptyDiv\".");
            }
            PrepareDialog(Title, EditFormDialog, ButtonAssign, TargetPanel, 0, 0, Width, Height, Modal, Resizable);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel.
        /// It will open normal dialog resizable width=380 by height=250
        /// </summary>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        public static void PrepareDialog(String Title, Panel EditFormDialog, object ButtonAssign)
        {
            PrepareDialog(Title, EditFormDialog, ButtonAssign, 380, 250, false, false);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel.
        /// It will open modal dialog width=380 by height=250
        /// </summary>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        public static void PrepareDialogModal(String Title, Panel EditFormDialog, object ButtonAssign)
        {
            PrepareDialog(Title, EditFormDialog, ButtonAssign, 380, 250, false, false);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel.
        /// It will open modal dialog resizable width=380 by height=250
        /// </summary>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        /// <param name="Resizable">Indicates whether dialog can be resizable by user</param>
        public static void PrepareDialogModal(String Title, Panel EditFormDialog, object ButtonAssign, Boolean Resizable)
        {
            PrepareDialog(Title, EditFormDialog, ButtonAssign, 0, 0, 380, 250, true, Resizable);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel.
        /// It will open modal dialog
        /// </summary>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        /// <param name="Width">Window Width</param>
        /// <param name="Height">Window Height</param>
        /// <param name="Resizable">Indicates whether dialog can be resizable by user</param>
        public static void PrepareDialogModal(String Title, Panel EditFormDialog, object ButtonAssign, Int32 Width, Int32 Height, Boolean Resizable)
        {
            PrepareDialog(Title, EditFormDialog, ButtonAssign, 0, 0, Width, Height, true, Resizable);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel.
        /// It will open modal dialog
        /// </summary>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        /// <param name="TargetPanel">Panel Empty used to append Dialog Panel - Solve problems with Ajax x JQuery</param>
        /// <param name="Width">Window Width</param>
        /// <param name="Height">Window Height</param>
        /// <param name="Resizable">Indicates whether dialog can be resizable by user</param>
        public static void PrepareDialogModal(String Title, Panel EditFormDialog, object ButtonAssign,
            Panel TargetPanel, Int32 Width, Int32 Height, Boolean Resizable)
        {
            PrepareDialog(Title, EditFormDialog, ButtonAssign, TargetPanel, 0, 0, Width, Height, true, Resizable);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel.
        /// It will open modal dialog
        /// </summary>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        /// <param name="TargetPanel">Panel Empty used to append Dialog Panel - Solve problems with Ajax x JQuery</param>
        /// <param name="Top">Window Position Top</param>
        /// <param name="Left">Window Position Left</param>
        /// <param name="Width">Window Width</param>
        /// <param name="Height">Window Height</param>
        /// <param name="Resizable">Indicates whether dialog can be resizable by user</param>
        public static void PrepareDialogModal(String Title, Panel EditFormDialog, object ButtonAssign,
            Panel TargetPanel, Int32 Top, Int32 Left, Int32 Width, Int32 Height, Boolean Resizable)
        {
            PrepareDialog(Title, EditFormDialog, ButtonAssign, TargetPanel, Top, Left, Width, Height, true, Resizable);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel.
        /// It will open modal resizable dialog width=380 by height=250
        /// </summary>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="ButtonAssign">Button used to put code panel.dialog(open)</param>
        public static void PrepareDialogModalResizable(String Title, Panel EditFormDialog, object ButtonAssign)
        {
            PrepareDialog(Title, EditFormDialog, ButtonAssign, 0, 0, 380, 250, false, true);
        }

        /// <summary>
        /// Prepare a panel content to be open like dialog, and button onclick event to open that panel
        /// </summary>
        /// <param name="Title">Window Title</param>
        /// <param name="EditFormDialog">Panel to be open dialog</param>
        /// <param name="TargetPanel">Panel Empty used to append Dialog Panel - Solve problems with Ajax x JQuery</param>
        /// <param name="Top">Window Position Top</param>
        /// <param name="Left">Window Position Left</param>
        /// <param name="Width">Window Width</param>
        /// <param name="Height">Window Height</param>
        /// <param name="Modal">Indicates whether dialog is modal or not</param>
        /// <param name="Resizable">Indicates whether dialog can be resizable by user</param>
        public static void OpenDialog(String Title, Panel EditFormDialog,
            Panel TargetPanel, Int32 Top, Int32 Left, Int32 Width, Int32 Height, Boolean Modal, Boolean Resizable)
        {
            try
            {
                Control ScopeTarget = (Control)EditFormDialog;
                Title = String.IsNullOrEmpty(Title) ? ((Page)HttpContext.Current.Handler).Title : Title;
                TargetPanel.Style.Add(HtmlTextWriterStyle.ZIndex, "2001");
                TargetPanel.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                TargetPanel.Style.Add(HtmlTextWriterStyle.Top, "1px");

                String Script = "$('#" + EditFormDialog.ClientID + "').dialog({\n";
                Script += "autoOpen: false,\n";
                Script += "height: " + Height.ToString() + ",\n";
                Script += "width: " + Width.ToString() + ",\n";
                Script += "modal: " + Modal.ToString().ToLower() + ",\n";
                Script += "resizable: " + Resizable.ToString().ToLower() + ",\n";
                Script += "bgiframe: true,\n";
                Script += "title: '" + Title + "',\n";
                Script += "closeOnEscape: true,\n";
                if (Modal)
                {
                    Script += "overlay:{ backgroundColor:'#000', opacity:0.5 }\n";
                }
                Script += "});\n";
                Script += "$('#" + EditFormDialog.ClientID + "').parent().appendTo('#" + TargetPanel.ClientID + "');\n";

                Script += "$('#" + EditFormDialog.ClientID + "').dialog('option','position',[";
                Script += String.Concat(Left == 0 ? "$(this).position().left + $(this).outerWidth()" : Left.ToString(), ",");
                Script += String.Concat(Top == 0 ? "$(this).position().top - $(document).scrollTop()" : Top.ToString());
                Script += "]);";

                Script += "$('#" + EditFormDialog.ClientID + "').dialog('open');\n";

                _ScriptRegistring.Add(Script);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion PrepareDialog

        #region Tooltip
        private static String CreateToolTipScript(String Name)
        {
            return "$(\"#" + Name + "\").tooltip({track:true,delay:5,showURL:false,"
            + "fixPNG:true,showBody:\" - \",extraClass:\"pretty fancy\",top:-15,left:5});";
        }

        public static void SetToolTip(WebControl ControlSource, String Mensagem)
        {
            ControlSource.ToolTip = Mensagem;
            String Script = CreateToolTipScript(ControlSource.ClientID);
            _ScriptRegistring.Add(Script);
        }

        public static void SetToolTip(HtmlControl ControlSource, String Mensagem)
        {
            ControlSource.Attributes.Add("title", Mensagem);
            String Script = CreateToolTipScript(ControlSource.ClientID);
            _ScriptRegistring.Add(Script);
        }
        #endregion Tooltip

        #region MaskEdit
        private static String CreateMaskEdit(String Name, String Mask)
        {
            return "$(\"#" + Name + "\").mask(\"" + Mask + "\");";
        }

        public static void SetMask(WebControl ControlSource, String Mask)
        {
            ControlSource.ToolTip = MensagemAguarde;
            String Script = CreateMaskEdit(ControlSource.ClientID, Mask);
            _ScriptRegistring.Add(Script);
        }

        public static void SetMask(HtmlControl ControlSource, String Mask)
        {
            ControlSource.Attributes.Add("title", MensagemAguarde);
            String Script = CreateMaskEdit(ControlSource.ClientID, Mask);
            _ScriptRegistring.Add(Script);
        }
        #endregion MaskEdit

        #region OpenModalPopupToString
        /// <summary>
        /// Retorna um string com os comandos a serem implementados em um OnClientClick ou diretamente para o render da página
        /// </summary>
        /// <param name="URL">Página a ser aberta</param>
        /// <param name="Width">Largura da Janela</param>
        /// <param name="Height">Altura da Janela</param>
        /// <returns>Comando para abrir uma pagina em modal popup</returns>
        public static String OpenModalPopupToString(String URL, Int32 Width, Int32 Height)
        {
            return String.Concat("tb_show('Detalhes Ordem de Recebimento', '", URL, "&KeepThis=true&TB_iframe=true&height=",
                                Height, "&width=", Width, "&inlineId=hiddenModalContent', null);");
        }
        #endregion OpenModalPopupToString

        #endregion Métodos Básicos

    }

}