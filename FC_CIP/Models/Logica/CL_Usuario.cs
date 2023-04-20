using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FC_CIP.Models.TablasCombinadas;
using FC_CIP.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Ajax.Utilities;
using System.Data.Entity.Core.Objects;
using System.Collections;
using System.Web.Mvc;

namespace FC_CIP.Models.Logica
{
    public class CL_Usuario
    {
        public decimal RegistrarUsuario(USUARIO oUsuario, out string Mensaje)
        {
            decimal IdUsuario = 0;
            Mensaje = string.Empty;
            List<USUARIO> oList = new List<USUARIO>();

            try
            {
                using(FC_CIP_BDEntities db = new FC_CIP_BDEntities())
                {
                    oList = (from P in db.USUARIO
                             where P.us_nid == oUsuario.us_nid || P.us_email == oUsuario.us_email
                             select P).ToList();

                    if (oList.Count > 0)
                    {
                        Mensaje = "El usuario ya existe"; 
                    }
                    else
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
                    return IdUsuario;
                }
            }catch(SqlException ex)
            {
                return IdUsuario;
            }

            

            /*using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
            {
                oList = (from P in db.USUARIO
                         where P.us_nid == oUsuario.us_nid || P.us_email == oUsuario.us_email
                         select P).ToList();

                if (oList.Count > 0)
                {
                    respuesta = false;
                    return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.SaveUsuario(
                        oUsuario.us_nid,
                        oUsuario.us_password,
                        oUsuario.us_name,
                        oUsuario.us_lastname,
                        oUsuario.us_email,
                        oUsuario.us_phone);
                    db.SaveChanges();
                    respuesta = true;
                    return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
                }
            }*/
        }
    }
}