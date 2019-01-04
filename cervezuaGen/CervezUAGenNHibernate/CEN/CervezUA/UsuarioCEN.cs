

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string New_ (string p_nUsuario, string p_email, Nullable<DateTime> p_fecNam, string p_nombre, string p_apellidos, string p_foto, CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum p_tipo, String p_pass)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.NUsuario = p_nUsuario;

        usuarioEN.Email = p_email;

        usuarioEN.FecNam = p_fecNam;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Foto = p_foto;

        usuarioEN.Tipo = p_tipo;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_email, Nullable<DateTime> p_fecNam, string p_nombre, string p_apellidos, string p_foto, CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum p_tipo, String p_pass)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.NUsuario = p_Usuario_OID;
        usuarioEN.Email = p_email;
        usuarioEN.FecNam = p_fecNam;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Foto = p_foto;
        usuarioEN.Tipo = p_tipo;
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string nUsuario
                     )
{
        _IUsuarioCAD.Destroy (nUsuario);
}

public UsuarioEN ReadOID (string nUsuario
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (nUsuario);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public long DevuelveTipo (long tipo)
{
        return _IUsuarioCAD.DevuelveTipo (tipo);
}



private string Encode ()
{
        var payload = new Dictionary<string, object>(){
               
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string nUsuario)
{
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (nUsuario);
        string token = Encode ();

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerNUSUARIO (decodedToken);

                UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);

                if (en != null && ((string)en.NUsuario).Equals (ObtenerNUSUARIO (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}
}
}
