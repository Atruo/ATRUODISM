
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
 * Clase LineaCesta:
 *
 */

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial class LineaCestaCAD : BasicCAD, ILineaCestaCAD
{
public LineaCestaCAD() : base ()
{
}

public LineaCestaCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaCestaEN ReadOIDDefault (int id
                                    )
{
        LineaCestaEN lineaCestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaCestaEN = (LineaCestaEN)session.Get (typeof(LineaCestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCestaEN;
}

public System.Collections.Generic.IList<LineaCestaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaCestaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaCestaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaCestaEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaCestaEN)).List<LineaCestaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaCestaEN lineaCesta)
{
        try
        {
                SessionInitializeTransaction ();
                LineaCestaEN lineaCestaEN = (LineaCestaEN)session.Load (typeof(LineaCestaEN), lineaCesta.Id);



                lineaCestaEN.Numero = lineaCesta.Numero;

                session.Update (lineaCestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (LineaCestaEN lineaCesta)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaCesta.Cesta != null) {
                        // Argumento OID y no colección.
                        lineaCesta.Cesta = (CervezUAGenNHibernate.EN.CervezUA.CestaEN)session.Load (typeof(CervezUAGenNHibernate.EN.CervezUA.CestaEN), lineaCesta.Cesta.Id);

                        lineaCesta.Cesta.Articulos
                        .Add (lineaCesta);
                }

                session.Save (lineaCesta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCesta.Id;
}

public void Modify (LineaCestaEN lineaCesta)
{
        try
        {
                SessionInitializeTransaction ();
                LineaCestaEN lineaCestaEN = (LineaCestaEN)session.Load (typeof(LineaCestaEN), lineaCesta.Id);

                lineaCestaEN.Numero = lineaCesta.Numero;

                session.Update (lineaCestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
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
                LineaCestaEN lineaCestaEN = (LineaCestaEN)session.Load (typeof(LineaCestaEN), id);
                session.Delete (lineaCestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in LineaCestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
