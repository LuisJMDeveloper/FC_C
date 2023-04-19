using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FC_CIP.Models.TablasCombinadas
{
    public class SolicitudCurso
    {
        [Required]
        public decimal co_id { get; set; }
        [Required]
        public decimal in_id { get; set; }

        [Required]
        [StringLength(255)]
        public string so_type { get; set; }
        [StringLength(200)]
        public string so_ente { get; set; }

        [Required]
        public decimal pf_id { get; set; }
        public decimal pe_id { get; set; }
                            
        [Required]
        public decimal lu_id { get; set; }
        [Required]
        public decimal am_id { get; set; }

        [Required]
        public int cu_code { get; set; }
        [Required]
        [StringLength(100)]
        public string cu_name { get; set; }
        [Required]
        public int cu_cupoMax { get; set; }
        [Required]
        public int cu_duration { get; set; }
        public DateTime cu_startdate { get; set; }
        public DateTime cu_enddate { get; set; }
        [Required]
        [StringLength(255)]
        public string cu_note { get; set; }
        [Required]
        [StringLength(200)]
        public string cu_days { get; set; }
    }
}