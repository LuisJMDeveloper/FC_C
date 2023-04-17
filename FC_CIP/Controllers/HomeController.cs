using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;
using FC_CIP.Models;
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
        public JsonResult RegistrarInstructor(UsuarioInstructor oUsuario)
        {
            bool respuesta = false;
            List<USUARIO> oList = new List<USUARIO>();

            using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
            {
                oList = (from P in db.USUARIO
                         where P.us_nid == oUsuario.us_nid
                         select P).ToList();

                if (oList.Count > 0)
                {
                    respuesta = false;
                }
                else
                {
                    var resultado = db.saveUserValidation(
                        oUsuario.us_nid,
                        oUsuario.us_password,
                        oUsuario.us_name,
                        oUsuario.us_lastname,
                        oUsuario.us_email,
                        oUsuario.us_phone
                        );

                    db.SaveChanges();
                    respuesta = true;
                }
            }
           

            return Json( new {resultado = respuesta}, JsonRequestBehavior.AllowGet);

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

            /*oPersona = db.Database.SqlQuery<USUARIO>(
                    "exec GetUserType "
                    + oUsuario.us_email + ","
                    + oUsuario.us_password).FirstOrDefault();
            if (oPersona.us_typeuser != null)
            {
                switch (oPersona.us_typeuser)
                {
                    case "Instructor":
                        resultado = 1;
                        break;
                    case "Coordinador":
                        resultado =2;
                        break;
                }
            }

            return Json(new { resultado }, JsonRequestBehavior.AllowGet);*/
        }


    }
}