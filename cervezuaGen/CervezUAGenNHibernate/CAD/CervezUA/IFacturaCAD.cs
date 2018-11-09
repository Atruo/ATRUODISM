
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface IFacturaCAD
{
FacturaEN ReadOIDDefault (int id
                          );

void ModifyDefault (FacturaEN factura);

System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size);



int New_ (FacturaEN factura);

void Modify (FacturaEN factura);


void Destroy (int id
              );



FacturaEN ReadOID (int id
                   );


System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size);
}
}
