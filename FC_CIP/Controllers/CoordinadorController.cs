using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FC_CIP.Models;
using FC_CIP.Models.TablasCombinadas;

namespace FC_CIP.Controllers
{
    public class CoordinadorController : Controller
    {
        // GET: Coordinador
        public ActionResult CoordinadorIndex()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getSolicitudesRecibidas()
        {
            using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
            {
                var oLista = db.Database.SqlQuery<SolicitudesRecibidas>("EXEC getSolicitudes").ToList();
                return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            }
        }

       
    }
}