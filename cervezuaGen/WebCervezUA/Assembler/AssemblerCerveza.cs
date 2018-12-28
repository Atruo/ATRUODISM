using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CervezUAWeb.Assembler
{
    public class AssemblerCerveza
    {
        public CervezaViewModel ConvertENToModelUI(CervezaEN en)
        {
            CervezaViewModel art = new CervezaViewModel();
            art.id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Imagen = en.Imagen;
            art.Marca = en.Marca;
            art.ValMedia = en.ValMedia;
            art.Stock = en.Stock;
            art.Graduacion = en.Graduacion;
            art.Unidades = en.Unidades;
            art.Volumen = en.Volumen;
            return art;


        }
        public IList<CervezaViewModel> ConvertListENToModel(IList<CervezaEN> ens)
        {
            IList<CervezaViewModel> arts = new List<CervezaViewModel>();
            foreach (CervezaEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}