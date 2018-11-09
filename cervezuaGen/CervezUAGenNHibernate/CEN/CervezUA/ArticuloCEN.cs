

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
 *      Definition of the class ArticuloCEN
 *
 */
public partial class ArticuloCEN
{
private IArticuloCAD _IArticuloCAD;

public ArticuloCEN()
{
        this._IArticuloCAD = new ArticuloCAD ();
}

public ArticuloCEN(IArticuloCAD _IArticuloCAD)
{
        this._IArticuloCAD = _IArticuloCAD;
}

public IArticuloCAD get_IArticuloCAD ()
{
        return this._IArticuloCAD;
}

public ArticuloEN ReadOID (int id
                           )
{
        ArticuloEN articuloEN = null;

        articuloEN = _IArticuloCAD.ReadOID (id);
        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> list = null;

        list = _IArticuloCAD.ReadAll (first, size);
        return list;
}
public int New_ (string p_nombre, int p_stock, double p_precio, double p_valMedia, string p_descripcion, string p_imagen, string p_marca)
{
        ArticuloEN articuloEN = null;
        int oid;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Nombre = p_nombre;

        articuloEN.Stock = p_stock;

        articuloEN.Precio = p_precio;

        articuloEN.ValMedia = p_valMedia;

        articuloEN.Descripcion = p_descripcion;

        articuloEN.Imagen = p_imagen;

        articuloEN.Marca = p_marca;

        //Call to ArticuloCAD

        oid = _IArticuloCAD.New_ (articuloEN);
        return oid;
}

public void Modify (int p_Articulo_OID, string p_nombre, int p_stock, double p_precio, double p_valMedia, string p_descripcion, string p_imagen, string p_marca)
{
        ArticuloEN articuloEN = null;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Id = p_Articulo_OID;
        articuloEN.Nombre = p_nombre;
        articuloEN.Stock = p_stock;
        articuloEN.Precio = p_precio;
        articuloEN.ValMedia = p_valMedia;
        articuloEN.Descripcion = p_descripcion;
        articuloEN.Imagen = p_imagen;
        articuloEN.Marca = p_marca;
        //Call to ArticuloCAD

        _IArticuloCAD.Modify (articuloEN);
}

public void Destroy (int id
                     )
{
        _IArticuloCAD.Destroy (id);
}

public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ArticuloEN> DevuelvePorMarca (string brand)
{
        return _IArticuloCAD.DevuelvePorMarca (brand);
}
}
}
