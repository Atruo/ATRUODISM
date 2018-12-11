
using CervezUAGenNHibernate.EN.CervezUA;
using System.Collections.Generic;

namespace CervezUAWeb.Models
{
    public class AssemblerValoracion
    {
        public ValoracionViewModel ConvertENToModelUI(ValoracionEN en)
        {
            ValoracionViewModel val = new ValoracionViewModel();
            val.id = en.Id;
            val.usuario = en.Usuario;
            val.Valoracion = en.Valoracion;
            val.texto = en.Texto;
            return val;
        }
        public IList<ValoracionViewModel> ConvertListENToModel(IList<ValoracionEN> ens)
        {
            IList<ValoracionViewModel> val = new List<ValoracionViewModel>();
            foreach (ValoracionEN en in ens)
            {
                val.Add(ConvertENToModelUI(en));
            }
            return val;
        }

    }
}