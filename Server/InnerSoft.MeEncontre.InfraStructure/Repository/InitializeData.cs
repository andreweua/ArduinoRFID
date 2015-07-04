using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InnerSoft.MeEncontre.Domain.Model;
using MeEncontre.Domain.Model;

namespace DiarioEscolar.Models
{
    public class InitializeData : DropCreateDatabaseIfModelChanges<MeEncontreEntities>
    {
        protected override void Seed(MeEncontreEntities context)
        {
            //var tipoClientes = new List<TipoCliente>
            //{
            //    new TipoCliente {Descricao= "Agua Doce"},
            //    new TipoCliente {Descricao= "Plantado"},
            //    new TipoCliente {Descricao= "Marinho"},
            //    new TipoCliente {Descricao= "Quarentena"},
            //    new TipoCliente {Descricao= "Hospital"},
            //    new TipoCliente {Descricao= "Criação"},
            //    new TipoCliente {Descricao= "Desenvolvimento"}                
            //};

          //  tipoClientes.ForEach(t => context.TipoClientes.Add(t));
        }            
    }
}