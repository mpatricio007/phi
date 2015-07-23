using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;

namespace Medusa.DAL
{
    public class Cep
    {
        [Key]
        public int id_cep { get; set; }

        public string uf { get; set; }

        public string cidade { get; set; }

        public string logradouro { get; set; }

        public string bairro { get; set; }

        public string BAI_FIM { get; set; }

        public string cep { get; set; }

        public string complemento { get; set; }

        public string tipoLOGRADOURO { get; set; }

        public string pais { get; set; }
    }
    

    public class CepConfiguration : EntityTypeConfiguration<Cep>
    {
        public CepConfiguration()
        {
            ToTable("Cep");
        }
    }
}