using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hotel2012.Models;

namespace hotel2012.Controllers
{
    public class reservasController : Controller
    {
        /*1 reservado
            2 ocupado
         * 3 salio
         */
        // GET: /reservas/
        coneccionDataContext ob = new coneccionDataContext();
        public ActionResult Index()
        {
            /*
            var xx = from hab in ob.habitacion
                     join cat in ob.categoria on hab.codigo_categoria equals cat.codigo_categoria
                     join est in ob.estado on hab.codigo_habitacion equals est.codigo_habitacion
                     join reha in ob.reserva_tiene_habitacion_tiene_consumo on hab.codigo_habitacion equals reha.codigo_habitacion into gg from hf in gg.DefaultIfEmpty() where hf ==null select hab.codigo_habitacion
                     join re in ob.reserva on reha.codigo_reserva equals re.codigo_reserva
                     where re.estado != 1 && re.estado != 2 && est.motivo == true
                     select new habitacio
                     {
                         codigo_habitacion=hab.codigo_habitacion,
                         numero= hab.numero??0,
                         piso= hab.piso??0,
                         precio=hab.precio??0,
                         estado=hab.estado,
                         codigo_categoria=hab.codigo_categoria??0,
                         categoria=cat.tipo
                     };
             * */
            var xx = ob.ExecuteQuery<habitacio>(@"SELECT DISTINCT 
                      dbo.habitacion.codigo_habitacion, dbo.habitacion.numero, dbo.habitacion.piso, dbo.habitacion.precio, dbo.estado.motivo, dbo.habitacion.codigo_categoria, 
                      dbo.habitacion.estado, dbo.categoria.tipo
FROM         dbo.reserva INNER JOIN
                      dbo.reserva_tiene_habitacion_tiene_consumo ON dbo.reserva.codigo_reserva = dbo.reserva_tiene_habitacion_tiene_consumo.codigo_reserva RIGHT OUTER JOIN
                      dbo.categoria INNER JOIN
                      dbo.habitacion ON dbo.categoria.codigo_categoria = dbo.habitacion.codigo_categoria INNER JOIN
                      dbo.estado ON dbo.habitacion.codigo_habitacion = dbo.estado.codigo_habitacion ON 
                      dbo.reserva_tiene_habitacion_tiene_consumo.codigo_habitacion = dbo.habitacion.codigo_habitacion
WHERE     (dbo.habitacion.estado = 1) AND (dbo.categoria.tipo = 'simple')");
            ViewBag.dato = xx;
            return View();
        }
        [HttpPost]
        public ActionResult Index(reserva ha)
        {
            ha.estado = 1;

            ha.codigo_cliente = (int)Session["idcli"];
            ob.reserva.InsertOnSubmit(ha);
            return View();
        }
        //
        // GET: /reservas/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /reservas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /reservas/Create

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
        // GET: /reservas/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /reservas/Edit/5

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
        // GET: /reservas/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /reservas/Delete/5

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
