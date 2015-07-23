using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Pagamento
    {
        [Key]
        public int id_pagamento { get; set; }

        public int id_contrato { get; set; }

        [ForeignKey("id_contrato")]
        public virtual Contrato Contrato { get; set; }
        
        public DateTime data_vencto { get; set; }

        public decimal valor { get; set; }

        public int id_usuario_lancto { get; set; }

        [ForeignKey("id_usuario_lancto")]
        public virtual Usuario UsuarioLancto { get; set; }

        public DateTime? data_pagto { get; set; }

        public int? id_usuario_baixa { get; set; }

        [ForeignKey("id_usuario_baixa")]
        public virtual Usuario UsuarioBaixa { get; set; }

        public int? id_forma { get; set; }

        [ForeignKey("id_forma")]
        public virtual FormaPagto FormaPagto { get; set; }
        
        public string num { get; set; }       
    }

    public class PagamentoConfiguration : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoConfiguration()
        {
            ToTable("Pagamento");
        }
    }
}