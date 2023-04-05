using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            bool respuesta = true;

            try
            {
                using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
                {

                    db.saveUserValidation(
                        oUsuario.us_nid,
                        oUsuario.us_password,
                        oUsuario.us_name,
                        oUsuario.us_lastname,
                        oUsuario.us_email,
                        oUsuario.us_phone
                        );
                    
                    db.SaveChanges();
                }
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                respuesta = false;
            }

            return Json( new {resultado = respuesta}, JsonRequestBehavior.AllowGet);

        }
    }
}