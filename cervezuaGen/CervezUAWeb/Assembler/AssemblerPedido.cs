
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
            ped.Importe = en.Importe;
            ped.Estado = en.Estado;
            ped.MPago = en.Attribute;
            ped.Direccion = en.Direccion;


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