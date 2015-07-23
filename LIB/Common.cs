using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Text;

namespace Medusa.LIB
{
    public class Common
    {

        #region GetCssHtmlLink Method
        static HtmlLink GetCssHtmlLink(String CssPath)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("href", CssPath);
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");

            return link;
        }
        #endregion

        #region RegisterStyleSheet Method
        public static void RegisterStyleSheet(PlaceHolder phCss, String StyleSheetPath)
        {
            phCss.Controls.Add(GetCssHtmlLink(StyleSheetPath));
        }
        #endregion

        #region GetHost Method
        public static String GetHost()
        {
            String Port = String.Empty, Protocol = String.Empty, BaseUrl = String.Empty;

            //get the port we are operating on
            Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"].ToString();
            Port = (Port == null || Port == "80" || Port == "443") ? "" : ":" + Port;

            //load the protocol value
            Protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"].ToString();
            Protocol = Protocol == null || Protocol == "0" ? "http://" : "https://";

            //assemble the base path
            BaseUrl = Protocol + HttpContext.Current.Request.ServerVariables["Server_Name"].ToString() + Port + HttpContext.Current.Request.ApplicationPath.ToString();

            //return ConfigurationManager.AppSettings["Url"].ToString();
            String UrlHost = BaseUrl.Substring(0, BaseUrl.Length).ToLower();
            return String.Concat(UrlHost, (UrlHost.EndsWith("/") ? "" : "/"));
        }
        #endregion
    }
}
