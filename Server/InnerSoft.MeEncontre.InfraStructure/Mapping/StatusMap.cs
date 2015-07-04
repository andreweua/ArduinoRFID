using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Domain.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnerSoft.MeEncontre.InfraStructure.Mapping
{

    public partial class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            this.ToTable("Status");
            this.HasKey(o => o.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
