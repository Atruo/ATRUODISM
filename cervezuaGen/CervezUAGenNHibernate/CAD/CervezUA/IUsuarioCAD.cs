
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string nUsuario
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string nUsuario
              );


UsuarioEN ReadOID (string nUsuario
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


long DevuelveTipo (long tipo);
}
}
