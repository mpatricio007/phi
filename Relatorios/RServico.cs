using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Configuration;
using Medusa.BLL;
using Medusa.DAL;

namespace Medusa.Relatorios
{
    public class RServico
    {
        public string servico { get; set; }

        public int qtdade { get; set; }

        public decimal totalPago { get; set; }
        
        public List<RServico> GetAll(DateTime de, DateTime ate)
        {
           var ctx = new Contexto();
            var ds = from p in ctx.ServicoClientes
                where p.data >= de && p.data <= ate
                group p by p.Servico
                into g
                select new RServico()
                {
                    servico = g.Key.descricao,
                    qtdade = g.Count(),
                    totalPago = g.Sum(k => (decimal)k.total)
                };

            return ds.OrderBy(k => k.servico).ToList();
        }
    }
}