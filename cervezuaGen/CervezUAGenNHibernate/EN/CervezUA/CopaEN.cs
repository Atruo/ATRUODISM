
using System;
// Definición clase CopaEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class CopaEN                                                                 : CervezUAGenNHibernate.EN.CervezUA.ArticuloEN


{
/**
 *	Atributo capacidad
 */
private double capacidad;



/**
 *	Atributo forma
 */
private CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum forma;






public virtual double Capacidad {
        get { return capacidad; } set { capacidad = value;  }
}



public virtual CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum Forma {
        get { return forma; } set { forma = value;  }
}





public CopaEN() : base ()
{
}



public CopaEN(int id, double capacidad, CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum forma
              , string nombre, int stock, double precio, double valMedia, string descripcion, string imagen, string marca, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN> valoracion
              )
{
        this.init (Id, capacidad, forma, nombre, stock, precio, valMedia, descripcion, imagen, marca, lineaPedido, valoracion);
}


public CopaEN(CopaEN copa)
{
        this.init (Id, copa.Capacidad, copa.Forma, copa.Nombre, copa.Stock, copa.Precio, copa.ValMedia, copa.Descripcion, copa.Imagen, copa.Marca, copa.LineaPedido, copa.Valoracion);
}

private void init (int id
                   , double capacidad, CervezUAGenNHibernate.Enumerated.CervezUA.TipoCopaEnum forma, string nombre, int stock, double precio, double valMedia, string descripcion, string imagen, string marca, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.ValoracionEN> valoracion)
{
        this.Id = id;


        this.Capacidad = capacidad;

        this.Forma = forma;

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
        CopaEN t = obj as CopaEN;
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
