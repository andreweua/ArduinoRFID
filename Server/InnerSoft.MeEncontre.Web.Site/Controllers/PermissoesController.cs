using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnerSoft.MeEncontre.Web.Site.Controllers
{
    public class PermissoesController : Controller
    {
        //
        // GET: /Permissoes/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Permissoes/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Permissoes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Permissoes/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Permissoes/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Permissoes/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Permissoes/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Permissoes/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
