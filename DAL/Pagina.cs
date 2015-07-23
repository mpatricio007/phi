using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Pagina
    {
        [Key]
        public int id_pagina { get; set; }

        [Required]
        [MaxLength(100)]
        public string url { get; set; }

        [Required]
        [MaxLength(50)]
        public string nome { get; set; }

        public virtual ICollection<MenuPagina> MenuPaginas { get; set; }

        public virtual ICollection<Sistema> Sistema { get; set; }
    }

    public class PaginaConfiguration : EntityTypeConfiguration<Pagina>
    {
        public PaginaConfiguration()
        {
            ToTable("Pagina");
        }
    }
}