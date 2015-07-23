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
    public partial class RelatorioClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rvClientes.Visible = false;

                rdAtivos.DataSource = Enum.GetNames(typeof(StatusFrequencia));
                rdAtivos.DataBind();
            }
        }

        protected void btGerarRelatorios_Click(object sender, EventArgs e)
        {
            rvClientes.Visible = true;
            rvClientes.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("filtros", String.Format( "Clientes {0} {1}", rdAtivos.SelectedItem.Text,
                this.cDdlPlano1.Id_plano != 0 ? String.Format("do plano {0}",this.cDdlPlano1.Text) : ""));
            
            rvClientes.LocalReport.SetParameters(parameters);
            var rel = new RCliente();
            ReportDataSource rpd = new ReportDataSource("dsClientes", rel.GetAll((StatusFrequencia)Enum.Parse(typeof(StatusFrequencia), rdAtivos.SelectedValue), this.cDdlPlano1.Id_plano));
            rvClientes.LocalReport.DataSources.Add(rpd);
            rvClientes.LocalReport.Refresh();
        }




    }
}