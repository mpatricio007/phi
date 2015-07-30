using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class ServicoCliente
    {
        [Key]
        public int id_servico_cliente { get; set; }

        public int id_servico { get; set; }

        [ForeignKey("id_servico")]
        public virtual Servico Servico { get; set; }

        public int id_cliente { get; set; }

        [ForeignKey("id_cliente")]
        public virtual Cliente Cliente { get; set; }

        public DateTime data { get; set; }        

        public string obs { get; set; }        

        public decimal? desconto_per { get; set; }

        public decimal? desconto_valor { get; set; }

        public DateTime? data_termino { get; set; }    

        public decimal? total { get; set; }
        //{
        //    get
        //    {
        //        return Servico.valor * (1 - desconto_per.GetValueOrDefault() / 100) - desconto_valor.GetValueOrDefault();
        //    }

        //}
    }

    public class ServicoClienteConfiguration : EntityTypeConfiguration<ServicoCliente>
    {
        public ServicoClienteConfiguration()
        {
            ToTable("ServicoCliente");
        }
    }
}