using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Cliente
    {
        [Key]
        public int id_cliente { get; set; }


        public int ra { get; set; }      

       

        [Required]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required]
        [MaxLength(1)]
        public string sexo { get; set; }

        public DateTime dtNascto { get; set; }

        public Email email { get; set; }

        public DateTime data_cadastro { get; set; }        

        public Endereco endereco { get; set; }

        public Telefone telefone { get; set; }

        public Telefone celular { get; set; }

        public Telefone comercial { get; set; }

        public Telefone tel_emergencia { get; set; }

        public string contato_emergencia { get; set; }

        public string responsavel { get; set; }

        public string cpf { get; set; }

        public string rg { get; set; }

        public string obs { get; set; }

        public bool vip { get; set; }

        public int id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public virtual Usuario Usuario { get; set; }

        public string foto { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<ServicoCliente> Servicos { get; set; }

        public virtual ICollection<Frequencia> Frequencias { get; set; }
    }

    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            
            ToTable("Cliente");
        }
    }
}