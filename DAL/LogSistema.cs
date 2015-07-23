using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class LogSistema
    {
        [Key]
        public int id_log { get; set; }
                
        [MaxLength(20)]
        public string acao { get; set; }
        
        [MaxLength(20)]
        public string entidade { get; set; }

        [MaxLength(20)]
        public string ip { get; set; }
                
        public int id_pessoa { get; set; }

        [ForeignKey("id_pessoa")]
        public virtual Usuario Usuario { get; set; }

        public DateTime? data { get; set; }

        public int? id_entidade { get; set; }

        public string descricao { get; set; }

    }

    public class LogSistemaConfiguration : EntityTypeConfiguration<LogSistema>
    {
        public LogSistemaConfiguration()
        {
            HasRequired(l => l.Usuario).WithMany(u => u.LogSistema).HasForeignKey(l => l.id_pessoa);
            ToTable("LogSistemas");
        }
    }
}