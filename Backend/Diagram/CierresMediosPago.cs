//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diagram
{
    using System;
    using System.Collections.Generic;
    
    public partial class CierresMediosPago
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public bool Gasto { get; set; }
        public int CierreId { get; set; }
        public int MedioPagoId { get; set; }
        public bool Activo { get; set; }
        public System.DateTime CreateAt { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
        public Nullable<System.DateTime> DeleteAt { get; set; }
    
        public virtual Cierre Cierre { get; set; }
        public virtual MediosPago MediosPago { get; set; }
    }
}
