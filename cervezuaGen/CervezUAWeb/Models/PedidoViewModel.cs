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

        [ScaffoldColumn(false)]
        public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> Lineas { get; set; }

        [Display(Prompt = "Usuario con la línea de pedido", Description = "Usuario con la línea de pedido", Name = "Nombre usuario ")]
        public CervezUAGenNHibernate.EN.CervezUA.UsuarioEN NUsuaurio { get; set; }

        [Display(Prompt = "Estado del Pedido", Description = "Estado del Pedido", Name = "Estado ")]
        [Required(ErrorMessage = "Debe indicar un estado")]
        public CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum Estado { get; set; }

        [Display(Prompt = "Factura del Pedido", Description = "Factura del Pedido", Name = "Factura ")]
        public CervezUAGenNHibernate.EN.CervezUA.FacturaEN Factura { get; set; }

     
    }
}