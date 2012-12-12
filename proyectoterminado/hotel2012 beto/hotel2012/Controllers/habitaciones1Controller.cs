using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hotel2012.Models;

namespace hotel2012.Controllers
{
    public class habitaciones1Controller : Controller
    {
        //
        // GET: /habitaciones1/
        public ActionResult estado (int id){
            try
            {
                coneccionDataContext bd = new coneccionDataContext();
                var x = bd.estado.Where(ss => ss.codigo_habitacion == id).First();
                
                // ViewBag.data = q;
                //Session["id"] = id;
                return View(x);
            }
            catch
            {
                return View();
            }
        }
         [HttpPost]
        public ActionResult estado(estado a)
        {
            try
            {
                coneccionDataContext bd = new coneccionDataContext();
                estado ac = bd.estado.Where(ss => ss.codigo_estado == a.codigo_estado).First();
                ac.codigo_estado=a.codigo_estado;
                ac.fecha_fin=a.fecha_fin;
                ac.fecha_inicio=a.fecha_inicio;
                ac.descripcion=a.descripcion;
                ac.motivo = a.motivo;
                ac.codigo_habitacion = a.codigo_habitacion;
                bd.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    
        public ActionResult Index()
        {
            coneccionDataContext ob = new coneccionDataContext();
            return View(ob.habitacion.Where(a => a.estado == 1).ToList());
        }
        public ActionResult lista()
        {

            coneccionDataContext ob = new coneccionDataContext();
            return View(ob.habitacion.Where(a=>a.estado==1).ToList());
        }

        //
        // GET: /habitaciones1/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /habitaciones1/Create

        public ActionResult Create(string x)
        {
            coneccionDataContext ob= new coneccionDataContext();
            ViewBag.categorias = ob.categoria;
            ViewBag.flag = x;
            return View();
        }

        //
        // POST: /habitaciones1/Create
        [HttpPost]
        public ActionResult Create(habitacion se)
        {
            try
            {
                coneccionDataContext bd = new coneccionDataContext();
                se.estado = 1;
                bd.habitacion.InsertOnSubmit(se);

                bd.SubmitChanges();
                estado es = new estado();
                es.descripcion = "activo";
                es.fecha_inicio=DateTime.Now;
                es.motivo =true;
                es.codigo_habitacion = se.codigo_habitacion;
                bd.estado.InsertOnSubmit(es);

                bd.SubmitChanges();
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }

        //
        // GET: /habitaciones1/Edit/5

        //
        // POST: /habitaciones1/Edit/5

        [HttpPost]
        public JsonResult Edit(int id)
        {
            try
            {
                coneccionDataContext bd = new coneccionDataContext();
                var x = bd.habitacion.Where(ss => ss.codigo_habitacion == id).First();
                habitacion q = new  habitacion();
                q.numero = x.numero;
                q.piso = x.piso;
                q.precio = x.precio;
                q.codigo_categoria = x.codigo_categoria;
                // ViewBag.data = q;
                Session["id"] = id;
                return Json(new { q });
            }
            catch
            {
                return Json(new { datos = "false" });
            }
        }

        //
        // GET: /habitaciones1/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                coneccionDataContext ob = new coneccionDataContext();
                habitacion x = (from fo in ob.habitacion where fo.codigo_habitacion == id select fo).First();
                x.estado = 0;
                ob.SubmitChanges();
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }

        //
        // POST: /habitaciones1/Delete/5

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
        [HttpPost]
        public ActionResult Editado(habitacion se)
        {
            try
            {
                coneccionDataContext bd= new coneccionDataContext();
                var xx = bd.habitacion.Where(a => a.codigo_habitacion == (int)Session["id"]).First();
                xx.numero = se.numero;
                xx.piso = se.piso;
                xx.precio = se.precio;
                xx.codigo_categoria = se.codigo_categoria; 
                xx.codigo_habitacion=(int)Session["id"];
                bd.SubmitChanges();
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }
    }
}
