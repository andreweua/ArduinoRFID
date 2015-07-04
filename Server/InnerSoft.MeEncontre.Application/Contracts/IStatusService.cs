using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.Application.Contracts
{
    public interface IStatusService
    {
        IEnumerable<Status> All();

        Status Find(int Id);

        Status FindByCodigo(string Codigo);

        Status Create(Status Status);

        int Update(Status Status);

        int Delete(int Id);

    }
}
