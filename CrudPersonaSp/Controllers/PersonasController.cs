using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudPersonaSp.Models;
using CrudPersonaSp.Dao;

namespace CrudPersonaSp.Controllers
{
    public class PersonasController : Controller
    {
        IPersonasDao dao = new PersonasDao();
        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View(new Personas());
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Personas persona)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(persona);
                }
                ViewBag.Mensaje = dao.Crear(persona);
                // TODO: Add insert logic here
                return View(persona);
               // return RedirectToAction("Index");
            }
            catch
            {
                return View(persona);
            }
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
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

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
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
