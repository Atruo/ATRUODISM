
using System;
// Definición clase LineaPedidoEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class LineaPedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo numero
 */
private int numero;



/**
 *	Atributo articulo
 */
private CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo;



/**
 *	Atributo pedido
 */
private CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Numero {
        get { return numero; } set { numero = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, int numero, CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo, CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido
                     )
{
        this.init (Id, numero, articulo, pedido);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (Id, lineaPedido.Numero, lineaPedido.Articulo, lineaPedido.Pedido);
}

private void init (int id
                   , int numero, CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo, CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido)
{
        this.Id = id;


        this.Numero = numero;

        this.Articulo = articulo;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
