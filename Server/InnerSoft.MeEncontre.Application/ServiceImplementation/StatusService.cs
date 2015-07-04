using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnerSoft.MeEncontre.Application.Contracts;
using InnerSoft.MeEncontre.Domain.Model;
using MeEncontre.Infrastructure.UnitOfWork;

namespace InnerSoft.MeEncontre.Application.ServiceImplementation
{
    public class StatusService : IStatusService, IDisposable
    {
        private IDALContext _Dbcontext;
        public StatusService(IDALContext dbContext)
        {
            _Dbcontext = dbContext;
        }

        public StatusService()
        {
            _Dbcontext = new DALContext();
        }

        public IEnumerable<Status> All()
        {
            return _Dbcontext.Status.All();
        }

        public Status Find(int Id)
        {
            return _Dbcontext.Status.Find(Id);
        }

        public Status Create(Status Status)
        {
            var ret = _Dbcontext.Status.Create(Status);
            _Dbcontext.SaveChanges();

            return ret;
        }

        public int Update(Status Status)
        {
            _Dbcontext.Status.Update(Status);
            return _Dbcontext.SaveChanges();

        }

        public int Delete(int Id)
        {
            Status Status = _Dbcontext.Status.Find(Id);
            _Dbcontext.Status.Delete(Status);
            return _Dbcontext.SaveChanges();
        }


        public Status FindByCodigo(string Codigo)
        {
            return _Dbcontext.Status.Filter(a => a.Codigo.Equals(Codigo)).First();
        }

        public void Dispose()
        {
            if (_Dbcontext != null)
                _Dbcontext.Dispose();
        }

    }
}
