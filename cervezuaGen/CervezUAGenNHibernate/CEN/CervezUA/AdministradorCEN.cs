

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using CervezUAGenNHibernate.Exceptions;

using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.CAD.CervezUA;


namespace CervezUAGenNHibernate.CEN.CervezUA
{
/*
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public string New_ (string p_nUsuario, string p_email, Nullable<DateTime> p_fecNam, string p_nombre, string p_apellidos, string p_foto, CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum p_tipo, String p_pass, double p_sueldo)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.NUsuario = p_nUsuario;

        administradorEN.Email = p_email;

        administradorEN.FecNam = p_fecNam;

        administradorEN.Nombre = p_nombre;

        administradorEN.Apellidos = p_apellidos;

        administradorEN.Foto = p_foto;

        administradorEN.Tipo = p_tipo;

        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        administradorEN.Sueldo = p_sueldo;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.New_ (administradorEN);
        return oid;
}

public void Modify (string p_Administrador_OID, string p_email, Nullable<DateTime> p_fecNam, string p_nombre, string p_apellidos, string p_foto, CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum p_tipo, String p_pass, double p_sueldo)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.NUsuario = p_Administrador_OID;
        administradorEN.Email = p_email;
        administradorEN.FecNam = p_fecNam;
        administradorEN.Nombre = p_nombre;
        administradorEN.Apellidos = p_apellidos;
        administradorEN.Foto = p_foto;
        administradorEN.Tipo = p_tipo;
        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        administradorEN.Sueldo = p_sueldo;
        //Call to AdministradorCAD

        _IAdministradorCAD.Modify (administradorEN);
}

public void Destroy (string nUsuario
                     )
{
        _IAdministradorCAD.Destroy (nUsuario);
}

public AdministradorEN ReadOID (string nUsuario
                                )
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorCAD.ReadOID (nUsuario);
        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorCAD.ReadAll (first, size);
        return list;
}
}
}
