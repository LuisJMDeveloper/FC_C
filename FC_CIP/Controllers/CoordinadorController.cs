using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FC_CIP.Controllers
{
    public class CoordinadorController : Controller
    {
        // GET: Coordinador
        public ActionResult CoordinadorIndex()
        {
            return View();
        }

        /*[HttpGet]
        public JsonResult getSolicitudesRecibidas()
        {

            using (var db = new FC_DB())
            {
                var oLista = db.Database.SqlQuery<getSolicitudesRecibidas>("EXEC getSolicitudesRecibidas").ToList();
                return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            }
        }*/
    }
}