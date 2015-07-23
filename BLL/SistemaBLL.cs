using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medusa.DAL;
 
namespace Medusa.BLL
{
    public class SistemaBLL: AbstractCrudWithLog<Sistema>
    {
        public string CreateHtmlMenu()
        {
       

            if (ObjEF.id_sistema == 0)
                return String.Empty;
            StringBuilder menu = new StringBuilder();            
            menu.Append("<ul>");
            //menu.Append("<li class=\"current_page_item\"><a href=\"Home.aspx\">PHI ACADEMIA</a></li>");
            foreach (Menu mn in ObjEF.Menus.OrderBy(t=>t.ordem))
            {
                //abre o menu
                menu.Append(String.Format("<li><a href=\"#\" title=\"{0}\" >{1}</a>",
                mn.descricao, mn.nome));
                if (mn.MenuPaginas.Count > 0)
                {
                    //abre a pagina
                    menu.Append("<ul>");
                    foreach (MenuPagina mpg in mn.MenuPaginas.OrderBy(y=>y.ordem))
                        menu.Append(String.Format("<li><a href=\"../../{0}\" title=\"{1}\">{1}</a></li>", mpg.Pagina.url, mpg.Pagina.nome));
                    //fecha pagina
                    menu.Append("</ul>");
                }
                //fecha menu
                menu.Append("</li>");
            }
            menu.Append("</ul>");
            return menu.ToString();
        }

    

        public string ResponseUrl(Int32 intId_Sistema)
        {
            Get(intId_Sistema);
            return string.Format("{0}/{1}","~",ObjEF.Pagina.url);
        }
    }
}
