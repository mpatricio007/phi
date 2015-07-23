using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medusa.DAL;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace Medusa.BLL
{
    public class SecurityBLL
    {
        public static string GetSha1Hash(string input)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha1.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GeraSenha()
        {
            Random rd = new Random(System.DateTime.Now.Millisecond);
            StringBuilder senha = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                char ch = Convert.ToChar(rd.Next('A', 'Z' + 1));
                if (i % 2 == 0)
                    ch = Convert.ToChar(ch.ToString().ToLower());
                senha.Append(ch);
            }
            return senha.ToString();
        }

        public static bool GetPermission(string strUrl, out bool bGravacao)
        {           
            int intId_usuario = Convert.ToInt32(System.Web.HttpContext.Current.Session["id_usuario"]);            
            Contexto ctx = new Contexto();
            var usu = ctx.Pessoas.OfType<Usuario>().Where(it => it.id_pessoa == intId_usuario).FirstOrDefault();
            bGravacao = false;
            if (usu == null)
                return false;
            else if (usu.nivel == 1)
            {
                bGravacao = true;
                return true;
            }
            else
            {
                strUrl = strUrl.ToUpper().Replace("ASP.", "");
                strUrl = strUrl.Contains("_ASPX") ? strUrl.Replace("_ASPX", ".ASPX") : strUrl.Replace("_ASCX", ".ASCX");
                strUrl = strUrl.Replace("_", "/");     
                
                var ds = from p in ctx.Paginas
                         join mp in ctx.MenuPaginas on p.id_pagina equals mp.id_pagina
                         join mn in ctx.Menus on mp.id_menu equals mn.id_menu
                         join s in ctx.Sistemas on mn.id_sistema equals s.id_sistema
                         join us in ctx.Pessoas.OfType<Usuario>() on s.id_sistema equals us.id_sistema
                         where us.id_pessoa == intId_usuario
                            & p.url == strUrl
                         select mp;

                MenuPagina objMp = ds.FirstOrDefault();
                if (objMp == null)
                {
                    bGravacao = false;
                    return false;
                }
                else
                {
                    bGravacao = objMp.gravacao;
                    return objMp.leitura;
                }
            }
        }

        public static Usuario Login(string strLogin, string strSenha, out string saida)//, out string url,out int id_sistema)
        {
            Contexto ctx = new Contexto();
            strSenha = SecurityBLL.GetSha1Hash(strSenha);
            var user = ctx.Pessoas.OfType<Usuario>().Where(it => it.login == strLogin & it.senha == strSenha).FirstOrDefault();
            saida = user == null ? "Senha e/ou Login inválidos!" : String.Empty;
            /*url = user != null ? string.Format("{0}/{1}", "~",user.Sistema.Pagina.url) : String.Empty;
            id_sistema = user != null ? user.id_sistema : 0;*/
            //return user != null ? user : 0;
            return user;
        }

        public static string AlterarSenha(string strOldSenha, string strNewSenha)
        {
            string saida = String.Empty;            
            try
            {
                int intId_usuario = Convert.ToInt32(System.Web.HttpContext.Current.Session["id_usuario"]);
                Contexto ctx = new Contexto();
                Usuario usu = ctx.Pessoas.OfType<Usuario>().Where(it => it.id_pessoa == intId_usuario).FirstOrDefault();
                if (usu != null)
                {
                    if (usu.senha == SecurityBLL.GetSha1Hash(strOldSenha))
                    {
                        usu.senha = SecurityBLL.GetSha1Hash(strNewSenha);
                        if (ctx.SaveChanges() > 0)
                            saida = "Senha alterada com sucesso!";
                    }
                    else
                    {
                        saida = "Senha atual incorreta!";
                    }
                }
                else
                    saida = "Usuário não logado!";


            }
            catch (Exception ex)
            {
                saida = ex.Message;
            }           
            
            return saida;   
            
        }

        public static int GetCurrentId_usuario()
        {
            int id_usuario = Convert.ToInt32(System.Web.HttpContext.Current.Session["id_usuario"]);
            if (id_usuario == 0)            
                FormsAuthentication.RedirectToLoginPage();
            return id_usuario;
        }
    }
}