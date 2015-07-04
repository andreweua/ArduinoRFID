using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeEncontre.Infrastructure.Repository;

namespace MeEncontre.Infrastructure.UnitOfWork
{
    public interface IDALContext : IUnitOfWork
    {
        IClienteRepository Clientes { get; }

        IAcessoRepository Acessos { get; }

        IColaboradorRepository Colaboradors { get; }

        IPermissaoLocalColaboradorRepository PermissaoLocalColaboradores { get; }

        ILocalRepository Locais { get; }

        IStatusRepository Status { get; }
        

    }
}
