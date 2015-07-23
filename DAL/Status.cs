using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Medusa.DAL
{
    public class Status
    {
        [Key]
        public int id_status { get; set; }


        [Required]
        [MaxLength(50)]
        public string nome { get; set; }
    }

    public class StatusConfiguration : EntityTypeConfiguration<Status>
    {
        public StatusConfiguration()
        {            
            ToTable("Status");
        }
    }
}