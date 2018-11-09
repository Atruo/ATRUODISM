
using System;
using System.Text;
using CervezUAGenNHibernate.CEN.CervezUA;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.Exceptions;


/*
 * Clase Pedido:
 *
 */

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial class PedidoCAD : BasicCAD, IPedidoCAD
{
public PedidoCAD() : base ()
{
}

public PedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PedidoEN ReadOIDDefault (int id
                                )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);



                pedidoEN.Estado = pedido.Estado;


                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (pedido.Usuario != null) {
                        // Argumento OID y no colección.
                        pedido.Usuario = (CervezUAGenNHibernate.EN.CervezUA.UsuarioEN)session.Load (typeof(CervezUAGenNHibernate.EN.CervezUA.UsuarioEN), pedido.Usuario.NUsuario);

                        pedido.Usuario.Pedido
                        .Add (pedido);
                }

                session.Save (pedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedido.Id;
}

public void Modify (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);

                pedidoEN.Estado = pedido.Estado;

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), id);
                session.Delete (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PedidoEN
public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> FiltrarPorEstado (CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum ? state)
{
        System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where FROM PedidoEN where estado = :state";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENfiltrarPorEstadoHQL");
                query.SetParameter ("state", state);

                result = query.List<CervezUAGenNHibernate.EN.CervezUA.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
