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
using Microsoft.Reporting.WebForms;

namespace Medusa.Relatorios
{
    public partial class RFinPlano : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rvClientes.Visible = false;
            }
        }

        protected void btGerarRelatorios_Click(object sender, EventArgs e)
        {
            rvClientes.Visible = true;
            rvClientes.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("filtros",
                String.Format(" de {0:d} até {1:d}", cDataDe.Value, cDataAte.Value));
                
            
            rvClientes.LocalReport.SetParameters(parameters);
            var rel = new RPlano();
            var rpd = new ReportDataSource("dsPlanos",
                rel.GetAll(cDataDe.Value.GetValueOrDefault(), cDataAte.Value.GetValueOrDefault()));
            rvClientes.LocalReport.DataSources.Add(rpd);
            rvClientes.LocalReport.Refresh();
        }




    }
}