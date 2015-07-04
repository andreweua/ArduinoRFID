using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnerSoft.MeEncontre.Application.ServiceImplementation;
using InnerSoft.MeEncontre.Domain.Model;
using AutoMapper;
using InnerSoft.MeEncontre.Web.Site.ViewModel;
using InnerSoft.MeEncontre.Web.Site.Helpers;
using System.Net.Http;
using System.Net;

namespace InnerSoft.MeEncontre.Web.Site.Controllers
{
    public class DashBoardController : ControllerAdmin
    {
        public DashBoardController(ClienteService clienteService)
            : base(clienteService)
        {



        }

        //
        // GET: /DashBoard/
        public ActionResult Index()
        {
            return View();
        }

        private List<ColaboradorLocalizacaoViewModel> ColaboradoresAtivos()
        {
            //var colaboradores = ClienteSelecionado().Colaboradores.Where(a => a.Status.Codigo == "A").ToList();
            var colaboradores = ClienteSelecionado().Colaboradores.ToList();

            var retorno = new List<ColaboradorLocalizacaoViewModel>();
            foreach (Colaborador colaborador in colaboradores)
            {

                var acesso = ClienteSelecionado().Acessos.Where(a => a.Colaborador.Id == colaborador.Id
                    //&& a.Movimento == "E"
                                                        && a.Data.ToShortDateString() == DateTime.Now.ToShortDateString()
                                                        ).OrderByDescending(o => o.Data).FirstOrDefault();

                if (acesso != null && acesso.Movimento == "E")
                {

                    retorno.Add(BindAcesso(acesso, colaborador));

                }
            }
            return retorno;

        }

        public ActionResult GetMapaAcessos()
        {
            var retorno = ColaboradoresAtivos();
            return Json(retorno, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult GetColaboradoresAtivos()
        {
            var retorno = ColaboradoresAtivos();
            return Json(retorno, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult GetPercentualColaboradoresAcesso()
        {
            var acesso = ColaboradoresAtivos().Count();
            //var total = ClienteSelecionado().Colaboradores.Where(a => a.Status.Codigo == "A").Count();
            var total = ClienteSelecionado().Colaboradores.Count();
            var naoacesso = total - acesso;

            var retorno = new PercentualColaboradoresViewModel();
            retorno.Acesso = acesso;
            retorno.Total = total;
            retorno.NaoAcesso = naoacesso;

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUltimosAcessos()
        {
            var retorno = ClienteSelecionado().Acessos
                .Select(a => new AcessoViewModel(a))
                .OrderByDescending(a => a.Data).Take(20).ToList();

            return Json(retorno, JsonRequestBehavior.AllowGet);

        }



        private ColaboradorLocalizacaoViewModel BindAcesso(Acesso acesso, Colaborador colaborador)
        {
            ColaboradorLocalizacaoViewModel r = new ColaboradorLocalizacaoViewModel();
            r.Nome = colaborador.Nome;
            r.Documento = colaborador.Documento;
            r.Email = colaborador.Email;
            r.Foto = colaborador.Foto;

            r.Data = acesso.Data;
            r.Local = acesso.Local.Nome;
            r.Latitude = acesso.Local.Latitude;
            r.Longitude = acesso.Local.Longitude;
            r.Movimento = acesso.Movimento;

            return r;
        }
    }
}

