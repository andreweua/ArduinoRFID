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

    public class LocalController : ControllerAdmin
    {        

        public LocalController(ClienteService clienteService, StatusService statusService)
            : base(clienteService, statusService)
        {

        }

       
        private Local LocalSelecionado(int Id)
        {
            return ClienteSelecionado().Locais.Where(a => a.Id == Id).FirstOrDefault();
        }

        //
        // GET: /Local/
        public ActionResult Index()
        {
            var locais = ClienteSelecionado().Locais.ToList();
            var locaisViewModel = Mapper.Map<IList<Local>, IList<LocalViewModel>>(locais);

            return View(locaisViewModel);

        }
        //
        // GET: /Local/Details/5
        public ActionResult Details(int id)
        {

            Local local = LocalSelecionado(id);

            if (local == null)
            {
                return HttpNotFound();
            }

            var localViewModel = Mapper.Map<Local, LocalViewModel>(local);
            return View(localViewModel);
        }

        //
        // GET: /Local/Create

        public ActionResult Create()
        {
            LocalViewModel localViewModel = new LocalViewModel();
            localViewModel.Key = GenerateGuid();
            return View(localViewModel);
        }

        //
        // POST: /Local/Create
        [HttpPost]
        public ActionResult Create(LocalViewModel localViewModel)
        {
            var local = new Local();
            local = Mapper.Map<LocalViewModel, Local>(localViewModel);

            if (ModelState.IsValid)
            {
                var cliente = ClienteSelecionado();
                local.Status = StatusAtivo();
                cliente.Locais.Add(local);
                _ClienteService.Update(cliente);

                var rota = String.Format("/Local");
                return Redirect(rota);
            }

            return View(localViewModel);
        }


        //
        // GET: /Local/Edit/5
        public ActionResult Edit(int id)
        {
            Local local = LocalSelecionado(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            var LocalViewModel = Mapper.Map<Local, LocalViewModel>(local);
            return View(LocalViewModel);
        }
        //
        // POST: /Local/Edit/5
        [HttpPost]
        public ActionResult Edit(LocalViewModel localViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = ClienteSelecionado();

                Local local = cliente.Locais.Where(a => a.Id == localViewModel.Id).FirstOrDefault();

                if (local == null)
                {
                    return HttpNotFound();
                }

                SetModel(local, localViewModel);

                _ClienteService.Update(cliente);

                var rota = String.Format("/Local");
                return Redirect(rota);

            }

            return View(localViewModel);
        }

        private void SetModel(Local Local, LocalViewModel LocalViewModel)
        {
            Local.Nome = LocalViewModel.Nome;
            Local.Endereco = LocalViewModel.Endereco;
            Local.Key = LocalViewModel.Key;
            Local.Latitude = LocalViewModel.Latitude;
            Local.Longitude = LocalViewModel.Longitude;


        }

        //
        // GET: /Local/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var cliente = ClienteSelecionado();

            Local local = cliente.Locais.Where(a => a.Id == id).FirstOrDefault();

            if (local == null)
            {
                return HttpNotFound();
            }

            cliente.Locais.Remove(local);
            _ClienteService.Update(cliente);

            var rota = String.Format("/Local");
            return Redirect(rota);
        }
       
    }
}
