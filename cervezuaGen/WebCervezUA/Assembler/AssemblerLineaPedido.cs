
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Models;
using System.Collections.Generic;

namespace CervezUAWeb.Assembler

{
    public class AssemblerLineaPedido

    {
        public LineaPedidoViewModel ConvertENToModelUI(LineaPedidoEN en)
        {
            LineaPedidoViewModel lin = new LineaPedidoViewModel();
            lin.id = en.Id;
            lin.Numero = en.Numero;
            lin.Articulo = en.Articulo;


            return lin;


        }

        public IList<LineaPedidoViewModel> ConvertListENToModel(IList<LineaPedidoEN> ens)
        {
            IList<LineaPedidoViewModel> lin = new List<LineaPedidoViewModel>();
            foreach (LineaPedidoEN en in ens)
            {
                lin.Add(ConvertENToModelUI(en));
            }
            return lin;

        }

    }
}