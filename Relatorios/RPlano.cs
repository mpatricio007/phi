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
    public class RPlano
    {
        public string plano { get; set; }

        public int qtdade { get; set; }

        public decimal totalPago { get; set; }
        
        public List<RPlano> GetAll(DateTime de, DateTime ate)
        {
           var ctx = new Contexto();
            var ds = from p in ctx.Pagamentos
                where p.data_pagto >= de && p.data_pagto <= ate
                group p by p.Contrato.Plano
                into g
                select new RPlano()
                {
                    plano = g.Key.nome,
                    qtdade = g.Count(),
                    totalPago = g.Sum(k => k.valor)
                };

            return ds.OrderBy(k => k.plano).ToList();
        }
    }
}