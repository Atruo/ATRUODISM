using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Models
{
    public class ArticuloViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public double ValMedia { get; set; }

        [Display(Prompt = "Nombre del artículo", Description = "Nombre del artículo", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del artículo", Description = "Precio del artículo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Stock incial del artículo", Description = "Stock incial del artículo", Name = "Stock ")]
        [Required(ErrorMessage = "Debe indicar un stock para el artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El stock debe ser un valor entero")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El stock debe ser mayor que cero y menor de 10000")]
        public int Stock { get; set; }

        [Display(Prompt = "Descripción del artículo", Description = "Descripción del artículo", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Marca del artículo", Description = "Marca del artículo", Name = "Marca ")]
        [Required(ErrorMessage = "Debe indicar una marca para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "La marca no puede tener más de 200 caracteres")]
        public string Marca { get; set; }

        [Display(Prompt = "Imagen del artículo", Description = "Unidades del artículo", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public string Imagen { get; set; }
    }
}