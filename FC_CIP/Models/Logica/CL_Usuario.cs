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
        public decimal SaveUser(UsuarioInstructor oUsuario, out string Mensaje)
        {
            List<USUARIO> oList = new List<USUARIO>();
            decimal IdUsuario = 0;
            Mensaje = string.Empty;

            #region Evitar campos vacíos
            if (string.IsNullOrEmpty(oUsuario.us_name) || string.IsNullOrWhiteSpace(oUsuario.us_name))
            {
                Mensaje += "¡El nombre de usuario es requerido!";
            }
            if (string.IsNullOrEmpty(oUsuario.us_lastname) || string.IsNullOrWhiteSpace(oUsuario.us_lastname))
            {
                Mensaje += "¡El apellido de usuario es requerido!";
            }
            if (string.IsNullOrEmpty(oUsuario.us_email) || string.IsNullOrWhiteSpace(oUsuario.us_email))
            {
                Mensaje += "¡El correo de usuario es requerido!";
            }
            if (oUsuario.us_nid <= 0)
            {
                Mensaje += "¡El número de identificaión de usuario es requerido!";
            }
            if (oUsuario.us_phone <= 0)
            {
                Mensaje += "¡El número Telefónico de usuario es requerido!";
            }
            #endregion

            if (string.IsNullOrEmpty(Mensaje))
            {

                #region Limpiar espacios

                //Limpia espacios al principio y al final
                oUsuario.us_name = CL_Recursos.ClearText(oUsuario.us_name);
                oUsuario.us_lastname = CL_Recursos.ClearText(oUsuario.us_lastname);
                //Limpia todos los espacios
                oUsuario.us_email = CL_Recursos.ClearText(oUsuario.us_email, true);
                oUsuario.us_nid = CL_Recursos.ClearText((decimal)oUsuario.us_nid);
                //Limpia los espacios y válida que sea un número de telefónico celular
                oUsuario.us_phone = CL_Recursos.ValidatePhone((decimal)oUsuario.us_phone);
                #endregion

                string clave = CL_Recursos.ConvertSha256(oUsuario.us_nid.ToString());

                string asunto = "Creación de usuario FC CIP";
                string _mensaje = "<h3>Su cuenta fue creada con exito</h3><br /><p>Su usuario es: <strong>!correo!</strong> y su contraseña es <strong>!clave!</strong></p>";
                _mensaje = _mensaje.Replace("!correo!", oUsuario.us_email);
                _mensaje = _mensaje.Replace("!clave!", oUsuario.us_nid.ToString());

                bool respuesta = CL_Recursos.EnviarCorreo(oUsuario.us_email,asunto,_mensaje);
                // Inserción a la base de datos

                if (respuesta)
                {
                    try
                    {
                        using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
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
                    }
                    catch (SqlException ex)
                    {
                        return IdUsuario;
                    }
                }

                #region Registro de ejemplo
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
                #endregion
            }

            return IdUsuario;
        }

        
    }
}