using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Models
{
    public class FacturaViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Importe de la factura", Description = "Importe de la factura", Name = "Importe ")]
        [Required(ErrorMessage = "Debe indicar el importe de la factura")]
        public int Pedido { get; set; }

        [Display(Prompt = "Importe de la factura", Description = "Importe de la factura", Name = "Importe ")]
        [Required(ErrorMessage = "Debe indicar el importe de la factura")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public double Importe { get; set; }

        [Display(Prompt = "Direccion de la factura", Description = "Direccion de la factura", Name = "Direccion ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Prompt = "Metodo de pago de la factura", Description = "Metodo de pago de la factura", Name = "MetodoPago ")]
        [Required(ErrorMessage = "Debe indicar un estado")]
        public CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum MetodoPago { get; set; }
    }
}