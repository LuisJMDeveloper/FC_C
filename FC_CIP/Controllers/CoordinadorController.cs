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

        [HttpGet]
        public JsonResult getSolicitudesID(int so_id)
        {
            using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
            {
                var oLista = db.Database.SqlQuery<SolicitudesRecibidas>("EXEC getSolicitudesID " + so_id).FirstOrDefault();
                return Json( oLista , JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateSolicitud(int so_id,string soli_status)
        {
            using(FC_CIP_BDEntities db = new FC_CIP_BDEntities())
            {
                db.UpdateSolistatus(so_id, soli_status);
                db.SaveChanges();
                var oLista = db.Database.SqlQuery<SolicitudesRecibidas>("EXEC getSolicitudesID " + so_id).FirstOrDefault();
                return Json(oLista, JsonRequestBehavior.AllowGet);
            }
        }


    }
}