using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{    
    public class Usuario : Pessoa
    {
        [Required]
        [MaxLength(50)]
        public string login { get; set; }

        [Required]
        [MaxLength(50)]
        public string senha { get; set; }

        public int nivel { get; set; }

        public int id_sistema { get; set; }

        [ForeignKey("id_sistema")]
        public virtual Sistema Sistema { get; set; }

        public virtual ICollection<LogSistema> LogSistema { get; set; }

        
    }

    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {            
            ToTable("Usuario");
        }
    }
}