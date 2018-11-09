
using System;
// Definición clase AdministradorEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class AdministradorEN                                                                        : CervezUAGenNHibernate.EN.CervezUA.UsuarioEN


{
/**
 *	Atributo sueldo
 */
private double sueldo;






public virtual double Sueldo {
        get { return sueldo; } set { sueldo = value;  }
}





public AdministradorEN() : base ()
{
}



public AdministradorEN(string nUsuario, double sueldo
                       , string email, Nullable<DateTime> fecNam, string nombre, string apellidos, string foto, CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum tipo, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> pedido, CervezUAGenNHibernate.EN.CervezUA.ValoracionEN valoracion, String pass
                       )
{
        this.init (NUsuario, sueldo, email, fecNam, nombre, apellidos, foto, tipo, pedido, valoracion, pass);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (NUsuario, administrador.Sueldo, administrador.Email, administrador.FecNam, administrador.Nombre, administrador.Apellidos, administrador.Foto, administrador.Tipo, administrador.Pedido, administrador.Valoracion, administrador.Pass);
}

private void init (string nUsuario
                   , double sueldo, string email, Nullable<DateTime> fecNam, string nombre, string apellidos, string foto, CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum tipo, System.Collections.Generic.IList<CervezUAGenNHibernate.EN.CervezUA.PedidoEN> pedido, CervezUAGenNHibernate.EN.CervezUA.ValoracionEN valoracion, String pass)
{
        this.NUsuario = nUsuario;


        this.Sueldo = sueldo;

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
        AdministradorEN t = obj as AdministradorEN;
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
