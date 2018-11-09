
using System;
// Definición clase UsuarioEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class UsuarioEN
{
/**
 *	Atributo nUsuario
 */
private string nUsuario;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo fecNam
 */
private Nullable<DateTime> fecNam;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo tipo
 */
private CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum tipo;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> pedido;



/**
 *	Atributo valoracion
 */
private CervezUAGenNHibernate.EN.CervezUA.ValoracionEN valoracion;



/**
 *	Atributo pass
 */
private String pass;






public virtual string NUsuario {
        get { return nUsuario; } set { nUsuario = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual Nullable<DateTime> FecNam {
        get { return fecNam; } set { fecNam = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual CervezUAGenNHibernate.EN.CervezUA.ValoracionEN Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public UsuarioEN()
{
        pedido = new System.Collections.Generic.List<CervezUAGenNHibernate.EN.CervezUA.PedidoEN>();
}



public UsuarioEN(string nUsuario, string email, Nullable<DateTime> fecNam, string nombre, string apellidos, string foto, CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum tipo, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> pedido, CervezUAGenNHibernate.EN.CervezUA.ValoracionEN valoracion, String pass
                 )
{
        this.init (NUsuario, email, fecNam, nombre, apellidos, foto, tipo, pedido, valoracion, pass);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (NUsuario, usuario.Email, usuario.FecNam, usuario.Nombre, usuario.Apellidos, usuario.Foto, usuario.Tipo, usuario.Pedido, usuario.Valoracion, usuario.Pass);
}

private void init (string nUsuario
                   , string email, Nullable<DateTime> fecNam, string nombre, string apellidos, string foto, CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum tipo, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> pedido, CervezUAGenNHibernate.EN.CervezUA.ValoracionEN valoracion, String pass)
{
        this.NUsuario = nUsuario;


        this.Email = email;

        this.FecNam = fecNam;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Foto = foto;

        this.Tipo = tipo;

        this.Pedido = pedido;

        this.Valoracion = valoracion;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (NUsuario.Equals (t.NUsuario))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NUsuario.GetHashCode ();
        return hash;
}
}
}
