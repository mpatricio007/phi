using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medusa.BLL;
using Medusa.DAL;

namespace Medusa.Relatorios
{
    public class RCliente
    {
        public string plano { get; set; }

        public string cliente { get; set; }

        public string telefones { get; set; }

        public string status { get; set; }

        public string modalidade { get; set; }

        public RCliente()
        {

        }

        public RCliente(Contrato c)
        {
            var sc = new StatusContrato(c);
            cliente = c.Cliente.nome;
            telefones = string.Format("{0} {1} {2}", c.Cliente.telefone.value, c.Cliente.celular.value, c.Cliente.comercial.value);
            plano = sc.plano;
            status = sc.status.ToString();
            modalidade = c.Plano.Modalidade.nome;
        }

        public List<RCliente> GetAll(StatusFrequencia status, int id_plano = 0)
        {
            var cBLL = new ContratoBLL();
            var ds = id_plano == 0 ? cBLL.Find(it => it.status == true) : cBLL.Find(it => it.id_plano == id_plano & it.status == true);

            var dsContratos = (from c in ds
                     group c by c.id_cliente
                         into g
                         select new
                             {
                                 id_cliente = g.Key,
                                 contrato = g.OrderByDescending(it => it.termino).FirstOrDefault()
                             }).Select(it => it.contrato);


            var lst = dsContratos.OrderBy(it => it.Cliente.nome).Select(item => new RCliente(item)).ToList();

            var strStatus = Enum.GetName(typeof(StatusFrequencia),status);
            return lst.Where(it => it.status == strStatus).ToList();
        }


        public List<RCliente> GetAllModalidade(StatusFrequencia status, int id_modalidade = 0)
        {
            var cBLL = new ContratoBLL();
            var ds = id_modalidade == 0 ? cBLL.Find(it => it.status == true) : cBLL.Find(it => it.Plano.id_modalidade == id_modalidade & it.status == true);
            var dsContratos = (from c in ds
                               group c by c.id_cliente
                                   into g
                                   select new
                                   {
                                       id_cliente = g.Key,
                                       contrato = g.OrderByDescending(it => it.termino).FirstOrDefault()
                                   }).Select(it => it.contrato);


            var lst = dsContratos.OrderBy(it => it.Cliente.nome).Select(item => new RCliente(item)).ToList();

            var strStatus = Enum.GetName(typeof(StatusFrequencia), status);
            return lst.Where(it => it.status == strStatus).Distinct().ToList();
        }
    }

    
}