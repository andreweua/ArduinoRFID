using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Domain.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnerSoft.MeEncontre.InfraStructure.Mapping
{

    public partial class ColaboradorMap : EntityTypeConfiguration<Colaborador>
    {
        public ColaboradorMap()
        {
            this.ToTable("Colaborador");
            this.HasKey(o => o.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasMany(x => x.Acessos).WithRequired(x => x.Colaborador);
            this.HasMany(x => x.PermissaoLocalColaboradores).WithRequired(x => x.Colaborador);

        }
    }
}
