using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Models;
using System.Collections.Generic;

namespace CervezUAWeb.Assembler
{
    public class AssemblerFactura
    {
        public FacturaViewModel ConvertENToModelUI(FacturaEN en)
        {
            FacturaViewModel fac = new FacturaViewModel();
            fac.id = en.Id;
            fac.Pedido = en.Pedido.Id;
            fac.Importe = en.Importe;
            fac.Direccion = en.Direccion;
            fac.MetodoPago = en.MetodoPago;
            return fac;


        }
        public IList<FacturaViewModel> ConvertListENToModel(IList<FacturaEN> ens)
        {
            IList<FacturaViewModel> facs = new List<FacturaViewModel>();
            foreach (FacturaEN en in ens)
            {
                facs.Add(ConvertENToModelUI(en));
            }
            return facs;
        }

    }
}