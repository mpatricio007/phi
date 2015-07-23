using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class MenuPagina
    {
        [Key]
        public int id_menu_paginas { get; set; }

        [Required]        
        public int id_menu { get; set; }

        [ForeignKey("id_menu")]
        public virtual Menu Menu { get; set; }

        [Required]        
        public int id_pagina { get; set; }

        [ForeignKey("id_pagina")]
        public virtual Pagina Pagina { get; set; }

        [Required]        
        public bool leitura { get; set; }

        [Required]        
        public bool gravacao { get; set; }

        public int ?ordem { get; set; }
    }

    public class MenuPaginaConfiguration : EntityTypeConfiguration<MenuPagina>
    {
        public MenuPaginaConfiguration()
        {
            ToTable("MenuPaginas");
        }
    }
}