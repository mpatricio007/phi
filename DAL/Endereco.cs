using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.DAL
{
    [ComplexType]
    [Serializable]
    public class Endereco
    {
        [MaxLength(50)]
        [Required]
        public string logradouro { get; set; }

        [MaxLength(10)]
        [Required]        
        public string numero { get; set; }

        [MaxLength(50)]
        public string complemento { get; set; }

        [MaxLength(30)]
        [Required]
        public string bairro { get; set; }

        [MaxLength(50)]
        [Required]
        public string cidade { get; set; }

        [MaxLength(2)]
        [Required]
        public string uf { get; set; }

        [MaxLength(9)]
        [Required]
        public string cep { get; set; }
    

        public override string ToString()
        {   
            return String.Format("{0},{1} {2} {3}-{4}  CEP:{5}",
                logradouro,
                numero,
                complemento,
                cidade,
                uf,                              
                cep);
        }
    }    
}

  