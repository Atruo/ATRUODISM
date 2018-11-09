
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface ILineaCestaCAD
{
LineaCestaEN ReadOIDDefault (int id
                             );

void ModifyDefault (LineaCestaEN lineaCesta);

System.Collections.Generic.IList<LineaCestaEN> ReadAllDefault (int first, int size);



int New_ (LineaCestaEN lineaCesta);

void Modify (LineaCestaEN lineaCesta);


void Destroy (int id
              );
}
}
