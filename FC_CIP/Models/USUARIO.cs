//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FC_CIP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        public decimal userId { get; set; }
        public Nullable<decimal> usua_nid { get; set; }
        public string user_password { get; set; }
        public Nullable<int> user_type { get; set; }
        public string userName { get; set; }
        public string user_lastname { get; set; }
        public string user_email { get; set; }
        public Nullable<decimal> user_phone { get; set; }
        public Nullable<bool> user_restore { get; set; }
        public Nullable<System.DateTime> us_date { get; set; }
    
        public virtual COORDINADOR COORDINADOR { get; set; }
        public virtual INSTRUCTOR INSTRUCTOR { get; set; }
    }
}
