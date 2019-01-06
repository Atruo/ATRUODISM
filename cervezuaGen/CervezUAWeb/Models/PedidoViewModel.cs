using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Models
{
    public class PedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Usuario con la línea de pedido", Description = "Usuario con la línea de pedido", Name = "Articulos ")]
        public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> Lineas { get; set; }

        [Display(Prompt = "Usuario del pedido", Description = "Usuario del pedido", Name = "Usuario ")]
        public CervezUAGenNHibernate.EN.CervezUA.UsuarioEN Usuario { get; set; }

        [Display(Prompt = "Dirección del pedido", Description = "Dirección del pedido", Name = "Dirección ")]
        [Required(ErrorMessage = "Debe indicar una dirección para el Pedido")]
        [StringLength(maximumLength: 200, ErrorMessage = "La dirección no puede tener más de 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Prompt = "Método de Pago", Description = "Método de Pago", Name = "Método de Pago ")]
        [Required(ErrorMessage = "Debe indicar un Método de Pago")]
        public CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum MPago { get; set; }

        [Display(Prompt = "Importe del pedido", Description = "Importe del pedido", Name = "Importe ")]
        [Required(ErrorMessage = "Debe indicar un Importe para el pedido")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 100000, ErrorMessage = "El importe debe ser mayor que cero y menor de 100000")]
        public double Importe { get; set; }

        [Display(Prompt = "Estado del Pedido", Description = "Estado del Pedido", Name = "Estado ")]
        [Required(ErrorMessage = "Debe indicar un estado")]
        public CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum Estado { get; set; }

  

     
    }
}