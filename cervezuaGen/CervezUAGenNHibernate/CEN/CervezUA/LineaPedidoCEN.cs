

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
 *      Definition of the class LineaPedidoCEN
 *
 */
public partial class LineaPedidoCEN
{
private ILineaPedidoCAD _ILineaPedidoCAD;

public LineaPedidoCEN()
{
        this._ILineaPedidoCAD = new LineaPedidoCAD ();
}

public LineaPedidoCEN(ILineaPedidoCAD _ILineaPedidoCAD)
{
        this._ILineaPedidoCAD = _ILineaPedidoCAD;
}

public ILineaPedidoCAD get_ILineaPedidoCAD ()
{
        return this._ILineaPedidoCAD;
}

public int New_ (int p_pedido, CervezUAGenNHibernate.EN.CervezUA.ArticuloEN p_articulo, int p_numero)
{
        LineaPedidoEN lineaPedidoEN = null;
        int oid;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();

        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                lineaPedidoEN.Pedido = new CervezUAGenNHibernate.EN.CervezUA.PedidoEN ();
                lineaPedidoEN.Pedido.Id = p_pedido;
        }

        lineaPedidoEN.Articulo = p_articulo;

        lineaPedidoEN.Numero = p_numero;

        //Call to LineaPedidoCAD

        oid = _ILineaPedidoCAD.New_ (lineaPedidoEN);
        return oid;
}

public void Modify (int p_LineaPedido_OID, int p_numero)
{
        LineaPedidoEN lineaPedidoEN = null;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Id = p_LineaPedido_OID;
        lineaPedidoEN.Numero = p_numero;
        //Call to LineaPedidoCAD

        _ILineaPedidoCAD.Modify (lineaPedidoEN);
}

public void Destroy (int id
                     )
{
        _ILineaPedidoCAD.Destroy (id);
}

public LineaPedidoEN ReadOID (int id
                              )
{
        LineaPedidoEN lineaPedidoEN = null;

        lineaPedidoEN = _ILineaPedidoCAD.ReadOID (id);
        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> list = null;

        list = _ILineaPedidoCAD.ReadAll (first, size);
        return list;
}
}
}
