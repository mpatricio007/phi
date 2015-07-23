using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.DAL
{

    [ComplexType]
    [Serializable]
    public class Telefone
    {        
        [MaxLength(20)]
        public string value { get; set; }

        public Telefone()
        {

        }


        public Telefone(string strValue)
        {
            value = strValue;           
        }
    }
}