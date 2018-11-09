
using System;
// Definición clase LineaCestaEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class LineaCestaEN
{
/**
 *	Atributo cesta
 */
private CervezUAGenNHibernate.EN.CervezUA.CestaEN cesta;



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






public virtual CervezUAGenNHibernate.EN.CervezUA.CestaEN Cesta {
        get { return cesta; } set { cesta = value;  }
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





public LineaCestaEN()
{
}



public LineaCestaEN(int id, CervezUAGenNHibernate.EN.CervezUA.CestaEN cesta, CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo, int numero
                    )
{
        this.init (Id, cesta, articulo, numero);
}


public LineaCestaEN(LineaCestaEN lineaCesta)
{
        this.init (Id, lineaCesta.Cesta, lineaCesta.Articulo, lineaCesta.Numero);
}

private void init (int id
                   , CervezUAGenNHibernate.EN.CervezUA.CestaEN cesta, CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo, int numero)
{
        this.Id = id;


        this.Cesta = cesta;

        this.Articulo = articulo;

        this.Numero = numero;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaCestaEN t = obj as LineaCestaEN;
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
