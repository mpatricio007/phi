using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Banco
    {
        [Key]
        public int id_banco { get; set; }

        [Required]
        [MaxLength(3)]
        public string codigo { get; set; }

        [Required]
        [MaxLength(30)]
        public string nome { get; set; }
    }


    public class BancoConfiguration : EntityTypeConfiguration<Banco>
    {
        public BancoConfiguration()
        {            
            ToTable("Banco");
        }
    }
}