using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.Application.Contracts
{
    public interface IClienteService
    {
        IEnumerable<Cliente> All();

        Cliente Find(int Id);

        Cliente FindByCodigo(string Codigo);

        Cliente Create(Cliente Cliente);

        int Update(Cliente Cliente);

        int Delete(int Id);

        string RegistraAcesso(string ChaveCliente, string ChaveLocal, string ChaveColaborador);

    }
}
