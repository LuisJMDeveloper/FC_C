using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FC_CIP.Models.TablasCombinadas
{
    public class SolicitudesRecibidas
    {
        #region Datos
        public decimal us_id { get; set; }
        public decimal us_nid { get; set; }
        public string us_name { get; set; }
        public string us_lastname { get; set; }
        public string us_email { get; set; }
        public decimal us_phone { get; set; }

    
        public decimal co_id { get; set; }
        

        public decimal in_id { get; set; }


        public decimal so_id { get; set; }
        public string so_status { get; set; }
        public string so_type { get; set; }
        public string so_ente { get; set; }
        public DateTime so_date { get; set; }


        public string cu_name { get; set; }


        public string pf_name { get; set; }
        public double pf_version { get; set; }
        #endregion

        /* Glosario
            
            us = USUARIO
            in = INSTRUCTOR
            so = SOLICITUD
            cu = CURSO2
            am = AMBIENTE
            lo = LOCACION => Municipio o centro de formación
            pf = PROGRAMA DE FORMACION
            pe = PROGRAMA ESPECIAL

         */

        /* Estructura Consulta
         
            select *
			from USUARIO, INSTRUCTOR, SOLICITUD, CURSO2
			where USUARIO.us_id = INSTRUCTOR.in_id and
				INSTRUCTOR.in_id = SOLICITUD.in_id and 
				SOLICITUD.so_id = CURSO2.so_id

         */

        /* Resultado de la consulta
            us_id
            us_nid
            us_password
            us_typeuser
            us_name
            us_lastname
            us_email
            us_phone
            us_reestablecer
            us_date
            
            in_id
            
            so_id
            co_id
            in_id
            so_status
            so_type
            so_ente
            so_date

            cu_id
            cu_code
            cu_name
            cu_duration
            cu_startDate
            cu_endDate
            cu_note
            cu_days
            am_name
            lo_name
            pf_name
            pf_version
            pe_name
            so_id
         */

    }
}