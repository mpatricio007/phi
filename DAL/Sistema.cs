using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Sistema
    {
        [Key]
        public int id_sistema { get; set; }

        [Required]
        [MaxLength(20)]
        public string sigla { get; set; }

        [Required]
        [MaxLength(50)]
        public string nome { get; set; }
                
              
        public int id_pagina { get; set; }

        [ForeignKey("id_pagina")]  
        public virtual Pagina Pagina { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

        public virtual ICollection<Usuario> Usuarios{ get; set; }
    }

    public class SistemaConfiguration : EntityTypeConfiguration<Sistema>
    {
        public SistemaConfiguration()
        {
            HasRequired(s => s.Pagina).WithMany(it => it.Sistema).HasForeignKey(s => s.id_pagina).WillCascadeOnDelete(false);
            ToTable("Sistema");
        }
    }
}