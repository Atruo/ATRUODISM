
using System;
// Definición clase ValoracionEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class ValoracionEN
{
/**
 *	Atributo articulo
 */
private CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo;



/**
 *	Atributo usuario
 */
private CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo valoracion
 */
private double valoracion;



/**
 *	Atributo texto
 */
private string texto;






public virtual CervezUAGenNHibernate.EN.CervezUA.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo, CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario, double valoracion, string texto
                    )
{
        this.init (Id, articulo, usuario, valoracion, texto);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (Id, valoracion.Articulo, valoracion.Usuario, valoracion.Valoracion, valoracion.Texto);
}

private void init (int id
                   , CervezUAGenNHibernate.EN.CervezUA.ArticuloEN articulo, CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario, double valoracion, string texto)
{
        this.Id = id;


        this.Articulo = articulo;

        this.Usuario = usuario;

        this.Valoracion = valoracion;

        this.Texto = texto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
