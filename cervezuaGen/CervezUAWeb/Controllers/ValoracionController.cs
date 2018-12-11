using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Controllers;
using CervezUAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CervezUAWeb.Controllers
{
    public class ValoracionController : BasicController
    {
        // GET: Valoracion
        public ActionResult Index()
        {
            ValoracionCEN val = new ValoracionCEN();

            IList<ValoracionEN> listaValoraciones = val.ReadAll(0, -1).ToList();
            IEnumerable<ValoracionViewModel> list = new AssemblerValoracion().ConvertListENToModel(listaValoraciones).ToList();
            return View(list);
        }

        // GET: Valoracion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Valoracion/Create
        public ActionResult Create()
        {
            ValoracionViewModel ValoracionEN = new ValoracionViewModel();
            return View(ValoracionEN);
        }

        // POST: Valoracion/Create
        [HttpPost]
        public ActionResult Create(ValoracionViewModel valoracion)
        {
            try
            {
                ValoracionCEN val = new ValoracionCEN();
                val.New_(valoracion.id,valoracion.usuario.NUsuario, valoracion.Valoracion, valoracion.texto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Valoracion/Edit/5
        public ActionResult Edit(int id)
        {
            ValoracionViewModel val = null;
            SessionInitialize();
            ValoracionEN valEN = new ValoracionCAD(session).ReadOIDDefault(id);
            val = new AssemblerValoracion().ConvertENToModelUI(valEN);
            SessionClose();

            return View(val);
        }

        // POST: Valoracion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ValoracionViewModel valoracion)
        {
            try
            {
                ValoracionCEN val = new ValoracionCEN();
                val.Modify(valoracion.id, valoracion.Valoracion, valoracion.texto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Valoracion/Delete/5
        public ActionResult Delete(int id)
        {
            ValoracionViewModel val = null;
            SessionInitialize();
            ValoracionEN valEN = new ValoracionCAD(session).ReadOIDDefault(id);
            val = new AssemblerValoracion().ConvertENToModelUI(valEN);
            SessionClose();
            return View(val);
        }

        // POST: Valoracion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ValoracionViewModel valoracion)
        {
            try
            {
                ValoracionCEN val = new ValoracionCEN();
                val.Destroy(valoracion.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
