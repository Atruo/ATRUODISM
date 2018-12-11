using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Models
{
    public class UsuarioViewModel
    {


        [Display(Prompt = "Nombre de usuario", Description = "Nombre de usuario", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string NUsuario { get; set; }

        [Display(Prompt = "Correo electrónico", Description = "Correo electrónico", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar un email")]
        [StringLength(maximumLength: 200, ErrorMessage = "El email no puede tener más de 200 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Fecha de nacimiento", Description = "Fecha de nacimiento", Name = "Fecha de nacimiento ")]
        [Required(ErrorMessage = "Debe indicar una fecha de nacimiento")]
        public DateTime? FecNam { get; set; }

        [Display(Prompt = "Nombre real", Description = "Nombre real", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Apellidos", Description = "Apellidos", Name = "Apellidos ")]
        [Required(ErrorMessage = "Debe indicar un apellido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El apellido no puede tener más de 200 caracteres")]
        public string Apellidos { get; set; }

        [Display(Prompt = "Foto", Description = "Foto", Name = "Foto ")]
        [Required(ErrorMessage = "Debe añadir una foto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre de la foto no puede tener más de 200 caracteres")]
        public string Foto { get; set; }

        [Display(Prompt = "Tipo de usuario", Description = "Tipo de usuario", Name = "Tipo de usuario ")]
        [Required(ErrorMessage = "Debe añadir un tipo")]

        public CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum Tipo { get; set; }

        [Display(Prompt = "Contraseña", Description = "Contraseña", Name = "Contraseña ")]
        [Required(ErrorMessage = "Debe indicar una contraseña")]
        [StringLength(maximumLength: 200, ErrorMessage = "La contraseña no puede tener más de 200 caracteres")]
        public string Password { get; set; }
    }
}