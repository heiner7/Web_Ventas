using Entities;
using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using VentasBackend.DTOs;

namespace WebServices.Controllers
{
    
    [Route("api/")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        IApplication<EncabezadoOrdenVenta> _encabezadoOrdenVenta;
        IApplication<DetalleOrdenVenta> _detalleOrdenVenta;  
        public VentasController(IApplication<EncabezadoOrdenVenta> encabezadoOrdenVenta,
                                    IApplication<DetalleOrdenVenta> detalleOrdenVenta)
        {
            _encabezadoOrdenVenta = encabezadoOrdenVenta;
            _detalleOrdenVenta = detalleOrdenVenta;
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(EncabezadoOrdenVenta), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("Ventas/ObtenerOrdenVenta/{cedula:long}")]
        public IActionResult ObtenerOrdenVenta(long cedula)
        {
            return _encabezadoOrdenVenta.GetById(cedula, "EncabezadoOrdenVentas").Count > 0 ? Ok(_encabezadoOrdenVenta.GetById(cedula, "EncabezadoOrdenVentas")) : NoContent();
        }

        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(DetalleOrdenVenta), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 204NoContent.
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("Ventas/ObtenerDetallesOrdenVenta/{id:int}")]
        public IActionResult ObtenerDetalleOrdenVenta(int id)
        {
            return _detalleOrdenVenta.GetDetalleOrdenVenta(id).Count > 0 ? Ok(_detalleOrdenVenta.GetDetalleOrdenVenta(id)) : NoContent();
        }

        //Con esto se seguriza el controlador
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 200OK.
        [ProducesResponseType(typeof(DetalleOrdenVenta), StatusCodes.Status200OK)]
        //indica que el método de acción puede devolver una respuesta HTTP con el código de estado 400BadRequest.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [Route("Ventas/GuardarDetalleOrdenVenta")]
        public IActionResult Save(DetalleOrdenVentaDTO dto)
        {
            var f = new DetalleOrdenVenta()
            {
                OrdenVentaId = dto.OrdenVentaId,
                IdProducto = dto.IdProducto,
                NombreProducto = dto.NombreProducto,
                Unidad = dto.Unidad,
                PrecioUnitario = dto.PrecioUnitario,
                PorcentajeImpuesto = dto.PorcentajeImpuesto,
                PrecioImpuestoUnitario = dto.PrecioImpuestoUnitario,
                Cantidad = dto.Cantidad,
                PrecioTotalImpuestos = dto.PrecioTotalImpuestos
            };

            return Ok(_detalleOrdenVenta.Save(f));           
        }       

    }
}
