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
            string resultado = string.Empty;
            using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
            {

                var oUser = (from d in db.USUARIO
                           where d.user_email == oUsuario.user_email
                           //&& SHA256.ReferenceEquals(d.user_password, oUsuario.user_password)
                           select d).FirstOrDefault<USUARIO>();

                if (oUser != null)
                {
                    if (CL_Recursos.ConvertSha256(oUsuario.user_password).Equals(oUser.user_password))
                    {
                        if (oUser != null)
                        {

                            Session["User"] = oUser;

                            if (oUser.user_type == 2020)
                            {
                                resultado = "1";
                            }
                            else if (oUser.user_type == 1010)
                            {
                                resultado = "2";
                            }
                            return Content(resultado);
                        }

                    }
                    else
                    {
                        resultado = "0";
                    }
                }
                else
                {
                    resultado = "0";
                }
            }
            return Content(resultado);
        }
    }
}