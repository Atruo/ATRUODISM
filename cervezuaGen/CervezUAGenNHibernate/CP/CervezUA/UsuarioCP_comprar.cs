
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
public void Comprar (string p_oid, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> linea)
{
        /*PROTECTED REGION ID(CervezUAGenNHibernate.CP.CervezUA_Usuario_comprar) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new PedidoCEN (pedidoCAD);

                PedidoEN pedido = new PedidoEN ();

                //pedidoCEN.New_ (p_oid, (Enumerated.CervezUA.EstadoPedidoEnum) 0);
                foreach (var item in linea) {
                        ArticuloCAD art = new ArticuloCAD (session);
                        ArticuloCEN articulo = new ArticuloCEN (art);
                        ArticuloEN a = art.ReadOIDDefault (item.Articulo.Id);

                        articulo.Modify (a.Id, a.Nombre, a.Stock - item.Numero, a.Precio, a.ValMedia, a.Descripcion, a.Imagen, a.Marca);
                }



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
