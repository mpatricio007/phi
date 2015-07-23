using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Modalidade
    {
        [Key]
        public int id_modalidade { get; set; }

        [Required]
        [MaxLength(50)]
        public string nome { get; set; }


       
        
    }

    public class ModalidadeConfiguration : EntityTypeConfiguration<Modalidade>
    {
        public ModalidadeConfiguration()
        {
            ToTable("Modalidade");
        }
    }
}