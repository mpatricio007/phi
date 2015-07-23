using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Plano
    {
        [Key]
        public int id_plano { get; set; }

        [Required]
        [MaxLength(100)]
        public string nome { get; set; }


        public decimal valor { get; set; }

        [Required]
        [MaxLength(100)]
        public string descricao { get; set; }

        public int meses { get; set; }

        public int acessos { get; set; }

        public int tolerancia { get; set; }

        public TimeSpan inicio { get; set; }

        public TimeSpan termino { get; set; }

        public bool status { get; set; }
        
        [NotMapped]
        public decimal total
        {
            get { return valor * meses; }
            
        }

        public int id_modalidade { get; set; }

        [ForeignKey("id_modalidade")]
        public virtual Modalidade Modalidade { get; set; }
        
    }

    public class PlanoConfiguration : EntityTypeConfiguration<Plano>
    {
        public PlanoConfiguration()
        {            
            ToTable("Plano");
        }
    }
}