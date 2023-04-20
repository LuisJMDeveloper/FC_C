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

namespace FC_CIP.Models.Logica
{
    public class CL_Usuario
    {
        public decimal RegistrarUsuario(USUARIO oUsuario, out string Mensaje)
        {
            decimal IdUsuario = 0;
            Mensaje = string.Empty;

            try
            {
                using(FC_CIP_BDEntities db = new FC_CIP_BDEntities())
                {
                    var resultado = db.saveUserValidation(
                        oUsuario.us_nid,
                        oUsuario.us_password,
                        oUsuario.us_name,
                        oUsuario.us_lastname,
                        oUsuario.us_email,
                        oUsuario.us_phone
                        );
                }
            }catch(SqlException ex)
            {

            }

            return IdUsuario;
        }
    }
}