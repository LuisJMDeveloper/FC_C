using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FC_CIP.Models;

namespace FC_CIP.Models.TablasCombinadas
{
    public class UsuarioInstructor
    {
        /* @us_nid numeric,
           @us_password varchar(250),
           @us_name varchar(30),
           @us_lastname varchar(30),
           @us_email varchar(60),
           @us_phone numeric
        */

        public decimal us_id { get; set; }
        public decimal us_nid { get; set; }
        public string us_password { get; set; }
        public string us_name { get; set; }
        public string us_lastname { get; set; }
        public string us_email { get; set; }
        public decimal us_phone { get; set; }
       
    }
}