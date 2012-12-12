using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hotel2012.Models;
namespace hotel2012.Controllers
{
    public class ServiciosController : Controller
    {
        //
        // GET: /Servicios/
        coneccionDataContext bd = new coneccionDataContext();

        public ActionResult lista()
        {

            return View(bd.servicios.ToList());
        }

        public ActionResult Index()
        {

            return View(bd.servicios.ToList());
        }

        //
        // GET: /Servicios/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Servicios/Create

        public ActionResult Create(string x)
        {
            ViewBag.flag = x;
            return View();
        }

        //
        // POST: /Servicios/Create

        [HttpPost]
        public ActionResult Create(servicios se)
        {
            try
            {
                bd.servicios.InsertOnSubmit(se);
                bd.SubmitChanges();
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }

        //
        // GET: /Servicios/Edit/5

        public ActionResult Edit()
        {
            return View();
        }

        //
        // POST: /Servicios/Edit/5

        [HttpPost]
        public JsonResult Edit(int id)
        {
            try
            {
                var x=bd.servicios.Where(ss => ss.codigo_servicio == id).First();
                servicios q = new servicios();
                q.codigo_servicio = x.codigo_servicio;
                q.nombre = x.nombre;
                q.costo = x.costo;
                q.descripcion=x.descripcion;
               // ViewBag.data = q;
                Session["id"] = id;
                return Json(new {q});
            }
            catch
            {
                return Json(new { datos = "false" });
            }
        }
        [HttpPost]
        public ActionResult Editado(servicios se)
        {
            try
            {

                var xx = bd.servicios.Where(a => a.codigo_servicio == (int)Session["id"]).First();
                xx.nombre = se.nombre;
                xx.costo = se.costo;
                xx.descripcion = se.descripcion;
                xx.codigo_servicio = (int)Session["id"];
                bd.SubmitChanges();
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }
        //
        // GET: /Servicios/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                servicios x = (from fo in bd.servicios where fo.codigo_servicio == id select fo).First();
                bd.servicios.DeleteOnSubmit(x);
                bd.SubmitChanges();
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }

        //
        // POST: /Servicios/Delete/5

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
        public ActionResult mostrarservicios() {
            return View();
        }
        public ActionResult mostrardetalleservicio()
        {
            return View();
        }
    }
}
