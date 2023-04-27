using FC_CIP.Models.TablasCombinadas;
using FC_CIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FC_CIP.Models.Logica;

namespace FC_CIP.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult InstructorIndex()
        {
            CL_Curso.AddCurso();
            return View();
        }

        [HttpPost]
        public JsonResult RegistrarSolicitudCurso(SolicitudCurso oGuardado)
        {
            object resultado;
            using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
            {
                resultado = db.SaveSolicitudCurso(
                    oGuardado.co_id,
                    oGuardado.in_id,
                    oGuardado.so_type,
                    oGuardado.so_ente,
                    oGuardado.pf_id,
                    oGuardado.pe_id,
                    oGuardado.lu_id,
                    oGuardado.am_id,
                    oGuardado.cu_code,
                    oGuardado.cu_name,
                    oGuardado.cu_cupoMax,
                    oGuardado.cu_duration,
                    oGuardado.cu_startdate,
                    oGuardado.cu_enddate,
                    oGuardado.cu_note,
                    oGuardado.cu_days);
                
            }


            return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);

        }
    }
}