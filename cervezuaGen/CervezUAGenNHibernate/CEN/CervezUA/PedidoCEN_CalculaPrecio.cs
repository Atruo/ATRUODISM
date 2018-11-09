
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


/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CEN.CervezUA_Pedido_calculaPrecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CEN.CervezUA
{
public partial class PedidoCEN
{
public double CalculaPrecio (int p_oid)
{
        /*PROTECTED REGION ID(CervezUAGenNHibernate.CEN.CervezUA_Pedido_calculaPrecio) ENABLED START*/
        double devuelve = 0;
        // Write here your custom code...
        PedidoEN pedido = ReadOID (p_oid);

        foreach (LineaPedidoEN linea in pedido.Lineas) {
                devuelve += linea.Articulo.Precio * linea.Numero;
        }
        return devuelve;

        /*PROTECTED REGION END*/
}
}
}
