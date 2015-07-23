using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medusa.DAL;
using System.IO;

namespace Medusa.BLL
{
    public class ContratoBLL : AbstractCrudWithLog<Contrato>
    {
        public override void Add()
        {
            ObjEF.termino = ObjEF.inicio.AddMonths(_dbContext.Planos.First(it => it.id_plano == ObjEF.id_plano).meses);
            ObjEF.id_usuario = SecurityBLL.GetCurrentId_usuario();
            base.Add();
        }
        public override void Update()
        {
            ObjEF.id_usuario = SecurityBLL.GetCurrentId_usuario();
            base.Update();
        }

       

        public bool GerarPagamentos(int num_parcelas, DateTime dtInicio)
        {
            var valorMensal = ObjEF.Total / num_parcelas;
            for (int i = 0; i < num_parcelas; i++)
            {
                var pagto = new Pagamento()
                {                    
                    data_vencto = dtInicio,
                    valor = valorMensal,
                    id_usuario_lancto = SecurityBLL.GetCurrentId_usuario(),
                };
                ObjEF.Pagamentos.Add(pagto);
                dtInicio = dtInicio.AddMonths(1);
            }
            return SaveChanges();
        }
    }
}
