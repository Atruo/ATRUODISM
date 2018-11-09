
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface IPedidoCAD
{
PedidoEN ReadOIDDefault (int id
                         );

void ModifyDefault (PedidoEN pedido);

System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size);



int New_ (PedidoEN pedido);

void Modify (PedidoEN pedido);


void Destroy (int id
              );


PedidoEN ReadOID (int id
                  );


System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size);




System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> FiltrarPorEstado (CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum ? state);
}
}
