using ApiRest.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Persona : Entity
    {
        [StringLength(12)]
        public long Cedula { get; set; }
        [StringLength(150)]
        public string Direccion { get; set; }
        [StringLength(12)]
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [StringLength(2)]
        public string Genero { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string PrimerApellido { get; set; }
        [StringLength(30)]
        public string SegundoApellido { get; set; }
        [StringLength(60)]
        public string CorreoElectronico { get; set; }
    }

}
