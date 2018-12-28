
using CervezUAGenNHibernate.EN.CervezUA;
using System.Collections.Generic;

namespace CervezUAWeb.Models
{
    public class AssemblerUsuario
    {
        public UsuarioViewModel ConvertENToModelUI(UsuarioEN en)
        {
            UsuarioViewModel usu = new UsuarioViewModel();
            usu.NUsuario = en.NUsuario;
            usu.Email = en.Email;
            usu.FecNam = en.FecNam;
            usu.Nombre = en.Nombre;
            usu.Apellidos = en.Apellidos;
            usu.Foto = en.Foto;
            usu.Tipo = en.Tipo;
            usu.Password = en.Pass;
            return usu;


        }
        public IList<UsuarioViewModel> ConvertListENToModel(IList<UsuarioEN> ens)
        {
            IList<UsuarioViewModel> usus = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }

    }
}