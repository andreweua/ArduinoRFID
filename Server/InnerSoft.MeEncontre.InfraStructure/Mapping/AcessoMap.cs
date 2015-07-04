using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using InnerSoft.MeEncontre.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;


namespace InnerSoft.MeEncontre.InfraStructure.Mapping
{
    public partial class AcessoMap : EntityTypeConfiguration<Acesso>
    {
        public AcessoMap()
        {
            this.ToTable("Acesso");
            this.HasKey(o => o.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            
            
        }
    }
}
