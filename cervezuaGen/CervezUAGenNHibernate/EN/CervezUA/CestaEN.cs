
using System;
// Definición clase CestaEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class CestaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulos
 */
private System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaCestaEN> articulos;



/**
 *	Atributo usuario
 */
private CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaCestaEN> Articulos {
        get { return articulos; } set { articulos = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public CestaEN()
{
        articulos = new System.Collections.Generic.List<CervezUAGenNHibernate.EN.CervezUA.LineaCestaEN>();
}



public CestaEN(int id, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaCestaEN> articulos, CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario
               )
{
        this.init (Id, articulos, usuario);
}


public CestaEN(CestaEN cesta)
{
        this.init (Id, cesta.Articulos, cesta.Usuario);
}

private void init (int id
                   , System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.LineaCestaEN> articulos, CervezUAGenNHibernate.EN.CervezUA.UsuarioEN usuario)
{
        this.Id = id;


        this.Articulos = articulos;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CestaEN t = obj as CestaEN;
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
