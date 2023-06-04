using ApiRest.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EncabezadoOrdenVenta: Entity
    {
        public long Cedula { get; set; }
        //public Persona Persona { get; set; }
        [StringLength(30)]
        public string IdSupermercado { get; set; }
        [StringLength(9)]
        public string MetodoPago { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal TipoCambio { get; set; }
        public DateTime FechaOrden { get; set; } = DateTime.Now;
    }

}
