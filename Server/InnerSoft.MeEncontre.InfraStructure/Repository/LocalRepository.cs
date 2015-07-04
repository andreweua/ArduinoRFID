using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Domain.Model;
using MeEncontre.Domain.Model;

namespace MeEncontre.Infrastructure.Repository
{
    public class LocalRepository : Repository<Local>, ILocalRepository
    {
        public LocalRepository(MeEncontreEntities context)
            : base(context)
        {
         
        }
    }
}
