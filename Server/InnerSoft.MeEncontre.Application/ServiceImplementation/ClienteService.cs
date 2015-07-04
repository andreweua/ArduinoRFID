using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Application.Contracts;
using InnerSoft.MeEncontre.Domain.Model;
using MeEncontre.Infrastructure.UnitOfWork;
using MeEncontre.Infrastructure.Repository;

namespace InnerSoft.MeEncontre.Application.ServiceImplementation
{
    public class ClienteService : IClienteService, IDisposable
    {

        private IClienteRepository _ClienteRepository;
        public ClienteService(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }

        //public ClienteService()
        //{
        //    _ClienteRepository = new ClienteRepository();
        //}

        public IEnumerable<Cliente> All()
        {
            return _ClienteRepository.All();
        }

        public Cliente Find(int Id)
        {
            return _ClienteRepository.Find(Id);
        }

        public Cliente Create(Cliente cliente)
        {
            var ret = _ClienteRepository.Create(cliente);
            _ClienteRepository.SaveChanges();
            return ret;
        }

        public int Update(Cliente cliente)
        {
            var ret = _ClienteRepository.Update(cliente);
            _ClienteRepository.SaveChanges();
            return ret;

        }

        public int Delete(int Id)
        {
            var cliente = this.Find(Id);
            if (cliente != null)
            {
                var ret = _ClienteRepository.Update(cliente);
                _ClienteRepository.SaveChanges();
                return ret;
            }
            else
                return 0;
        }
      

        public Cliente FindByCodigo(string Codigo)
        {
            return _ClienteRepository.Filter(a => a.Codigo.Equals(Codigo)).First();
        }

        public void Dispose()
        {
            if (_ClienteRepository != null)
                _ClienteRepository.Dispose();
        }

        public string RegistraAcesso(string ChaveCliente, string ChaveLocal, string ChaveColaborador)
        {
            string retorno = "|X                   |";

            var cliente = ClienteAcesso(ChaveCliente);
            if (cliente == null)
                return retorno;

            var local = LocalAcesso(cliente, ChaveLocal);
            if (local == null)
                return retorno;

            var colaborador = ColaboradorAcesso(cliente, ChaveColaborador);
            if (colaborador == null)
                return retorno;
            
            var ultimoAcesso = cliente.Acessos.Where(a => a.Colaborador.Id == colaborador.Id
                                                     && a.Local.Id == local.Id)
                                                     .OrderByDescending(a => a.Data).Take(1).SingleOrDefault();
            
            Acesso acesso = new Acesso();
            acesso.Cliente = cliente;
            acesso.Colaborador = colaborador;
            acesso.Local = local;
            acesso.Data = DateTime.Now;
            acesso.AtualizaUltimoMovimento(ultimoAcesso);

            cliente.Acessos.Add(acesso);
            this.Update(cliente);

            return acesso.RetornaAcesso();
        }

        protected Cliente ClienteAcesso(string codigocliente)
        {
            var cliente = this.All().Where(a => a.Codigo == codigocliente).FirstOrDefault();
            return cliente;
        }

        private Colaborador ColaboradorAcesso(Cliente cliente, string colaboradorKey)
        {
            return cliente.Colaboradores.Where(a => a.Key == colaboradorKey).FirstOrDefault();
        }

        private Local LocalAcesso(Cliente cliente, string localKey)
        {
            return cliente.Locais.Where(a => a.Key == localKey).FirstOrDefault();
        }   

    }
}
