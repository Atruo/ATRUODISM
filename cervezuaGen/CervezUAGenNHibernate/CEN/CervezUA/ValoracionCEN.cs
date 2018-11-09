

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
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionCAD _IValoracionCAD;

public ValoracionCEN()
{
        this._IValoracionCAD = new ValoracionCAD ();
}

public ValoracionCEN(IValoracionCAD _IValoracionCAD)
{
        this._IValoracionCAD = _IValoracionCAD;
}

public IValoracionCAD get_IValoracionCAD ()
{
        return this._IValoracionCAD;
}

public int New_ (int p_articulo, string p_usuario, double p_valoracion, string p_texto)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();

        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids id
                valoracionEN.Articulo = new CervezUAGenNHibernate.EN.CervezUA.ArticuloEN ();
                valoracionEN.Articulo.Id = p_articulo;
        }


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                valoracionEN.Usuario = new CervezUAGenNHibernate.EN.CervezUA.UsuarioEN ();
                valoracionEN.Usuario.NUsuario = p_usuario;
        }

        valoracionEN.Valoracion = p_valoracion;

        valoracionEN.Texto = p_texto;

        //Call to ValoracionCAD

        oid = _IValoracionCAD.New_ (valoracionEN);
        return oid;
}

public void Modify (int p_Valoracion_OID, double p_valoracion, string p_texto)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id = p_Valoracion_OID;
        valoracionEN.Valoracion = p_valoracion;
        valoracionEN.Texto = p_texto;
        //Call to ValoracionCAD

        _IValoracionCAD.Modify (valoracionEN);
}

public void Destroy (int id
                     )
{
        _IValoracionCAD.Destroy (id);
}

public ValoracionEN ReadOID (int id
                             )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionCAD.ReadOID (id);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionCAD.ReadAll (first, size);
        return list;
}
}
}
