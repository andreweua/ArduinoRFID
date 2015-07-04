using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using InnerSoft.MeEncontre.InfraStructure.Mapping;

namespace MeEncontre.Domain.Model
{
    public class MeEncontreEntities : DbContext
    {

        public MeEncontreEntities()            
        {
            
        }

        //public MeEncontreEntities(string connectionString)
        //    : base(connectionString)
        //{
        //    if (this.Database.Exists() &&
        //    !this.Database.CompatibleWithModel(false))
        //        this.Database.Delete();
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);


            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new AcessoMap());
            modelBuilder.Configurations.Add(new LocalMap());
            modelBuilder.Configurations.Add(new PermissaoLocalColaboradorMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new ColaboradorMap());
          
        }

    }

    //public class InitializeData : DropCreateDatabaseIfModelChanges<MeEncontreEntities>
    //{
    //    protected override void Seed(MeEncontreEntities context)
    //    {
    //        var tiposCliente = new List<TipoCliente> { 
    //            new TipoCliente{Descricao = "Plantado"},
    //            new TipoCliente{Descricao = "Marinho"},
    //            new TipoCliente{Descricao = "Quarentena"}                       
    //        };

    //        tiposCliente.ForEach(t => context.Tipo.Add(t));
        
    //        //var tipoNotas = new List<TipoNota>
    //        //{
    //        //    new TipoNota {Ordem = 1, Descricao= "1 Bimestre"},
    //        //    new TipoNota {Ordem = 2, Descricao= "2 Bimestre"},
    //        //    new TipoNota {Ordem = 3, Descricao= "3 Bimestre"},
    //        //    new TipoNota {Ordem = 4, Descricao= "4 Bimestre"},
    //        //    new TipoNota {Ordem = 5, Descricao= "Recuperação"},
    //        //    new TipoNota {Ordem = 6, Descricao= "Média Final"}
    //        //};

    //        //tipoNotas.ForEach(t => context.TipoNotas.Add(t));
    //    }
    //}
}

