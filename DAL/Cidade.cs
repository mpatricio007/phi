using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
  

    public class Cidade
    {
        [Key]
        [MaxLength(50)]
        public string cidade { get; set; }

        [MaxLength(2)]
        public string uf { get; set; }
    }


    public class CidadeConfiguration : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfiguration()
        {
            ToTable("vCidade");
        }
    }
}