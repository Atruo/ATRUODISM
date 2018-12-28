using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Models
{
    public class ValoracionViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Articulo a valorar", Description = "Articulo a valorar", Name = "Articulo a valorar ")]
        [Required(ErrorMessage = "SE necesita saber el artículo a valorar.")]
        [StringLength(maximumLength: 100, ErrorMessage = "el texto es demasiado largo")]
        public int Articulo { get; set; }

        [Display(Prompt = "usuario", Description = "usuario creador de la valoracion ", Name = "Usuario")]
        [Required(ErrorMessage = "se necesira un usuario")]
        [StringLength(maximumLength: 100, ErrorMessage = "el texto es demasiado largo")]
        public string Usuario { get; set; }

        [Display(Prompt = "Valoracion", Description = "Valoracion ", Name = "Valoracion ")]
        [Required(ErrorMessage = "Debe tener una valoracion")]
        //[Range(minimum: 0, maximum: 5, ErrorMessage = "Se debe valorar del 0 al 5")]
        public double Valoracion { get; set; }



        [Display(Prompt = "Texto", Description = "Explicacion de la valoracion ", Name = "Texto")]
        [Required(ErrorMessage = "Se necesita un texto")]
        [StringLength(maximumLength: 5000, ErrorMessage = "el texto es demasiado largo")]
        public String Texto { get; set; }
    }
}