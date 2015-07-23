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
    public partial class RClientesModalidade : System.Web.UI.Page
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
                this.cDdlModalidades1.Id_modalidade != 0 ? String.Format("da modalidade {0}",this.cDdlModalidades1.Text) : ""));
            
            rvClientes.LocalReport.SetParameters(parameters);
            var rel = new RCliente();
            ReportDataSource rpd = new ReportDataSource("dsClientes", rel.GetAllModalidade((StatusFrequencia)Enum.Parse(typeof(StatusFrequencia), rdAtivos.SelectedValue), this.cDdlModalidades1.Id_modalidade));
            rvClientes.LocalReport.DataSources.Add(rpd);
            rvClientes.LocalReport.Refresh();
        }




    }
}