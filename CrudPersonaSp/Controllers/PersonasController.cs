using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudPersonaSp.Models;
using CrudPersonaSp.Dao;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using CrudPersonaSp.CrystalReports;

namespace CrudPersonaSp.Controllers
{
    public class PersonasController : Controller
    {
        IPersonasDao dao = new PersonasDao();
        // GET: Personas
        public ActionResult Index()
        {
            return View(dao.Listar());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View(dao.BuscarId(id));
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            int id = dao.ObtenerId();
            ViewBag.idPersona = id;
            Personas p = new Personas();
            p.idPersona = id;
            return View(p);
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Personas persona, HttpPostedFileBase imagen)
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
            return View(dao.BuscarId(id));
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Personas persona)
        {
            try
            {

                dao.Actualizar(persona);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(persona);
            }
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View(dao.BuscarId(id));
        }

        // POST: Personas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                dao.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
        }
        public ActionResult ExportarPersonas()
        {
            try
            {
                List<Personas> allCustomer = new List<Personas>();
                allCustomer = dao.Listar();
                //creamos el objeto document
                ReportDocument rd = new ReportDocument();
                //le pasamos el reporte que hemos creado
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "PersonasReport.rpt"));
                //en el reporte ya le hemos instanceado el datasource, de lo contrario descomentamos las lineas siguientes
                            //rd.SetDataSource(allCustomer);
                             //  Response.Buffer = false;
                               //  Response.ClearContent();
                               //  Response.ClearHeaders();

                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Listado de Personas.pdf");  

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult ExportarPersona(int id)
        {
            try
            {
                //creamos el documento de reporte
                ReportDocument reportDoc = new ReportDocument();
                // creamos los parametros
                

                // Pasando una caneda/valor
                //reportDoc.SetParameterValue("@idPersona", "Hola Mundo");
                // Pasando una variable
               // reportDoc.SetParameterValue("@idPersona", id);

             
                ParameterField pf = new ParameterField();
                // se crea un objeto para meter los parametros requeridos
                ParameterFields pfs = new ParameterFields();
                //este objeto no se para que sirve
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();

                pf.Name = "@idPersona";
                pdv.Value = id;
                pf.CurrentValues.Add(pdv);

                pfs.Add(pf);
                //reportDoc.SetDataSource(dao.Listar());
               
                
                reportDoc.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "PersonaByIdReport.rpt"));
                Stream stream = reportDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Cliente"+id+".pdf"); 


            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
