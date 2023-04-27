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
            if (string.IsNullOrEmpty(oUsuario.user_name) || string.IsNullOrWhiteSpace(oUsuario.user_name))
            {
                Mensaje += "¡El nombre de usuario es requerido! ";
            }
            if (string.IsNullOrEmpty(oUsuario.user_lastname) || string.IsNullOrWhiteSpace(oUsuario.user_lastname))
            {
                Mensaje += "¡El apellido de usuario es requerido! ";
            }
            if (string.IsNullOrEmpty(oUsuario.user_email) || string.IsNullOrWhiteSpace(oUsuario.user_email))
            {
                Mensaje += "¡El correo de usuario es requerido! ";
            }
            if (oUsuario.user_nid <= 0)
            {
                Mensaje += " ¡El número de identificaión de usuario es requerido! ";
            }
            if (oUsuario.user_phone <= 0)
            {
                Mensaje += "¡El número Telefónico de usuario es requerido!";
            }
            #endregion

            if (string.IsNullOrEmpty(Mensaje))
            {

                #region Limpiar espacios

                //Limpia espacios al principio y al final
                oUsuario.user_name = CL_Recursos.ClearText(oUsuario.user_name);
                oUsuario.user_lastname = CL_Recursos.ClearText(oUsuario.user_lastname);
                //Limpia todos los espacios
                oUsuario.user_email = CL_Recursos.ClearText(oUsuario.user_email, true);
                oUsuario.user_nid = CL_Recursos.ClearText((decimal)oUsuario.user_nid);
                //Limpia los espacios y válida que sea un número de telefónico celular
                oUsuario.user_phone = CL_Recursos.ClearText((decimal)oUsuario.user_phone);
                #endregion

                //Encripta la clave
                string clave = CL_Recursos.ConvertSha256(oUsuario.user_nid.ToString());


                //Prepara el envio del correo
                string asunto = "Creación de usuario FC CIP";
                string _mensaje = "<h3>Su cuenta fue creada con exito</h3><br /><p>Su usuario es: <strong>!correo!</strong> y su contraseña es <strong>!clave!</strong></p>";
                _mensaje = _mensaje.Replace("!correo!", oUsuario.user_email);
                _mensaje = _mensaje.Replace("!clave!", oUsuario.user_nid.ToString());

                //Envia el correo
                bool respuesta = CL_Recursos.EnviarCorreo(oUsuario.user_email,asunto,_mensaje);
                // Inserción a la base de datos

                if (respuesta)
                {
                    try
                    {
                        using (FC_CIP_BDEntities db = new FC_CIP_BDEntities())
                        {
                            oList = (from P in db.USUARIO
                                     where P.usua_nid == oUsuario.user_nid || P.user_email == oUsuario.user_email
                                     select P).ToList();

                            if (oList.Count > 0)
                            {
                                Mensaje = "El usuario !user! ya existe o el correo !email!";
                                Mensaje = Mensaje.Replace("!user!", oUsuario.user_nid.ToString());
                                Mensaje = Mensaje.Replace("!email!", oUsuario.user_email);
                            }
                            else
                            {
                                db.RegistrarUsuario(
                                oUsuario.user_nid,
                                clave,
                                oUsuario.user_name,
                                oUsuario.user_lastname,
                                oUsuario.user_email,
                                oUsuario.user_phone
                                );

                                db.SaveChanges();
                              
  
                            }

                            return 1;
                        }
                    }
                    catch (SqlException ex)
                    {
                        return IdUsuario;
                    }
                }
                else
                {
                    Mensaje = "Tenemos problemas para crear tu usuario\n¡Intenta más tarde!";
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