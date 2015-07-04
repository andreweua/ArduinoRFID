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

    public class ColaboradorController : ControllerAdmin
    {

        public ColaboradorController(ClienteService clienteService, StatusService statusService)
            : base(clienteService, statusService)
        {

        }

        private Colaborador Colaboradoreselecionado(int Id)
        {
            return ClienteSelecionado().Colaboradores.Where(a => a.Id == Id).FirstOrDefault();
        }

        //
        // GET: /Colaborador/
        public ActionResult Index()
        {
            var colaboradores = ClienteSelecionado().Colaboradores.ToList();
            var colaboradoresViewModel = Mapper.Map<IList<Colaborador>, IList<ColaboradorViewModel>>(colaboradores);

            return View(colaboradoresViewModel);

        }
        //
        // GET: /Colaborador/Details/5
        public ActionResult Details(int id)
        {

            Colaborador Colaborador = Colaboradoreselecionado(id);

            if (Colaborador == null)
            {
                return HttpNotFound();
            }

            var ColaboradorViewModel = Mapper.Map<Colaborador, ColaboradorViewModel>(Colaborador);
            return View(ColaboradorViewModel);
        }

        //
        // GET: /Colaborador/Create

        public ActionResult Create()
        {
            ColaboradorViewModel ColaboradorViewModel = new ColaboradorViewModel();
            return View(ColaboradorViewModel);
        }

        //
        // POST: /Colaborador/Create
        [HttpPost]
        public ActionResult Create(ColaboradorViewModel ColaboradorViewModel)
        {
            var Colaborador = new Colaborador();
            Colaborador = Mapper.Map<ColaboradorViewModel, Colaborador>(ColaboradorViewModel);

            if (ModelState.IsValid)
            {
                var cliente = ClienteSelecionado();
                Colaborador.Status = StatusAtivo();
                cliente.Colaboradores.Add(Colaborador);
                _ClienteService.Update(cliente);

                var rota = String.Format("/Colaborador");
                return Redirect(rota);
            }

            return View(ColaboradorViewModel);
        }


        //
        // GET: /Colaborador/Edit/5
        public ActionResult Edit(int id)
        {
            Colaborador Colaborador = Colaboradoreselecionado(id);
            if (Colaborador == null)
            {
                return HttpNotFound();
            }
            var ColaboradorViewModel = Mapper.Map<Colaborador, ColaboradorViewModel>(Colaborador);
            return View(ColaboradorViewModel);
        }
        //
        // POST: /Colaborador/Edit/5
        [HttpPost]
        public ActionResult Edit(ColaboradorViewModel ColaboradorViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = ClienteSelecionado();

                Colaborador Colaborador = cliente.Colaboradores.Where(a => a.Id == ColaboradorViewModel.Id).FirstOrDefault();

                if (Colaborador == null)
                {
                    return HttpNotFound();
                }

                SetModel(Colaborador, ColaboradorViewModel);

                _ClienteService.Update(cliente);

                var rota = String.Format("/Colaborador");
                return Redirect(rota);

            }

            return View(ColaboradorViewModel);
        }

        private void SetModel(Colaborador Colaborador, ColaboradorViewModel ColaboradorViewModel)
        {
            Colaborador.Nome = ColaboradorViewModel.Nome;
            Colaborador.Key = ColaboradorViewModel.Key;
            Colaborador.Documento = ColaboradorViewModel.Documento;
            Colaborador.Email = ColaboradorViewModel.Email;
        }

        //
        // GET: /Colaborador/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var cliente = ClienteSelecionado();

            Colaborador Colaborador = cliente.Colaboradores.Where(a => a.Id == id).FirstOrDefault();

            if (Colaborador == null)
            {
                return HttpNotFound();
            }

            cliente.Colaboradores.Remove(Colaborador);
            _ClienteService.Update(cliente);

            var rota = String.Format("/Colaborador");
            return Redirect(rota);
        }

    }
}
