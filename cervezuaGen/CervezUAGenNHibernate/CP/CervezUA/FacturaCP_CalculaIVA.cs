
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;



/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CP.CervezUA_Factura_calculaIVA) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CP.CervezUA
{
public partial class FacturaCP : BasicCP
{
public void CalculaIVA (double iva, int pedido, int p_oid)
{
        /*PROTECTED REGION ID(CervezUAGenNHibernate.CP.CervezUA_Factura_calculaIVA) ENABLED START*/

        IFacturaCAD facturaCAD = null;
        FacturaCEN facturaCEN = null;
        PedidoCEN pedido_a_tratar = null;




        try
        {
                SessionInitializeTransaction ();
                facturaCAD = new FacturaCAD (session);
                facturaCEN = new  FacturaCEN (facturaCAD);
                FacturaEN factura = facturaCEN.ReadOID(p_oid);

                double precio_sinIVA = pedido_a_tratar.CalculaPrecio(pedido);
                precio_sinIVA = precio_sinIVA * iva;

                factura.Importe = precio_sinIVA;
                     

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
