using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Models
{
    public class LineaPedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Pedido", Description = "Pedido ", Name = "^Pedido ")]
        [Required(ErrorMessage = "Debe indicar un Pedido")]
        public CervezUAGenNHibernate.EN.CervezUA.PedidoEN Pedido { get; set; }

        [Display(Prompt = "Numero de elementos", Description = "Numero de elementos", Name = "Número ")]
        [Required(ErrorMessage = "Debe indicar un número de elementos")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El número debe ser mayor que cero y menor de 10000")]
        public int Numero { get; set; }

        [Display(Prompt = "Articulo", Description = "Articulo a pedir ", Name = "Articulo ")]
        [Required(ErrorMessage = "Debe indicar un articulo")]
        public CervezUAGenNHibernate.EN.CervezUA.ArticuloEN Articulo { get; set; }
    }
}