
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
 * Clase Copa:
 *
 */

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial class CopaCAD : BasicCAD, ICopaCAD
{
public CopaCAD() : base ()
{
}

public CopaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CopaEN ReadOIDDefault (int id
                              )
{
        CopaEN copaEN = null;

        try
        {
                SessionInitializeTransaction ();
                copaEN = (CopaEN)session.Get (typeof(CopaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return copaEN;
}

public System.Collections.Generic.IList<CopaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CopaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CopaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CopaEN>();
                        else
                                result = session.CreateCriteria (typeof(CopaEN)).List<CopaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CopaEN copa)
{
        try
        {
                SessionInitializeTransaction ();
                CopaEN copaEN = (CopaEN)session.Load (typeof(CopaEN), copa.Id);

                copaEN.Capacidad = copa.Capacidad;


                copaEN.Forma = copa.Forma;

                session.Update (copaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CopaEN copa)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (copa);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return copa.Id;
}

public void Modify (CopaEN copa)
{
        try
        {
                SessionInitializeTransaction ();
                CopaEN copaEN = (CopaEN)session.Load (typeof(CopaEN), copa.Id);

                copaEN.Nombre = copa.Nombre;


                copaEN.Stock = copa.Stock;


                copaEN.Precio = copa.Precio;


                copaEN.ValMedia = copa.ValMedia;


                copaEN.Descripcion = copa.Descripcion;


                copaEN.Imagen = copa.Imagen;


                copaEN.Marca = copa.Marca;


                copaEN.Capacidad = copa.Capacidad;


                copaEN.Forma = copa.Forma;

                session.Update (copaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
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
                CopaEN copaEN = (CopaEN)session.Load (typeof(CopaEN), id);
                session.Delete (copaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CopaEN
public CopaEN ReadOID (int id
                       )
{
        CopaEN copaEN = null;

        try
        {
                SessionInitializeTransaction ();
                copaEN = (CopaEN)session.Get (typeof(CopaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return copaEN;
}

public System.Collections.Generic.IList<CopaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CopaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CopaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CopaEN>();
                else
                        result = session.CreateCriteria (typeof(CopaEN)).List<CopaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.CopaEN> DevuelvePorTipo (CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum ? tipo)
{
        System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.CopaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CopaEN self where FROM CopaEN where forma = :tipo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CopaENdevuelvePorTipoHQL");
                query.SetParameter ("tipo", tipo);

                result = query.List<CervezUAGenNHibernate.EN.CervezUA.CopaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CopaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
