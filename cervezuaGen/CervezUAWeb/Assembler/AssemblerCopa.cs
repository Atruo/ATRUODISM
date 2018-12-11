
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Models;
using System.Collections.Generic;

namespace CervezUAWeb.Assembler
{
    public class AssemblerCopa

    {
        public CopaViewModel ConvertENToModelUI(CopaEN en)
        {
            CopaViewModel art = new CopaViewModel();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Imagen = en.Imagen;
            art.Marca = en.Marca;
            art.ValMedia = en.ValMedia;
            art.Stock = en.Stock;
            art.Capacidad = en.Capacidad;
            art.Tipo = en.Forma;

            return art;


        }
        public IList<CopaViewModel> ConvertListENToModel(IList<CopaEN> ens)
        {
            IList<CopaViewModel> arts = new List<CopaViewModel>();
            foreach (CopaEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;

        }
    }
}