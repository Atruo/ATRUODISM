
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
 *	Atributo lineas
 */
private System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineas;



/**
 *	Atributo usuario
 */
private CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario;



/**
 *	Atributo estado
 */
private CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum estado;



/**
 *	Atributo factura
 */
private CervezUAGenNHibernate.EN.CervezUA.FacturaEN factura;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> Lineas {
        get { return lineas; } set { lineas = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}





public PedidoEN()
{
        lineas = new System.Collections.Generic.List<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN>();
}



public PedidoEN(int id, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineas, CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario, CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum estado, CervezUAGenNHibernate.EN.CervezUA.FacturaEN factura
                )
{
        this.init (Id, lineas, usuario, estado, factura);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Lineas, pedido.Usuario, pedido.Estado, pedido.Factura);
}

private void init (int id
                   , System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineas, CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario, CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum estado, CervezUAGenNHibernate.EN.CervezUA.FacturaEN factura)
{
        this.Id = id;


        this.Lineas = lineas;

        this.Usuario = usuario;

        this.Estado = estado;

        this.Factura = factura;
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
