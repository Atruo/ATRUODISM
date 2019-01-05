
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using CervezUAGenNHibernate.Exceptions;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.CAD.CervezUA;


/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CEN.CervezUA_Usuario_editar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CEN.CervezUA
{
public partial class UsuarioCEN
{
public void Editar (CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usu, string id, string foto)
{
            UsuarioCEN usuCEN = new UsuarioCEN();
            UsuarioEN compr = usuCEN.ReadOID(id);

            if (compr.NUsuario != usu.NUsuario)
            {
                compr.NUsuario = usu.NUsuario;
            }
            if (compr.Email != usu.Email)
            {
                compr.Email = usu.Email;
            }
            if (compr.Nombre != usu.Nombre)
            {
                compr.Nombre = usu.Nombre;
            }
            if (compr.FecNam != usu.FecNam)
            {
                compr.FecNam = usu.FecNam;
            }
            if (foto != "" && compr.Foto != foto)
            {                
                compr.Foto = foto;
            }
            if (compr.Apellidos != usu.Apellidos)
            {
                compr.Apellidos = usu.Apellidos;
            }
            if (compr.Pass != usu.Pass)
            {
                compr.Pass = usu.Pass;
            }
            _IUsuarioCAD.Modify(usu);
        }
}
}
