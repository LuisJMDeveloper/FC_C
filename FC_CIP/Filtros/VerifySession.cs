using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FC_CIP.Controllers;
using FC_CIP.Models;

namespace FC_CIP.Filtros
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (USUARIO)HttpContext.Current.Session["User"];
            if(oUser == null)
            {
                if(filterContext.Controller is HomeController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }

            }
            else if (oUser.us_typeuser == "Instructor")
            {
                if (filterContext.Controller is InstructorController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Instructor/InstructorIndex");
                }
            }
            else if (oUser.us_typeuser == "Coordinador")
            {
                if (filterContext.Controller is CoordinadorController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Coordinador/CoordinadorIndex");
                }
            }



            base.OnActionExecuting(filterContext);
        }
    }
}