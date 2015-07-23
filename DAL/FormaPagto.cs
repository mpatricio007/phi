using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class FormaPagto
    {
        [Key]
        public int id_forma { get; set; }

        [Required]
        [MaxLength(50)]
        public string nome { get; set; }

        public bool requer_num { get; set; }
    }

    public class FormaPagtoConfiguration : EntityTypeConfiguration<FormaPagto>
    {
        public FormaPagtoConfiguration()
        {
            ToTable("FormaPagto");
        }
    }
}