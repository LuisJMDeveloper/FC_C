using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FC_CIP.Models.TablasCombinadas
{
    public class FormatoSolicitudes
    {
        public string userName { get; set; }
        public decimal usua_nid { get; set; }
        public string user_lastname { get; set; }
        public string user_email { get; set; }
        public decimal user_phone { get; set; }
        public DateTime curso_startDate { get; set; }
        public DateTime curso_endDate { get; set; }
        public string curso_programa { get; set; }
        public int curso_code { get; set; }
        public double curso_version { get; set; }
        public string curso_lugar { get; set; }
        public string muni_name { get; set; }
        public int curso_duration { get; set; }
        public string pe_name { get; set; }
        public string curso_note { get; set; }
        public string soli_type { get; set; }
        public string soli_empresa { get; set; }
        public string curso_days { get; set; }



    }
}