﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FC_CIP_BDEntities : DbContext
    {
        public FC_CIP_BDEntities()
            : base("name=FC_CIP_BDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTIVIDAD> ACTIVIDAD { get; set; }
        public virtual DbSet<AMBIENTE> AMBIENTE { get; set; }
        public virtual DbSet<COORDINADORA> COORDINADORA { get; set; }
        public virtual DbSet<INSTRUCTOR> INSTRUCTOR { get; set; }
        public virtual DbSet<LOCACION> LOCACION { get; set; }
        public virtual DbSet<PROGRAMA_ESPECIAL> PROGRAMA_ESPECIAL { get; set; }
        public virtual DbSet<REPORTE> REPORTE { get; set; }
        public virtual DbSet<SOLICITUD> SOLICITUD { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<PROGRAMA_FORMACION> PROGRAMA_FORMACION { get; set; }
        public virtual DbSet<ACTIVIDAD2> ACTIVIDAD2 { get; set; }
        public virtual DbSet<CURSO2> CURSO2 { get; set; }
        public virtual DbSet<CURSO> CURSO { get; set; }
    
        public virtual ObjectResult<Nullable<int>> saveUserValidation(Nullable<decimal> us_nid, string us_password, string us_name, string us_lastname, string us_email, Nullable<decimal> us_phone)
        {
            var us_nidParameter = us_nid.HasValue ?
                new ObjectParameter("us_nid", us_nid) :
                new ObjectParameter("us_nid", typeof(decimal));
    
            var us_passwordParameter = us_password != null ?
                new ObjectParameter("us_password", us_password) :
                new ObjectParameter("us_password", typeof(string));
    
            var us_nameParameter = us_name != null ?
                new ObjectParameter("us_name", us_name) :
                new ObjectParameter("us_name", typeof(string));
    
            var us_lastnameParameter = us_lastname != null ?
                new ObjectParameter("us_lastname", us_lastname) :
                new ObjectParameter("us_lastname", typeof(string));
    
            var us_emailParameter = us_email != null ?
                new ObjectParameter("us_email", us_email) :
                new ObjectParameter("us_email", typeof(string));
    
            var us_phoneParameter = us_phone.HasValue ?
                new ObjectParameter("us_phone", us_phone) :
                new ObjectParameter("us_phone", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("saveUserValidation", us_nidParameter, us_passwordParameter, us_nameParameter, us_lastnameParameter, us_emailParameter, us_phoneParameter);
        }
    
        public virtual ObjectResult<GetUserType_Result> GetUserType(Nullable<decimal> us_nid, string us_password)
        {
            var us_nidParameter = us_nid.HasValue ?
                new ObjectParameter("us_nid", us_nid) :
                new ObjectParameter("us_nid", typeof(decimal));
    
            var us_passwordParameter = us_password != null ?
                new ObjectParameter("us_password", us_password) :
                new ObjectParameter("us_password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserType_Result>("GetUserType", us_nidParameter, us_passwordParameter);
        }
    
        public virtual ObjectResult<getSolicitudesRecibidas_Result> getSolicitudesRecibidas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSolicitudesRecibidas_Result>("getSolicitudesRecibidas");
        }
    
        public virtual ObjectResult<getSolicitudes_Result> getSolicitudes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSolicitudes_Result>("getSolicitudes");
        }
    
        public virtual int RegistrarUsuario(Nullable<decimal> us_nid, string us_password, string us_name, string us_lastname, string us_email, Nullable<decimal> us_phone, ObjectParameter mensaje, ObjectParameter resultado)
        {
            var us_nidParameter = us_nid.HasValue ?
                new ObjectParameter("us_nid", us_nid) :
                new ObjectParameter("us_nid", typeof(decimal));
    
            var us_passwordParameter = us_password != null ?
                new ObjectParameter("us_password", us_password) :
                new ObjectParameter("us_password", typeof(string));
    
            var us_nameParameter = us_name != null ?
                new ObjectParameter("us_name", us_name) :
                new ObjectParameter("us_name", typeof(string));
    
            var us_lastnameParameter = us_lastname != null ?
                new ObjectParameter("us_lastname", us_lastname) :
                new ObjectParameter("us_lastname", typeof(string));
    
            var us_emailParameter = us_email != null ?
                new ObjectParameter("us_email", us_email) :
                new ObjectParameter("us_email", typeof(string));
    
            var us_phoneParameter = us_phone.HasValue ?
                new ObjectParameter("us_phone", us_phone) :
                new ObjectParameter("us_phone", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarUsuario", us_nidParameter, us_passwordParameter, us_nameParameter, us_lastnameParameter, us_emailParameter, us_phoneParameter, mensaje, resultado);
        }
    
        public virtual ObjectResult<Nullable<decimal>> SaveSolicitudCurso(Nullable<decimal> co_id, Nullable<decimal> in_id, string so_type, string so_ente, Nullable<decimal> pf_id, Nullable<decimal> pe_id, Nullable<decimal> lu_id, Nullable<decimal> am_id, Nullable<int> cu_code, string cu_name, Nullable<int> cu_cupoMax, Nullable<int> cu_duration, Nullable<System.DateTime> cu_startdate, Nullable<System.DateTime> cu_enddate, string cu_note, string cu_days)
        {
            var co_idParameter = co_id.HasValue ?
                new ObjectParameter("co_id", co_id) :
                new ObjectParameter("co_id", typeof(decimal));
    
            var in_idParameter = in_id.HasValue ?
                new ObjectParameter("in_id", in_id) :
                new ObjectParameter("in_id", typeof(decimal));
    
            var so_typeParameter = so_type != null ?
                new ObjectParameter("so_type", so_type) :
                new ObjectParameter("so_type", typeof(string));
    
            var so_enteParameter = so_ente != null ?
                new ObjectParameter("so_ente", so_ente) :
                new ObjectParameter("so_ente", typeof(string));
    
            var pf_idParameter = pf_id.HasValue ?
                new ObjectParameter("pf_id", pf_id) :
                new ObjectParameter("pf_id", typeof(decimal));
    
            var pe_idParameter = pe_id.HasValue ?
                new ObjectParameter("pe_id", pe_id) :
                new ObjectParameter("pe_id", typeof(decimal));
    
            var lu_idParameter = lu_id.HasValue ?
                new ObjectParameter("lu_id", lu_id) :
                new ObjectParameter("lu_id", typeof(decimal));
    
            var am_idParameter = am_id.HasValue ?
                new ObjectParameter("am_id", am_id) :
                new ObjectParameter("am_id", typeof(decimal));
    
            var cu_codeParameter = cu_code.HasValue ?
                new ObjectParameter("cu_code", cu_code) :
                new ObjectParameter("cu_code", typeof(int));
    
            var cu_nameParameter = cu_name != null ?
                new ObjectParameter("cu_name", cu_name) :
                new ObjectParameter("cu_name", typeof(string));
    
            var cu_cupoMaxParameter = cu_cupoMax.HasValue ?
                new ObjectParameter("cu_cupoMax", cu_cupoMax) :
                new ObjectParameter("cu_cupoMax", typeof(int));
    
            var cu_durationParameter = cu_duration.HasValue ?
                new ObjectParameter("cu_duration", cu_duration) :
                new ObjectParameter("cu_duration", typeof(int));
    
            var cu_startdateParameter = cu_startdate.HasValue ?
                new ObjectParameter("cu_startdate", cu_startdate) :
                new ObjectParameter("cu_startdate", typeof(System.DateTime));
    
            var cu_enddateParameter = cu_enddate.HasValue ?
                new ObjectParameter("cu_enddate", cu_enddate) :
                new ObjectParameter("cu_enddate", typeof(System.DateTime));
    
            var cu_noteParameter = cu_note != null ?
                new ObjectParameter("cu_note", cu_note) :
                new ObjectParameter("cu_note", typeof(string));
    
            var cu_daysParameter = cu_days != null ?
                new ObjectParameter("cu_days", cu_days) :
                new ObjectParameter("cu_days", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("SaveSolicitudCurso", co_idParameter, in_idParameter, so_typeParameter, so_enteParameter, pf_idParameter, pe_idParameter, lu_idParameter, am_idParameter, cu_codeParameter, cu_nameParameter, cu_cupoMaxParameter, cu_durationParameter, cu_startdateParameter, cu_enddateParameter, cu_noteParameter, cu_daysParameter);
        }
    }
}
