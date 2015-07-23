using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Pessoa
    {
        [Key]
        public int id_pessoa { get; set; }

        [Required]
        [MaxLength(100)]
        public string nome { get; set; }

        [MaxLength(1)]
        public string sexo { get; set; }

        public DateTime? dtNascto { get; set; }

        private Email Email;

        public Email email
        {
            get 
            {
                if (Email == null)
                    Email = new Email();
                return Email; 
            }
            set { Email = value; }
        }       
        
    }

    public class PessoaFisicaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaFisicaConfiguration()
        {        
            ToTable("Pessoa");
        }
    }
}