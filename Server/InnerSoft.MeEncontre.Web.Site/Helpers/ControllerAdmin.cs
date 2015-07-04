using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnerSoft.MeEncontre.Application.ServiceImplementation;
using InnerSoft.MeEncontre.Domain.Model;

namespace InnerSoft.MeEncontre.Web.Site.Helpers
{
    public class ControllerAdmin : Controller
    {
        protected ClienteService _ClienteService;
        protected StatusService _StatusService;

        public ControllerAdmin(ClienteService clienteService)
        {
            _ClienteService = clienteService;
        }
		
		public ControllerAdmin(ClienteService clienteService, StatusService statusService)
        {
            _ClienteService = clienteService;
            _StatusService = statusService;
        }

        protected Status StatusAtivo()
        {
            return _StatusService.FindByCodigo("A");
        }

        protected string GenerateGuid()
        {
            return Guid.NewGuid().ToString();

        }

        protected Cliente ClienteSelecionado()
        {
            var cliente = _ClienteService.All().Where(a => a.Codigo == SiteHelper.ClienteDemo()).FirstOrDefault();
            return cliente;
        }


        protected override void Dispose(bool disposing)
        {
            _ClienteService.Dispose();
            base.Dispose(disposing);
        }


    }
}