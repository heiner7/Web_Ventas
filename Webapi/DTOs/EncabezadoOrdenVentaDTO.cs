using System.ComponentModel.DataAnnotations;
using System;

namespace VentasBackend.DTOs
{
    public class EncabezadoOrdenVentaDTO
    {
        public int Id { get; set; }
        public int PersonaCedula { get; set; }
        public string IdSupermercado { get; set; }
        public string MetodoPago { get; set; }
        public decimal TipoCambio { get; set; }
        public DateTime FechaOrden { get; set; }
    }
}
