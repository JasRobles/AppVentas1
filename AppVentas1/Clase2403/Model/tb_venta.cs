//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clase2403.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_venta()
        {
            this.detalleVenta = new HashSet<detalleVenta>();
        }
    
        public int idVenta { get; set; }
        public int idDocumento { get; set; }
        public int iDCliente { get; set; }
        public int iDUsuario { get; set; }
        public Nullable<decimal> totalVenta { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleVenta> detalleVenta { get; set; }
        public virtual tb_cliente tb_cliente { get; set; }
        public virtual tb_documento tb_documento { get; set; }
        public virtual tb_usuarios tb_usuarios { get; set; }
    }
}