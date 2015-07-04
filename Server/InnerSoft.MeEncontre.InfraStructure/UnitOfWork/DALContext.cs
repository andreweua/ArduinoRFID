using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Domain.Model;
using MeEncontre.Infrastructure.Repository;
using MeEncontre.Domain.Model;

namespace MeEncontre.Infrastructure.UnitOfWork
{
    public class DALContext : IDALContext
    {
        private MeEncontreEntities dbContext;
        private IClienteRepository clientes;
        private IAcessoRepository acessos;
        private ILocalRepository locais;
        private IPermissaoLocalColaboradorRepository permissaoLocalColaboradores;
        private IStatusRepository status;
        private IColaboradorRepository colaboradors;
       

        public DALContext()
        {
            dbContext = new MeEncontreEntities();
        }
        public IClienteRepository Clientes
        {
            get
            {
                if (clientes == null)
                    clientes = new ClienteRepository(dbContext);
                return clientes;
            }
        }

        public IAcessoRepository Acessos
        {
            get
            {
                if (acessos == null)
                    acessos = new AcessoRepository(dbContext);
                return acessos;
            }
        }


        public ILocalRepository Locais
        {
            get
            {
                if (locais == null)
                    locais = new LocalRepository(dbContext);
                return locais;
            }
        }

        public IPermissaoLocalColaboradorRepository PermissaoLocalColaboradores
        {
            get
            {
                if (permissaoLocalColaboradores == null)
                    permissaoLocalColaboradores = new PermissaoLocalColaboradorRepository(dbContext);
                return permissaoLocalColaboradores;
            }
        }

        public IStatusRepository Status
        {
            get
            {
                if (status == null)
                    status = new StatusRepository(dbContext);
                return status;
            }
        }

        public IColaboradorRepository Colaboradors
        {
            get
            {
                if (colaboradors == null)
                    colaboradors = new ColaboradorRepository(dbContext);
                return colaboradors;
            }
        }

      
        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (clientes != null)
                clientes.Dispose();

            if (acessos != null)
                acessos.Dispose();

            if (locais!= null)
                locais.Dispose();

            if (permissaoLocalColaboradores != null)
                permissaoLocalColaboradores.Dispose();
           
            if (colaboradors != null)
                colaboradors.Dispose();

            if (status != null)
                status.Dispose();


            GC.SuppressFinalize(this);
        }
    }
}

