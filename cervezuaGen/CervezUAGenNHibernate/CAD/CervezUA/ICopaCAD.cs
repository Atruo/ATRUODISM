
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface ICopaCAD
{
CopaEN ReadOIDDefault (int id
                       );

void ModifyDefault (CopaEN copa);

System.Collections.Generic.IList<CopaEN> ReadAllDefault (int first, int size);



int New_ (CopaEN copa);

void Modify (CopaEN copa);


void Destroy (int id
              );


CopaEN ReadOID (int id
                );


System.Collections.Generic.IList<CopaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.CopaEN> DevuelvePorTipo (CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum ? tipo);
}
}
