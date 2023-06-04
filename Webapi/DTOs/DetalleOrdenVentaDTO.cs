using Entities;
using System.ComponentModel.DataAnnotations;

namespace VentasBackend.DTOs
{
    public class DetalleOrdenVentaDTO
    {
        public int Id { get; set; }
        public int OrdenVentaId { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Unidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PorcentajeImpuesto { get; set; }
        public decimal PrecioImpuestoUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotalImpuestos { get; set; }
    }
}
