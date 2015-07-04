using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InnerSoft.MeEncontre.Application.ServiceImplementation;
using InnerSoft.MeEncontre.Domain.Model;
using MeEncontre.Infrastructure.Repository;
using MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.Web.API.Controllers
{
    public class AcessoController : ApiController
    {

        protected ClienteService _ClienteService;
        public AcessoController()
        {
            _ClienteService = new ClienteService(new ClienteRepository(new MeEncontreEntities()));

        }
        
        // GET api/acesso/5
        // http://localhost:21842/api/acesso/INNER/0001/chave
        public string Get(string ChaveCliente, string ChaveLocal, string ChaveColaborador)
        {          
            return _ClienteService.RegistraAcesso(ChaveCliente, ChaveLocal, ChaveColaborador);            
        }              

        protected override void Dispose(bool disposing)
        {
            _ClienteService.Dispose();
            base.Dispose(disposing);
        }
    }
}
