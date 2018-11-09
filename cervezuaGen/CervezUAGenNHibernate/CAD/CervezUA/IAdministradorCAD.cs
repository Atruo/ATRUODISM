
using System;
using CervezUAGenNHibernate.EN.CervezUA;

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string nUsuario
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



string New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (string nUsuario
              );


AdministradorEN ReadOID (string nUsuario
                         );


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);
}
}
