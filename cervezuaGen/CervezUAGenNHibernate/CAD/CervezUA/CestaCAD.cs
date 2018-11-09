
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
 * Clase Cesta:
 *
 */

namespace CervezUAGenNHibernate.CAD.CervezUA
{
public partial class CestaCAD : BasicCAD, ICestaCAD
{
public CestaCAD() : base ()
{
}

public CestaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CestaEN ReadOIDDefault (int id
                               )
{
        CestaEN cestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cestaEN = (CestaEN)session.Get (typeof(CestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cestaEN;
}

public System.Collections.Generic.IList<CestaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CestaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CestaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CestaEN>();
                        else
                                result = session.CreateCriteria (typeof(CestaEN)).List<CestaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CestaEN cesta)
{
        try
        {
                SessionInitializeTransaction ();
                CestaEN cestaEN = (CestaEN)session.Load (typeof(CestaEN), cesta.Id);


                session.Update (cestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CestaEN cesta)
{
        try
        {
                SessionInitializeTransaction ();
                if (cesta.Usuario != null) {
                        // Argumento OID y no colección.
                        cesta.Usuario = (CervezUAGenNHibernate.EN.CervezUA.UsuarioEN)session.Load (typeof(CervezUAGenNHibernate.EN.CervezUA.UsuarioEN), cesta.Usuario.NUsuario);

                        cesta.Usuario.Cesta
                                = cesta;
                }

                session.Save (cesta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cesta.Id;
}

public void Modify (CestaEN cesta)
{
        try
        {
                SessionInitializeTransaction ();
                CestaEN cestaEN = (CestaEN)session.Load (typeof(CestaEN), cesta.Id);
                session.Update (cestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
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
                CestaEN cestaEN = (CestaEN)session.Load (typeof(CestaEN), id);
                session.Delete (cestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CestaEN
public CestaEN ReadOID (int id
                        )
{
        CestaEN cestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cestaEN = (CestaEN)session.Get (typeof(CestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cestaEN;
}

public System.Collections.Generic.IList<CestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CestaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CestaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CestaEN>();
                else
                        result = session.CreateCriteria (typeof(CestaEN)).List<CestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is CervezUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new CervezUAGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
