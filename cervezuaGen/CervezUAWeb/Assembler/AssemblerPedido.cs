
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Models;
using System.Collections.Generic;

namespace CervezUAWeb.Models
{
    public class AssemblerPedido
    {
        public PedidoViewModel ConvertENToModelUI(PedidoEN en)
        {
            PedidoViewModel ped = new PedidoViewModel();
            ped.Id = en.Id;
            ped.Lineas = en.Lineas;
            ped.NUsuaurio = en.Usuario;
            ped.Estado = en.Estado;
            ped.Factura = en.Factura;
            return ped;


        }
        public IList<PedidoViewModel> ConvertListENToModel(IList<PedidoEN> ens)
        {
            IList<PedidoViewModel> peds = new List<PedidoViewModel>();
            foreach (PedidoEN en in ens)
            {
                peds.Add(ConvertENToModelUI(en));
            }
            return peds;
        }

    }
}