using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Servico
    {
        [Key]
        public int id_servico { get; set; }

        [Required]
        [MaxLength(100)]
        public string descricao { get; set; }

              
        public decimal valor { get; set; }
    }

    public class ServicoConfiguration : EntityTypeConfiguration<Servico>
    {
        public ServicoConfiguration()
        {
            ToTable("Servico");
        }
    }
}