using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hotel2012.Models;
using System.IO;
namespace hotel2012.Controllers
{
    public class archivosController : Controller
    {
        //
        // GET: /archivos/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult verlistadepersonas()
        {
           // archivopersona q= new archivopersona();
            coneccionDataContext ob = new coneccionDataContext();
            var p = from  cli in ob.cliente
                    join  per in ob.persona on cli.codigo_cliente equals per.codigo_cliente
                    join ciu in ob.ciudad on cli.codigo_ciudad equals ciu.codigo_ciudad
                    join pai in ob.pais on ciu.codigo_pais equals pai.codigo_pais
          select new archivopersona
          {
            codigo_cliente=cli.codigo_cliente,
            nombre=cli.nombre,
            telefono=cli.telefono,
            email=cli.email,
            direccion=cli.direccion,
            estado=cli.estado,
            comentario=cli.comentario,
            pais=pai.nombre,
            ciudad=ciu.nombre,
            codigo_persona=per.codigo_persona,
            paterno=per.paterno,
            materno=per.materno,
            pasaporte=per.pasaporte,
            cumpleaños=(per.cumpleaños??DateTime.Now)
          };

            return View(p);
        }
        public ActionResult exportarpersona()
        {
            coneccionDataContext ob = new coneccionDataContext();
            var p = from cli in ob.cliente
                    join per in ob.persona on cli.codigo_cliente equals per.codigo_cliente
                    join ciu in ob.ciudad on cli.codigo_ciudad equals ciu.codigo_ciudad
                    join pai in ob.pais on ciu.codigo_pais equals pai.codigo_pais
                    select new archivopersona
                    {
                        codigo_cliente = cli.codigo_cliente,
                        nombre = cli.nombre,
                        telefono = cli.telefono,
                        email = cli.email,
                        direccion = cli.direccion,
                        estado = cli.estado,
                        comentario = cli.comentario,
                        pais = pai.nombre,
                        ciudad = ciu.nombre,
                        codigo_persona = per.codigo_persona,
                        paterno = per.paterno,
                        materno = per.materno,
                        pasaporte = per.pasaporte,
                        cumpleaños = (per.cumpleaños ?? DateTime.Now)
                    };
            List<archivopersona> datos = p.ToList();
            string nombre = "personas" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "_") + ".csv";
            string ruta = Server.MapPath("~/download");
            StreamWriter stream = System.IO.File.CreateText(ruta + @"\" + nombre);
            // string cadena = "";
            foreach (var item in datos)
            {
                stream.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                item.codigo_cliente,item.nombre, item.telefono, item.email,item.direccion,item.estado,item.comentario,
                item.pais,item.ciudad,item.codigo_persona,item.paterno,item.materno,item.pasaporte,item.cumpleaños
                );
            }
            stream.Close();
            return Redirect("~/download/" + nombre);

        }
        public ActionResult verlistadeempresas()
        {
            coneccionDataContext ob = new coneccionDataContext();
            var p = from cli in ob.cliente
                    join em in ob.empresa on cli.codigo_cliente equals em.codigo_cliente
                    join ciu in ob.ciudad on cli.codigo_ciudad equals ciu.codigo_ciudad
                    join pai in ob.pais on ciu.codigo_pais equals pai.codigo_pais
                    select new archivoempresa
                    {
                        codigo_cliente = cli.codigo_cliente,
                        nombre = cli.nombre,
                        telefono = cli.telefono,
                        email = cli.email,
                        direccion = cli.direccion,
                        estado = cli.estado,
                        comentario = cli.comentario,
                        pais = pai.nombre,
                        ciudad = ciu.nombre,
                        codigo_empresa = em.codigo_empresa,
                        nit =(long) em.nit,
                        contacto = em.contacto,
                        metodo_pago = em.metodo_pago
                       // cumpleaños = (per.cumpleaños ?? DateTime.Now)
                    };
            return View(p);
        }
        public ActionResult exportarempresa()
        {
            coneccionDataContext ob = new coneccionDataContext();
            var p = from cli in ob.cliente
                    join em in ob.empresa on cli.codigo_cliente equals em.codigo_cliente
                    join ciu in ob.ciudad on cli.codigo_ciudad equals ciu.codigo_ciudad
                    join pai in ob.pais on ciu.codigo_pais equals pai.codigo_pais
                    select new archivoempresa
                    {
                        codigo_cliente = cli.codigo_cliente,
                        nombre = cli.nombre,
                        telefono = cli.telefono,
                        email = cli.email,
                        direccion = cli.direccion,
                        estado = cli.estado,
                        comentario = cli.comentario,
                        pais = pai.nombre,
                        ciudad = ciu.nombre,
                        codigo_empresa = em.codigo_empresa,
                        nit = (long)em.nit,
                        contacto = em.contacto,
                        metodo_pago = em.metodo_pago
                        // cumpleaños = (per.cumpleaños ?? DateTime.Now)
                    };
            List<archivoempresa> datos = p.ToList();
            string nombre = "empresas" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "_") + ".csv";
            string ruta = Server.MapPath("~/download");
            StreamWriter stream = System.IO.File.CreateText(ruta + @"\" + nombre);
            // string cadena = "";
            foreach (var item in datos)
            {
                stream.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                item.codigo_cliente, item.nombre, item.telefono, item.email, item.direccion, item.estado, item.comentario,
                item.pais, item.ciudad, item.codigo_empresa, item.nit, item.contacto, item.metodo_pago
                );
            }
            stream.Close();
            return Redirect("~/download/" + nombre);

        }
        public ActionResult verlistadeagencias()
        {
            coneccionDataContext ob = new coneccionDataContext();
            var p = from cli in ob.cliente
                    join ag in ob.agencia on cli.codigo_cliente equals ag.codigo_cliente
                    join ciu in ob.ciudad on cli.codigo_ciudad equals ciu.codigo_ciudad
                    join pai in ob.pais on ciu.codigo_pais equals pai.codigo_pais
                    select new archivoagencia
                    {
                        codigo_cliente = cli.codigo_cliente,
                        nombre = cli.nombre,
                        telefono = cli.telefono,
                        email = cli.email,
                        direccion = cli.direccion,
                        estado = cli.estado,
                        comentario = cli.comentario,
                        pais = pai.nombre,
                        ciudad = ciu.nombre,
                        codigo_agencia = ag.codigo_agencia,
                        nit = (long)ag.nit,
                        contacto = ag.contacto,
                       // metodo_pago = em.metodo_pago
                        // cumpleaños = (per.cumpleaños ?? DateTime.Now)
                    };
            return View(p);
        }
        public ActionResult exportaragencia()
        {
            coneccionDataContext ob = new coneccionDataContext();
            var p = from cli in ob.cliente
                    join ag in ob.agencia on cli.codigo_cliente equals ag.codigo_cliente
                    join ciu in ob.ciudad on cli.codigo_ciudad equals ciu.codigo_ciudad
                    join pai in ob.pais on ciu.codigo_pais equals pai.codigo_pais
                    select new archivoagencia
                    {
                        codigo_cliente = cli.codigo_cliente,
                        nombre = cli.nombre,
                        telefono = cli.telefono,
                        email = cli.email,
                        direccion = cli.direccion,
                        estado = cli.estado,
                        comentario = cli.comentario,
                        pais = pai.nombre,
                        ciudad = ciu.nombre,
                        codigo_agencia = ag.codigo_agencia,
                        nit = (long)ag.nit,
                        contacto = ag.contacto,
                        // metodo_pago = em.metodo_pago
                        // cumpleaños = (per.cumpleaños ?? DateTime.Now)
                    };
            List<archivoagencia> datos = p.ToList();
            string nombre = "agencias" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "_") + ".csv";
            string ruta = Server.MapPath("~/download");
            StreamWriter stream = System.IO.File.CreateText(ruta + @"\" + nombre);
            // string cadena = "";
            foreach (var item in datos)
            {
                stream.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                item.codigo_cliente, item.nombre, item.telefono, item.email, item.direccion, item.estado, item.comentario,
                item.pais, item.ciudad, item.codigo_agencia, item.nit, item.contacto
                );
            }
            stream.Close();
            return Redirect("~/download/" + nombre);

        }
    }
}
