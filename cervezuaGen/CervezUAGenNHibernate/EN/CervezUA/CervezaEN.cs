
using System;
// Definición clase CervezaEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class CervezaEN                                                                      : CervezUAGenNHibernate.EN.CervezUA.ArticuloEN


{
/**
 *	Atributo volumen
 */
private double volumen;



/**
 *	Atributo unidades
 */
private int unidades;



/**
 *	Atributo graduacion
 */
private double graduacion;



/**
 *	Atributo tipo
 */
private CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum tipo;






public virtual double Volumen {
        get { return volumen; } set { volumen = value;  }
}



public virtual int Unidades {
        get { return unidades; } set { unidades = value;  }
}



public virtual double Graduacion {
        get { return graduacion; } set { graduacion = value;  }
}



public virtual CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}





public CervezaEN() : base ()
{
}



public CervezaEN(int id, double volumen, int unidades, double graduacion, CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum tipo
                 , string nombre, int stock, double precio, double valMedia, string descripcion, string imagen, string marca, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN> valoracion
                 )
{
        this.init (Id, volumen, unidades, graduacion, tipo, nombre, stock, precio, valMedia, descripcion, imagen, marca, lineaPedido, valoracion);
}


public CervezaEN(CervezaEN cerveza)
{
        this.init (Id, cerveza.Volumen, cerveza.Unidades, cerveza.Graduacion, cerveza.Tipo, cerveza.Nombre, cerveza.Stock, cerveza.Precio, cerveza.ValMedia, cerveza.Descripcion, cerveza.Imagen, cerveza.Marca, cerveza.LineaPedido, cerveza.Valoracion);
}

private void init (int id
                   , double volumen, int unidades, double graduacion, CervezUAGenNHibernate.Enumerated.CervezUA.TipoCervezaEnum tipo, string nombre, int stock, double precio, double valMedia, string descripcion, string imagen, string marca, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN> valoracion)
{
        this.Id = id;


        this.Volumen = volumen;

        this.Unidades = unidades;

        this.Graduacion = graduacion;

        this.Tipo = tipo;

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
        CervezaEN t = obj as CervezaEN;
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
