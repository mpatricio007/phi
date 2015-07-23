using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text;
using System.Globalization;

namespace Medusa.LIB
{
    public class Util
    {
        public static string TirarFormatoConta(string cta)
        {           
            return cta.Substring(0, cta.Length - 1).Replace(".", "").Replace("-", "");
        }


        public static string DateToString(DateTime? date)
        {
            return (!date.HasValue) || (date == DateTime.MinValue) ? String.Empty : date.GetValueOrDefault().ToShortDateString();
        }

        public static DateTime? StringToDate(string strData)
        {
            DateTime dtOut;
            if (DateTime.TryParse(strData, out dtOut))
                return dtOut;
            else
                return null;
        }

        public static DateTime? StringSemBarrasToDate(string strData)
        {
            DateTime dtOut;
            if (DateTime.TryParseExact(strData, "ddMMyyyy", new CultureInfo("pt-BR"),DateTimeStyles.None, out dtOut))
                return dtOut;
            else
                return null;
        }

        public static string DecimalToString(Decimal? valor)
        {
            return (!valor.HasValue) ? String.Empty : valor.GetValueOrDefault().ToString();
        }

        public static Decimal? StringToDecimal(string strDecimal)
        {
            Decimal decOut;
            if (Decimal.TryParse(strDecimal, out decOut))
                return decOut;
            else
                return null;
        }


        public static string InteiroToString(int? inteiro)
        {
            return (!inteiro.HasValue) ? String.Empty : inteiro.GetValueOrDefault().ToString();
        }

        public static int? StringToInteiro(string strInteiro)
        {
            int intOut;
            if (int.TryParse(strInteiro, out intOut))
                return intOut;
            else
                return null;
        }


        public static string TranslateAction(string acao)
        {
            string saida = "";
            switch (acao.ToLower())
            {
                case "added":
                    saida = "inclusão";
                    break;
                case "modified":
                    saida = "alteração";
                    break;
                case "deleted":
                    saida = "exclusão";
                    break;
            }
            return saida;
        }

        public static void ShowMessage(string message)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null)
                ScriptManager.RegisterStartupScript(page, page.GetType(), "Alert", String.Format("alert('{0}')", message), true);


        }

        public static void PrintArea(string id)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null)
            {
                StringBuilder txt = new StringBuilder();
                txt.Append("var oPrint, oJan;");
                txt.Append(String.Format("oPrint  = window.document.getElementById('{0}').innerHTML;", id));
                txt.Append("oJan= window.open();oJan.document.write(oPrint);");
                txt.Append("oJan.history.go();oJan.window.print();");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "Print", txt.ToString(), true);
            }

        }

        public static void NovaJanela(string url)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null)
            {
                StringBuilder txt = new StringBuilder();
                txt.Append(String.Format("window.open('{0}','url');", url));                
                ScriptManager.RegisterStartupScript(page, page.GetType(), "new", txt.ToString(), true);
            }

        }       
    }
}


       
  