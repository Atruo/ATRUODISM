

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
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public int New_ (string p_usuario, CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum p_estado, double p_importe, string p_direccion, CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum p_attribute)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                pedidoEN.Usuario = new CervezUAGenNHibernate.EN.CervezUA.UsuarioEN ();
                pedidoEN.Usuario.NUsuario = p_usuario;
        }

        pedidoEN.Estado = p_estado;

        pedidoEN.Importe = p_importe;

        pedidoEN.Direccion = p_direccion;

        pedidoEN.Attribute = p_attribute;

        //Call to PedidoCAD

        oid = _IPedidoCAD.New_ (pedidoEN);
        return oid;
}

public void Modify (int p_Pedido_OID, CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum p_estado, double p_importe, string p_direccion, CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum p_attribute)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Estado = p_estado;
        pedidoEN.Importe = p_importe;
        pedidoEN.Direccion = p_direccion;
        pedidoEN.Attribute = p_attribute;
        //Call to PedidoCAD

        _IPedidoCAD.Modify (pedidoEN);
}

public void Destroy (int id
                     )
{
        _IPedidoCAD.Destroy (id);
}

public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoCAD.ReadOID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> FiltrarPorEstado (CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum ? state)
{
        return _IPedidoCAD.FiltrarPorEstado (state);
}
}
}
