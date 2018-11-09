
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
 * Clase Cerveza:
 *
 */

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial class CervezaCAD : BasicCAD, ICervezaCAD
{
public CervezaCAD() : base ()
{
}

public CervezaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CervezaEN ReadOIDDefault (int id
                                 )
{
        CervezaEN cervezaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cervezaEN = (CervezaEN)session.Get (typeof(CervezaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cervezaEN;
}

public System.Collections.Generic.IList<CervezaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CervezaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CervezaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CervezaEN>();
                        else
                                result = session.CreateCriteria (typeof(CervezaEN)).List<CervezaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CervezaEN cerveza)
{
        try
        {
                SessionInitializeTransaction ();
                CervezaEN cervezaEN = (CervezaEN)session.Load (typeof(CervezaEN), cerveza.Id);

                cervezaEN.Volumen = cerveza.Volumen;


                cervezaEN.Unidades = cerveza.Unidades;


                cervezaEN.Graduacion = cerveza.Graduacion;


                cervezaEN.Tipo = cerveza.Tipo;

                session.Update (cervezaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CervezaEN cerveza)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (cerveza);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cerveza.Id;
}

public void Modify (CervezaEN cerveza)
{
        try
        {
                SessionInitializeTransaction ();
                CervezaEN cervezaEN = (CervezaEN)session.Load (typeof(CervezaEN), cerveza.Id);

                cervezaEN.Nombre = cerveza.Nombre;


                cervezaEN.Stock = cerveza.Stock;


                cervezaEN.Precio = cerveza.Precio;


                cervezaEN.ValMedia = cerveza.ValMedia;


                cervezaEN.Descripcion = cerveza.Descripcion;


                cervezaEN.Imagen = cerveza.Imagen;


                cervezaEN.Marca = cerveza.Marca;


                cervezaEN.Volumen = cerveza.Volumen;


                cervezaEN.Unidades = cerveza.Unidades;


                cervezaEN.Graduacion = cerveza.Graduacion;


                cervezaEN.Tipo = cerveza.Tipo;

                session.Update (cervezaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
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
                CervezaEN cervezaEN = (CervezaEN)session.Load (typeof(CervezaEN), id);
                session.Delete (cervezaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CervezaEN
public CervezaEN ReadOID (int id
                          )
{
        CervezaEN cervezaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cervezaEN = (CervezaEN)session.Get (typeof(CervezaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cervezaEN;
}

public System.Collections.Generic.IList<CervezaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CervezaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CervezaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CervezaEN>();
                else
                        result = session.CreateCriteria (typeof(CervezaEN)).List<CervezaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.CervezaEN> DevulevePorTipo (CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum ? arg0)
{
        System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.CervezaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CervezaEN self where FROM CervezaEN where tipo = :tipo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CervezaENdevulevePorTipoHQL");
                query.SetParameter ("arg0", arg0);

                result = query.List<CervezUAGenNHibernate.EN.CervezUA.CervezaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CervezaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
