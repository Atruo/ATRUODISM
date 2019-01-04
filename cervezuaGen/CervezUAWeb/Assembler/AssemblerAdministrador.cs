
using CervezUAGenNHibernate.EN.CervezUA;
using System.Collections.Generic;

namespace CervezUAWeb.Models
{
    public class AssemblerAdministrador
    {
        public AdministradorViewModel ConvertENToModelUI(AdministradorEN en)
        {
            AdministradorViewModel usu = new AdministradorViewModel();
            usu.NUsuario = en.NUsuario;
            usu.Email = en.Email;
            usu.FecNam = en.FecNam;
            usu.Nombre = en.Nombre;
            usu.Apellidos = en.Apellidos;
            usu.Foto = en.Foto;
            usu.Tipo = en.Tipo;
            usu.Password = en.Pass;
            usu.Sueldo = en.Sueldo;
            return usu;


        }
        public IList<AdministradorViewModel> ConvertListENToModel(IList<AdministradorEN> ens)
        {
            IList<AdministradorViewModel> usus = new List<AdministradorViewModel>();
            foreach (AdministradorEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }

    }
}