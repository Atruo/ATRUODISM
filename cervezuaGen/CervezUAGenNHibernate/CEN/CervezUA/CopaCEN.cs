

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
 *      Definition of the class CopaCEN
 *
 */
public partial class CopaCEN
{
private ICopaCAD _ICopaCAD;

public CopaCEN()
{
        this._ICopaCAD = new CopaCAD ();
}

public CopaCEN(ICopaCAD _ICopaCAD)
{
        this._ICopaCAD = _ICopaCAD;
}

public ICopaCAD get_ICopaCAD ()
{
        return this._ICopaCAD;
}

public int New_ (string p_nombre, int p_stock, double p_precio, double p_valMedia, string p_descripcion, string p_imagen, string p_marca, double p_capacidad, CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum p_forma)
{
        CopaEN copaEN = null;
        int oid;

        //Initialized CopaEN
        copaEN = new CopaEN ();
        copaEN.Nombre = p_nombre;

        copaEN.Stock = p_stock;

        copaEN.Precio = p_precio;

        copaEN.ValMedia = p_valMedia;

        copaEN.Descripcion = p_descripcion;

        copaEN.Imagen = p_imagen;

        copaEN.Marca = p_marca;

        copaEN.Capacidad = p_capacidad;

        copaEN.Forma = p_forma;

        //Call to CopaCAD

        oid = _ICopaCAD.New_ (copaEN);
        return oid;
}

public void Modify (int p_Copa_OID, string p_nombre, int p_stock, double p_precio, double p_valMedia, string p_descripcion, string p_imagen, string p_marca, double p_capacidad, CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum p_forma)
{
        CopaEN copaEN = null;

        //Initialized CopaEN
        copaEN = new CopaEN ();
        copaEN.Id = p_Copa_OID;
        copaEN.Nombre = p_nombre;
        copaEN.Stock = p_stock;
        copaEN.Precio = p_precio;
        copaEN.ValMedia = p_valMedia;
        copaEN.Descripcion = p_descripcion;
        copaEN.Imagen = p_imagen;
        copaEN.Marca = p_marca;
        copaEN.Capacidad = p_capacidad;
        copaEN.Forma = p_forma;
        //Call to CopaCAD

        _ICopaCAD.Modify (copaEN);
}

public void Destroy (int id
                     )
{
        _ICopaCAD.Destroy (id);
}

public CopaEN ReadOID (int id
                       )
{
        CopaEN copaEN = null;

        copaEN = _ICopaCAD.ReadOID (id);
        return copaEN;
}

public System.Collections.Generic.IList<CopaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CopaEN> list = null;

        list = _ICopaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.CopaEN> DevuelvePorTipo (CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum ? tipo)
{
        return _ICopaCAD.DevuelvePorTipo (tipo);
}
}
}
