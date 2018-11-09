
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface ICervezaCAD
{
CervezaEN ReadOIDDefault (int id
                          );

void ModifyDefault (CervezaEN cerveza);

System.Collections.Generic.IList<CervezaEN> ReadAllDefault (int first, int size);



int New_ (CervezaEN cerveza);

void Modify (CervezaEN cerveza);


void Destroy (int id
              );


CervezaEN ReadOID (int id
                   );


System.Collections.Generic.IList<CervezaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.CervezaEN> DevulevePorTipo (CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum ? arg0);
}
}
