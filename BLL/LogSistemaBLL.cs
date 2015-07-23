using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medusa.DAL;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Medusa.BLL
{
    public class LogSistemaBLL: Abstract_Crud<LogSistema>
    {
        public LogSistemaBLL()
        {
            HttpRequest currentRequest = HttpContext.Current.Request;
            string ipAddress = currentRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (ipAddress == null || ipAddress.ToLower() == "unknown")
                ipAddress = currentRequest.ServerVariables["REMOTE_ADDR"];
            
            ObjEF.ip = ipAddress;
            ObjEF.data = DateTime.Now;
            ObjEF.id_pessoa = SecurityBLL.GetCurrentId_usuario();
        }

        public string GetEntidade()
        {
            StringBuilder tabela = new StringBuilder();            
            try
            {
                Type tipo = Type.GetType(String.Format("Medusa.BLL.{0}BLL", ObjEF.entidade));
                Type[] types = new Type[] { };
                ConstructorInfo cInfo = tipo.GetConstructor(types);
                object objEntidade = cInfo.Invoke(new object[] { });
                MethodInfo metodo = tipo.GetMethod("Get");
                metodo.Invoke(objEntidade, new object[] { ObjEF.id_entidade });
                object obj = tipo.GetProperty("ObjEF").GetValue(objEntidade, new object[] { });
                
                foreach (var property in obj.GetType().GetProperties())
                {
                    tabela.Append("<tr><td class=\"esquerdo\">");
                    tabela.Append(property.Name);
                    tabela.Append("</td>");
                    tabela.Append("<td class=\"direito\">");
                    tabela.Append(Convert.ToString(property.GetValue(obj, new object[] { })));
                    tabela.Append("</td></tr>");                    
                }                
                return tabela.ToString();
            }
            catch (Exception)
            {
                return null;
            }

            
        }
    }
}