
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface IArticuloCAD
{
ArticuloEN ReadOIDDefault (int id
                           );

void ModifyDefault (ArticuloEN articulo);

System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size);



ArticuloEN ReadOID (int id
                    );


System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size);


int New_ (ArticuloEN articulo);

void Modify (ArticuloEN articulo);


void Destroy (int id
              );


System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ArticuloEN> DevuelvePorMarca (string brand);
}
}
