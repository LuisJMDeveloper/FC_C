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

        public decimal user_id { get; set; }
        public decimal user_nid { get; set; }
        public string user_password { get; set; }
        public string user_name { get; set; }
        public string user_lastname { get; set; }
        public string user_email { get; set; }
        public decimal user_phone { get; set; }
       
    }
}