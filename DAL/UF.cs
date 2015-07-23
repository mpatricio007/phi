using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class UF
    {
        [Key]
        [MaxLength(2)]
        public string uf { get; set; }        
    }


    public class UFConfiguration : EntityTypeConfiguration<UF>
    {
        public UFConfiguration()
        {
            ToTable("vUF");
        }
    }
}