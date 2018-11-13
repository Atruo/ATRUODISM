
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


/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CEN.CervezUA_Factura_calculaIVA) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CEN.CervezUA
{
public partial class FacturaCEN
{
public void CalculaIVA (int p_oid, double iva)
{
        /*PROTECTED REGION ID(CervezUAGenNHibernate.CEN.CervezUA_Factura_calculaIVA) ENABLED START*/
        FacturaEN factura = ReadOID (p_oid);
        double precio = PedidoCEN_CalculaPrecio (factura.Pedido.Id);

        precio = precio * iva;

        factura.Importe = precio;
        /*PROTECTED REGION END*/
}
}
}
