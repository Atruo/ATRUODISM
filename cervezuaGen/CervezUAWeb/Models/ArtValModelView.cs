using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Models
{
    public class ArtValViewModel
    {
        public CervezaViewModel cerveza { get; set;}
        public IEnumerable<ValoracionViewModel> valoraciones { get; set; }
    }
}