using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;
using FC_CIP.Models;
using FC_CIP.Models.Logica;
using FC_CIP.Models.TablasCombinadas;

namespace FC_CIP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveUser(UsuarioInstructor obj)
        {
            object result;
            string mensaje = string.Empty;

            result = new CL_Usuario().SaveUser(obj, out mensaje);

            return Json(new {result = result, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ValidarIngreso(USUARIO oUsuario)
        {
            USUARIO oPersona = new USUARIO();
            string resultado = string.Empty;
            using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
            {
                
                var lst = from d in db.USUARIO
                          where d.us_email == oUsuario.us_email
                          && d.us_password == oUsuario.us_password
                          select d;

                if (lst.Count() > 0)
                {
                    USUARIO oUser = lst.First();
                    Session["User"] = oUser;

                    if(oUser.us_typeuser == "Instructor")
                    {
                        resultado = "1";
                    }else if (oUser.us_typeuser == "Coordinador")
                    {
                        resultado = "2";
                    }
                    return Content(resultado);
                }
                else
                {
                    return Content(resultado);
                }
            }
        }


    }
}