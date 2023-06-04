using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DetalleOrdenVenta : Entity
    {
        public int OrdenVentaId { get; set; }
        //public EncabezadoOrdenVenta OrdenVenta { get; set; }
        public int IdProducto { get; set; }
        [StringLength(60)]
        public string NombreProducto { get; set; }
        public string Unidad { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeImpuesto { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal PrecioImpuestoUnitario { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioTotalImpuestos { get; set; }
    }

}
