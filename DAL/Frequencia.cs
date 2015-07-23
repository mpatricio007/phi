using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public enum StatusFrequencia
    {
        LIBERAR = 0,
        AVISAR = 1,
        BLOQUEAR = 2,
        TERMINADO = 3
    }

    public class Frequencia
    {
        [Key]
        public int id_frequencia { get; set; }

        public DateTime data { get; set; }       

        public int id_cliente { get; set; }

        [ForeignKey("id_cliente")]
        public virtual Cliente Cliente { get; set; }

        public int id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public virtual Usuario Usuario { get; set; }

        public StatusFrequencia StatusFrequencia { get; set; }

        public string obs { get; set; }
    }

    public class FrequenciaConfiguration : EntityTypeConfiguration<Frequencia>
    {
        public FrequenciaConfiguration()
        {
            ToTable("Frequencia");
        }
    }
}