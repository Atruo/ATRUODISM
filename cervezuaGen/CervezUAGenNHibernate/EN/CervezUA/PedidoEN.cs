
using System;
// Definición clase PedidoEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario;



/**
 *	Atributo estado
 */
private CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum estado;



/**
 *	Atributo lineas
 */
private System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineas;



/**
 *	Atributo importe
 */
private double importe;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo attribute
 */
private CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum attribute;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> Lineas {
        get { return lineas; } set { lineas = value;  }
}



public virtual double Importe {
        get { return importe; } set { importe = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum Attribute {
        get { return attribute; } set { attribute = value;  }
}





public PedidoEN()
{
        lineas = new System.Collections.Generic.List<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN>();
}



public PedidoEN(int id, CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario, CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum estado, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineas, double importe, string direccion, CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum attribute
                )
{
        this.init (Id, usuario, estado, lineas, importe, direccion, attribute);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Usuario, pedido.Estado, pedido.Lineas, pedido.Importe, pedido.Direccion, pedido.Attribute);
}

private void init (int id
                   , CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario, CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum estado, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineas, double importe, string direccion, CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum attribute)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Estado = estado;

        this.Lineas = lineas;

        this.Importe = importe;

        this.Direccion = direccion;

        this.Attribute = attribute;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
