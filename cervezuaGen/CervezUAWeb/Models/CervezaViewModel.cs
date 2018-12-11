using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Models
{
    public class CervezaViewModel
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

        [Display(Prompt = "Volumen del artículo", Description = "Volumen incial del artículo", Name = "Volumen ")]
        [Required(ErrorMessage = "Debe indicar un volumen para el artículo")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El volumen debe ser mayor que cero y menor de 10000")]
        public double Volumen { get; set; }

        [Display(Prompt = "Unidades del artículo", Description = "Unidades del artículo", Name = "Unidades ")]
        [Required(ErrorMessage = "Debe indicar una cantidad para el artículo")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "La cantidad debe ser mayor que cero y menor de 10000")]
        public int Unidades { get; set; }

        [Display(Prompt = "Graduación de la cerveza", Description = "Graduación de la cerveza", Name = "Graduación ")]
        [Required(ErrorMessage = "Debe indicar una graduación para la cerveza")]
        [Range(minimum: 0, maximum: 15, ErrorMessage = "La graduación debe ser mayor que cero y menor de 15")]
        public double Graduacion { get; set; }

        [Display(Prompt = "Tipo de cerveza", Description = "Tipo de cerveza", Name = "Tipo ")]
        [Required(ErrorMessage = "Debe indicar un tipo de cerveza")]
        public CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum Tipo { get; set; }

    }
}