

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using CervezUAGenNHibernate.Exceptions;

using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.CAD.CervezUA;


namespace CervezUAGenNHibernate.CEN.CervezUA
{
/*
 *      Definition of the class CestaCEN
 *
 */
public partial class CestaCEN
{
private ICestaCAD _ICestaCAD;

public CestaCEN()
{
        this._ICestaCAD = new CestaCAD ();
}

public CestaCEN(ICestaCAD _ICestaCAD)
{
        this._ICestaCAD = _ICestaCAD;
}

public ICestaCAD get_ICestaCAD ()
{
        return this._ICestaCAD;
}

public int New_ (string p_usuario)
{
        CestaEN cestaEN = null;
        int oid;

        //Initialized CestaEN
        cestaEN = new CestaEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                cestaEN.Usuario = new CervezUAGenNHibernate.EN.CervezUA.UsuarioEN ();
                cestaEN.Usuario.NUsuario = p_usuario;
        }

        //Call to CestaCAD

        oid = _ICestaCAD.New_ (cestaEN);
        return oid;
}

public void Modify (int p_Cesta_OID)
{
        CestaEN cestaEN = null;

        //Initialized CestaEN
        cestaEN = new CestaEN ();
        cestaEN.Id = p_Cesta_OID;
        //Call to CestaCAD

        _ICestaCAD.Modify (cestaEN);
}

public void Destroy (int id
                     )
{
        _ICestaCAD.Destroy (id);
}

public CestaEN ReadOID (int id
                        )
{
        CestaEN cestaEN = null;

        cestaEN = _ICestaCAD.ReadOID (id);
        return cestaEN;
}

public System.Collections.Generic.IList<CestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CestaEN> list = null;

        list = _ICestaCAD.ReadAll (first, size);
        return list;
}
}
}
