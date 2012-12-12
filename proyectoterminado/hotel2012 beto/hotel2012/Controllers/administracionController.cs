using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hotel2012.Models;

namespace hotel2012.Controllers
{
    public class administracionController : Controller
    {
        //
        // GET: /administracion/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult verrolesdeusuario()
        {
            coneccionDataContext db = new coneccionDataContext();

            List<UserListRol> Lista = db.
                    Users.
                    Select(a => new UserListRol()
                    {
                        id = a.UserId,
                        nombre = a.UserName,
                        ListaRoles = db.UsersInRoles.Where(b => b.UserId == a.UserId).
                        Select(b => new RolView()
                        {
                            id = b.Roles.RoleId,
                            nombre = b.Roles.RoleName
                        }).ToList()
                    }).ToList();



            ViewBag.roles = db.Roles.ToList();
            ViewBag.lista = Lista;
            // ViewBag.hhgh = "ghghg";
            return View();
        }
        public ActionResult eliminarrol(string idu,string []rol) {
            coneccionDataContext db = new coneccionDataContext();
            Guid id =  new Guid(idu);
            try{
                db.UsersInRoles.DeleteOnSubmit(db.UsersInRoles.Where(a => a.UserId == id).First());
                db.SubmitChanges();
                return Content("true");
            }catch(Exception){
                return Content("false");
            }
        }
        public ActionResult agregarol(string idu, string[] rol) {

            try
            {
                Guid idus = new Guid(idu);
                coneccionDataContext db = new coneccionDataContext();
                foreach (string a in rol)
                {
                    Guid id = new Guid(a);
                    var x = db.UsersInRoles.Where(aa => aa.RoleId == id && aa.UserId == idus);
                    if (x.Count() == 0)
                    {
                        UsersInRoles roles = new UsersInRoles()
                        {
                            UserId = idus,
                            RoleId = id

                        };
                        db.UsersInRoles.InsertOnSubmit(roles);
                        db.SubmitChanges();
                    }
                }
                ViewBag.nombre = db.Users.Where(ss=>ss.UserId==idus).First().UserName;
                var rol_ = db.UsersInRoles.Where(b => b.UserId == idus).
                        Select(b => new RolView()
                        {
                            id = b.Roles.RoleId,
                            nombre = b.Roles.RoleName
                        }).ToList();
                return View(rol_);
            }
            catch (Exception) { return Content("false"); }
        }

    }
}
