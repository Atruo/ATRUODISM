
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


/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CEN.CervezUA_Usuario_toAdmin) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CEN.CervezUA
{
    public partial class UsuarioCEN
    {
        public void ToAdmin(string p_oid, bool admin)
        {
            UsuarioCEN usuCEN = new UsuarioCEN();
            UsuarioEN usu = usuCEN.ReadOID(p_oid);
            if (admin)
            {
                usu.Tipo = (Enumerated.CervezUA.TipoUsuarioEnum)3;
            }
            else
            {
                usu.Tipo = (Enumerated.CervezUA.TipoUsuarioEnum)1;
            }
            _IUsuarioCAD.Modify(usu);

        }
    }
}

