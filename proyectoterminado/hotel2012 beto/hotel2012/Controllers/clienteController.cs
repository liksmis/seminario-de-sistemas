using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hotel2012.Models;

namespace hotel2012.Controllers
{
   
    public class clienteController : Controller
    {
        int a;
        Guid data;
        //
        // GET: /registrarcliente/

        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult registrar() {
            coneccionDataContext ob=new coneccionDataContext();
            ViewBag.p = ob.pais;
            return View();
        }
       [HttpPost]
        public ActionResult registrar(cliente model) {
           //var aa= Request["tipo"];
           // agencia c = new agencia();
            //contacto = Request["contacto"];
            coneccionDataContext ob =new coneccionDataContext();
            cliente ob1 = new cliente() { nombre = model.nombre, telefono = model.telefono,email = model.email, direccion = model.direccion, estado = model.estado, comentario = model.comentario,codigo_ciudad=model.codigo_ciudad };
            ob.cliente.InsertOnSubmit(ob1);
            ob.SubmitChanges();
            a = (from ag in ob.cliente
                     select ag.codigo_cliente).OrderByDescending(codigo => codigo).First();
            
           string xx= User.Identity.Name;
           Guid iddd = ob.Users.Where(ss => ss.UserName == xx).First().UserId;
           usuario q = new usuario();
           q.codigo_user = iddd;
           q.codigo_cliente = a;
           ob.usuario.InsertOnSubmit(q);
           ob.SubmitChanges();
           data = iddd;

            if (Request["tipo"] == "empresa") {

                empresa em = new empresa();
                em.contacto = Request["contacto"];
                em.nit =Convert.ToInt32(Request["nit"]);
                em.metodo_pago = Request["contacto"];
                em.codigo_cliente = a;
                ob.empresa.InsertOnSubmit(em);
                ob.SubmitChanges();
            
            }
            if (Request["tipo"] == "agencia")
            {
                agencia ag = new agencia();
                ag.nit = Convert.ToInt32(Request["nit"]);
                ag.contacto = (Request["contacto"]);
                ag.codigo_cliente = a;
                ob.agencia.InsertOnSubmit(ag);
                ob.SubmitChanges();

            }
            if (Request["tipo"] == "persona")
            {
                persona pe = new persona();
                pe.paterno=(Request["paterno"]);
                pe.materno=(Request["materno"]);
                pe.pasaporte = (Request["pasaporte"]);
                pe.cumpleaños = Convert.ToDateTime((Request["cumpleaños"]));
                pe.codigo_cliente = a;
                ob.persona.InsertOnSubmit(pe);
                ob.SubmitChanges();
            }
            agregarroldecliente(data);
            return (RedirectToAction("Index"));
        }
        public void agregarroldecliente(Guid a){
            coneccionDataContext ob = new coneccionDataContext();
            Guid irol = ob.Roles.Where(ss => ss.RoleName == "activado").First().RoleId;
            UsersInRoles p = new UsersInRoles();
            p.RoleId = irol;
            p.UserId = a;
            ob.UsersInRoles.InsertOnSubmit(p);
            ob.SubmitChanges();
                //db.Users.Where(ss => ss.UserId == idus).First().UserName;
        }

        public ActionResult tipoempresa() {
            return View();
        }
        public ActionResult tipoagencia()
        {
            return View();
        }
        public ActionResult tipopersona()
        {
            return View();
        }
        public ActionResult cargarciudad(int id)
        {
            coneccionDataContext ob = new coneccionDataContext();
            var ciudad = ob.ciudad.Where(a => a.codigo_pais == id);
            ViewBag.ciudad = ciudad;
            return View();
        }
    }
}
