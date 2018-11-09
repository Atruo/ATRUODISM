
using System;
// Definición clase LineaPedidoEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class LineaPedidoEN
{
/**
 *	Atributo pedido
 */
private CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulo
 */
private CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo;



/**
 *	Atributo numero
 */
private int numero;






public virtual CervezUAGenNHibernate.EN.CervezUA.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual int Numero {
        get { return numero; } set { numero = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido, CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo, int numero
                     )
{
        this.init (Id, pedido, articulo, numero);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (Id, lineaPedido.Pedido, lineaPedido.Articulo, lineaPedido.Numero);
}

private void init (int id
                   , CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido, CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo, int numero)
{
        this.Id = id;


        this.Pedido = pedido;

        this.Articulo = articulo;

        this.Numero = numero;
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
