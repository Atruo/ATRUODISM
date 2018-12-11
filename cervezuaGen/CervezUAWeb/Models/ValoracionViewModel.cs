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

        [Display(Prompt = "usuario", Description = "usuario creador de la valoracion ", Name = "usuario")]
        [Required(ErrorMessage = "se necesira un usuario")]
        [StringLength(maximumLength: 100, ErrorMessage = "el texto es demasiado largo")]
        public CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario { get; set; }

        [Display(Prompt = "Valoracion", Description = "Valoracion ", Name = "Valor")]
        [Required(ErrorMessage = "Debe tener una valoracion")]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "Se debe valorar del 1 al 5")]
        public double Valoracion { get; set; }



        [Display(Prompt = "Texto", Description = "Explicacion de la valoracion ", Name = "Texto")]
        [Required(ErrorMessage = "Se necesita un texto")]
        [StringLength(maximumLength: 5000, ErrorMessage = "el texto es demasiado largo")]
        public String texto { get; set; }
    }
}