using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Domain.Model;
using MeEncontre.Domain.Model;

namespace MeEncontre.Infrastructure.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(MeEncontreEntities context)
            : base(context)
        {
         
        }
    }
}
