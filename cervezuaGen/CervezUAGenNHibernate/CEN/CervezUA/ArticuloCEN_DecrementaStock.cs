
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


/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CEN.CervezUA_Articulo_decrementaStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CEN.CervezUA
{
public partial class ArticuloCEN
{
public void DecrementaStock (int p_oid, int arg1)
{
        /*PROTECTED REGION ID(CervezUAGenNHibernate.CEN.CervezUA_Articulo_decrementaStock) ENABLED START*/

        ArticuloEN articulo = _IArticuloCAD.ReadOIDDefault (p_oid);

        articulo.Stock -= arg1;
        _IArticuloCAD.Modify (articulo);

        /*PROTECTED REGION END*/
}
}
}
