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

namespace InnerSoft.MeEncontre.Web.Site.Controllers
{

    public class AcessoController : ControllerAdmin
    {

        public AcessoController(ClienteService clienteService)
            : base(clienteService)
        {

        }

        private Acesso AcessoSelecionado(int Id)
        {
            return ClienteSelecionado().Acessos.Where(a => a.Id == Id).FirstOrDefault();
        }

        //
        // GET: /Acesso/
        public ActionResult Index()
        {
            var acessosViewModel = ClienteSelecionado().Acessos
                .Select(a => new AcessoViewModel(a))
                .OrderByDescending(a => a.Data).ToList();
                       

            return View(acessosViewModel);

        }
        //
        // GET: /Acesso/Details/5
        public ActionResult Details(int id)
        {

            Acesso Acesso = AcessoSelecionado(id);

            if (Acesso == null)
            {
                return HttpNotFound();
            }

            var AcessoViewModel = Mapper.Map<Acesso, AcessoViewModel>(Acesso);
            return View(AcessoViewModel);
        }

        //
        // GET: /Acesso/Create

        public ActionResult Create()
        {
            AcessoViewModel AcessoViewModel = new AcessoViewModel();
            return View(AcessoViewModel);
        }

        //
        // POST: /Acesso/Create
        [HttpPost]
        public ActionResult Create(AcessoViewModel AcessoViewModel)
        {
            var Acesso = new Acesso();
            Acesso = Mapper.Map<AcessoViewModel, Acesso>(AcessoViewModel);

            if (ModelState.IsValid)
            {
                var cliente = ClienteSelecionado();        
                cliente.Acessos.Add(Acesso);
                _ClienteService.Update(cliente);

                var rota = String.Format("/Acesso");
                return Redirect(rota);
            }

            return View(AcessoViewModel);
        }

        //
        // GET: /Acesso/Edit/5
        public ActionResult Edit(int id)
        {
            Acesso Acesso = AcessoSelecionado(id);
            if (Acesso == null)
            {
                return HttpNotFound();
            }
            var AcessoViewModel = Mapper.Map<Acesso, AcessoViewModel>(Acesso);
            return View(AcessoViewModel);
        }
        //
        // POST: /Acesso/Edit/5
        [HttpPost]
        public ActionResult Edit(AcessoViewModel AcessoViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = ClienteSelecionado();

                Acesso Acesso = cliente.Acessos.Where(a => a.Id == AcessoViewModel.Id).FirstOrDefault();

                if (Acesso == null)
                {
                    return HttpNotFound();
                }

                SetModel(Acesso, AcessoViewModel);

                _ClienteService.Update(cliente);

                var rota = String.Format("/Acesso");
                return Redirect(rota);

            }

            return View(AcessoViewModel);
        }

        private void SetModel(Acesso Acesso, AcessoViewModel AcessoViewModel)
        {
		
        }

        //
        // GET: /Acesso/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var cliente = ClienteSelecionado();

            Acesso Acesso = cliente.Acessos.Where(a => a.Id == id).FirstOrDefault();

            if (Acesso == null)
            {
                return HttpNotFound();
            }

            cliente.Acessos.Remove(Acesso);
            _ClienteService.Update(cliente);

            var rota = String.Format("/Acesso");
            return Redirect(rota);
        }

    }
}
