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
    
    public partial class ImpresorasCategorias
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
        public System.DateTime CreateAt { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
        public Nullable<System.DateTime> DeleteAt { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Impresoras Impresora { get; set; }
        public virtual Salones Salon { get; set; }
    }
}
