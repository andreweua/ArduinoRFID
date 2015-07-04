using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using InnerSoft.MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.InfraStructure.Mapping
{
    public partial class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            this.ToTable("Cliente");
            this.HasKey(o => o.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasMany(x => x.Locais).WithRequired(x => x.Cliente);
            this.HasMany(x => x.Colaboradores).WithRequired(x => x.Cliente);
                    
        }    
    }
}
