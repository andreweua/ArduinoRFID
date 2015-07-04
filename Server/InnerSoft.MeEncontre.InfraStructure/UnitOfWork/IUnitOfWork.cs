using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeEncontre.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
