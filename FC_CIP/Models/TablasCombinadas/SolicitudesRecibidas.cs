using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FC_CIP.Models.TablasCombinadas
{
    public class SolicitudesRecibidas
    {
        #region Datos
        public decimal userId { get; set; }
        public decimal usua_nid { get; set; }
        public string userName { get; set; }
        public string user_lastname { get; set; }
        public string user_email { get; set; }
        public decimal user_phone { get; set; }

    
        public decimal user_InId { get; set; }
        

        public decimal user_CoId { get; set; }


        public decimal so_id { get; set; }
        public string soli_status { get; set; }
        public string soli_type { get; set; }
        public string soli_empresa { get; set; }
        public DateTime soli_date { get; set; }


        public string curso_name { get; set; }


        public string curso_programa { get; set; }
        public double curso_version { get; set; }
        #endregion

        
    }
}