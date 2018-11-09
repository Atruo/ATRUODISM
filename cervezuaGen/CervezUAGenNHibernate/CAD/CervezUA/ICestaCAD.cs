
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface ICestaCAD
{
CestaEN ReadOIDDefault (int id
                        );

void ModifyDefault (CestaEN cesta);

System.Collections.Generic.IList<CestaEN> ReadAllDefault (int first, int size);



int New_ (CestaEN cesta);

void Modify (CestaEN cesta);


void Destroy (int id
              );


CestaEN ReadOID (int id
                 );


System.Collections.Generic.IList<CestaEN> ReadAll (int first, int size);
}
}
