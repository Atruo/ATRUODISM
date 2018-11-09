

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
 *      Definition of the class CervezaCEN
 *
 */
public partial class CervezaCEN
{
private ICervezaCAD _ICervezaCAD;

public CervezaCEN()
{
        this._ICervezaCAD = new CervezaCAD ();
}

public CervezaCEN(ICervezaCAD _ICervezaCAD)
{
        this._ICervezaCAD = _ICervezaCAD;
}

public ICervezaCAD get_ICervezaCAD ()
{
        return this._ICervezaCAD;
}

public int New_ (string p_nombre, int p_stock, double p_precio, double p_valMedia, string p_descripcion, string p_imagen, string p_marca, double p_volumen, int p_unidades, double p_graduacion, CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum p_tipo)
{
        CervezaEN cervezaEN = null;
        int oid;

        //Initialized CervezaEN
        cervezaEN = new CervezaEN ();
        cervezaEN.Nombre = p_nombre;

        cervezaEN.Stock = p_stock;

        cervezaEN.Precio = p_precio;

        cervezaEN.ValMedia = p_valMedia;

        cervezaEN.Descripcion = p_descripcion;

        cervezaEN.Imagen = p_imagen;

        cervezaEN.Marca = p_marca;

        cervezaEN.Volumen = p_volumen;

        cervezaEN.Unidades = p_unidades;

        cervezaEN.Graduacion = p_graduacion;

        cervezaEN.Tipo = p_tipo;

        //Call to CervezaCAD

        oid = _ICervezaCAD.New_ (cervezaEN);
        return oid;
}

public void Modify (int p_Cerveza_OID, string p_nombre, int p_stock, double p_precio, double p_valMedia, string p_descripcion, string p_imagen, string p_marca, double p_volumen, int p_unidades, double p_graduacion, CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum p_tipo)
{
        CervezaEN cervezaEN = null;

        //Initialized CervezaEN
        cervezaEN = new CervezaEN ();
        cervezaEN.Id = p_Cerveza_OID;
        cervezaEN.Nombre = p_nombre;
        cervezaEN.Stock = p_stock;
        cervezaEN.Precio = p_precio;
        cervezaEN.ValMedia = p_valMedia;
        cervezaEN.Descripcion = p_descripcion;
        cervezaEN.Imagen = p_imagen;
        cervezaEN.Marca = p_marca;
        cervezaEN.Volumen = p_volumen;
        cervezaEN.Unidades = p_unidades;
        cervezaEN.Graduacion = p_graduacion;
        cervezaEN.Tipo = p_tipo;
        //Call to CervezaCAD

        _ICervezaCAD.Modify (cervezaEN);
}

public void Destroy (int id
                     )
{
        _ICervezaCAD.Destroy (id);
}

public CervezaEN ReadOID (int id
                          )
{
        CervezaEN cervezaEN = null;

        cervezaEN = _ICervezaCAD.ReadOID (id);
        return cervezaEN;
}

public System.Collections.Generic.IList<CervezaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CervezaEN> list = null;

        list = _ICervezaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.CervezaEN> DevulevePorTipo (CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum ? arg0)
{
        return _ICervezaCAD.DevulevePorTipo (arg0);
}
}
}
