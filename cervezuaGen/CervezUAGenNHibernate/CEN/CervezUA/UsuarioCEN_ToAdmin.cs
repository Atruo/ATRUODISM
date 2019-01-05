
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
        public void ToAdmin(string p_oid, int tipo)
        {
            UsuarioCEN usuCEN = new UsuarioCEN();
            UsuarioEN usu = usuCEN.ReadOID(p_oid);
           
                usu.Tipo = (Enumerated.CervezUA.TipoUsuarioEnum)tipo;
             
            
            _IUsuarioCAD.Modify(usu);

        }
    }
}

