
using CervezUAGenNHibernate.EN.CervezUA;
using System.Collections.Generic;

namespace CervezUAWeb.Models
{
    public class AssemblerArticulo
    {
        public ArticuloViewModel ConvertENToModelUI(ArticuloEN en)
        {
            ArticuloViewModel art = new ArticuloViewModel();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Imagen = en.Imagen;
            art.Marca = en.Marca;
            art.ValMedia = en.ValMedia;
            art.Stock = en.Stock;
            return art;


        }
        public IList<ArticuloViewModel> ConvertListENToModel(IList<ArticuloEN> ens)
        {
            IList<ArticuloViewModel> arts = new List<ArticuloViewModel>();
            foreach (ArticuloEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }

    }
}