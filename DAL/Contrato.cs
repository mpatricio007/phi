using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Contrato
    {
        [Key]
        public int id_contrato { get; set; }

        public int id_plano { get; set; }

        [ForeignKey("id_plano")]
        public virtual Plano Plano { get; set; }

        public int id_cliente { get; set; }

        [ForeignKey("id_cliente")]
        public virtual Cliente Cliente { get; set; }

        public DateTime inicio { get; set; }

        public DateTime termino { get; set; }
        
        public string obs { get; set; }

        public bool status { get; set; }

        public decimal? desconto_per { get; set; }

        public decimal? desconto_valor { get; set; }

        [NotMapped]
        public decimal Total
        {
            get 
            {
                return Plano.total * (1 - desconto_per.GetValueOrDefault()/100) - desconto_valor.GetValueOrDefault();
            }
            
        }

        public int id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }

    public class ContratoConfiguration : EntityTypeConfiguration<Contrato>
    {
        public ContratoConfiguration()
        {
            
            ToTable("Contrato");
        }
    }
}