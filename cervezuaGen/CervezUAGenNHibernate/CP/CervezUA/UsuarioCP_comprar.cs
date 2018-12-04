
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



/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CP.CervezUA_Usuario_comprar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CP.CervezUA
{
public partial class UsuarioCP : BasicCP
{
public void Comprar (string p_oid, int idPedido, CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum pago, string dirEnvio)
{
        /*PROTECTED REGION ID(CervezUAGenNHibernate.CP.CervezUA_Usuario_comprar) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        PedidoCEN pedidoCEN = null;
        FacturaCEN facturaCEN = null;
        ArticuloCEN articuloCEN = null;




        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                PedidoCAD pedidoCAD = new PedidoCAD (session);
                ArticuloCAD articuloCAD = new ArticuloCAD (session);
                PedidoEN pedido = pedidoCAD.ReadOIDDefault (idPedido);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                double importe = 0;

                foreach (LineaPedidoEN l in pedido.Lineas) {
                        ArticuloEN articulo = l.Articulo;
                        articuloCEN = new ArticuloCEN (articuloCAD);
                        articuloCEN.DecrementaStock (articulo.Id, l.Numero);
                        importe += l.Numero * l.Articulo.Precio;
                }

                pedido.Estado = (Enumerated.CervezUA.EstadoPedidoEnum) 1;
                //FacturaEN factura = new FacturaEN (pedido,importe, dirEnvio, pago);
                facturaCEN = new FacturaCEN ();
                facturaCEN.New_ (pedido.Id, importe, dirEnvio, pago);


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
