
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


/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CEN.CervezUA_Usuario_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CEN.CervezUA
{
public partial class UsuarioCEN
{
public string Login (string p_Usuario_OID, string p_pass)
{
        /*PROTECTED REGION ID(CervezUAGenNHibernate.CEN.CervezUA_Usuario_login) ENABLED START*/
        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_Usuario_OID);

        if (en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.NUsuario);

        return result;
        /*PROTECTED REGION END*/
}
}
}
