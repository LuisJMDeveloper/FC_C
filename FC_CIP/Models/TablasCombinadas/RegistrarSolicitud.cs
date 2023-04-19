using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FC_CIP.Models.TablasCombinadas
{
    public class RegistrarSolicitud
    {

        /*
            @in_id numeric,
	        @co_id numeric,
	        @so_type varchar(15),
	        @so_ente varchar(100),
	        @am_id numeric,
	        @pf_id numeric, 
	        @pe_id numeric,
	        --@so_id declarada abajo
	        @cu_code numeric,
	        @cu_name varchar(100),
	        @cu_duration numeric,
	        @cu_startDate date,
	        @cu_endDate date, 
	        @cu_note varchar (255),
	        @cu_days varchar(200)
         */


        // Span co_id es el identificador del coordinador al que se le va a enviar la solitud.
        // No es necesario para el guardar
        public decimal co_id { get; set; }

        // Información de quien crea la solicitud
        public decimal us_id { get; set; }
        public decimal in_id { get; set; }
        public decimal us_nid { get; set; }
        public string us_name { get; set; }
        public string us_lastname { get; set; }
        public string us_email { get; set; }
        public decimal us_phone { get; set; }

        // Programa de formación
        public decimal pf_id { get; set; }


    }
}