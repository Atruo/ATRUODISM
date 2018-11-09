
using System;
// Definición clase ArticuloEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class ArticuloEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo valMedia
 */
private double valMedia;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo marca
 */
private string marca;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineaPedido;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN> valoracion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual double ValMedia {
        get { return valMedia; } set { valMedia = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Marca {
        get { return marca; } set { marca = value;  }
}



public virtual System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}





public ArticuloEN()
{
        lineaPedido = new System.Collections.Generic.List<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN>();
        valoracion = new System.Collections.Generic.List<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN>();
}



public ArticuloEN(int id, string nombre, int stock, double precio, double valMedia, string descripcion, string imagen, string marca, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN> valoracion
                  )
{
        this.init (Id, nombre, stock, precio, valMedia, descripcion, imagen, marca, lineaPedido, valoracion);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (Id, articulo.Nombre, articulo.Stock, articulo.Precio, articulo.ValMedia, articulo.Descripcion, articulo.Imagen, articulo.Marca, articulo.LineaPedido, articulo.Valoracion);
}

private void init (int id
                   , string nombre, int stock, double precio, double valMedia, string descripcion, string imagen, string marca, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN> valoracion)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Stock = stock;

        this.Precio = precio;

        this.ValMedia = valMedia;

        this.Descripcion = descripcion;

        this.Imagen = imagen;

        this.Marca = marca;

        this.LineaPedido = lineaPedido;

        this.Valoracion = valoracion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArticuloEN t = obj as ArticuloEN;
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
