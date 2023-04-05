using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FC_CIP.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult InstructorIndex()
        {
            return View();
        }
    }
}