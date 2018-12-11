using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Assembler;
using CervezUAWeb.Controllers;
using CervezUAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CervezUAWeb.Views.Copa
{
    public class CopaController : BasicController
    {
        // GET: Copa
        public ActionResult Index()
        {
            CopaCEN art = new CopaCEN();

            IList<CopaEN> listaArticulos = art.ReadAll(0, -1).ToList();
            IEnumerable<CopaViewModel> list = new AssemblerCopa().ConvertListENToModel(listaArticulos).ToList();
            return View(list);
        }

        // GET: Copa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Copa/Create
        public ActionResult Create()
        {
            CopaViewModel usuarioEN = new CopaViewModel();
            return View(usuarioEN);
        }

        // POST: Copa/Create
        [HttpPost]
        public ActionResult Create(CopaViewModel copa)
        {
            try
            {
                CopaCEN cop = new CopaCEN();
                cop.New_(copa.Nombre, copa.Stock, copa.Precio, copa.ValMedia, copa.Descripcion, copa.Imagen, copa.Marca, copa.Capacidad, copa.Tipo);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        // GET: Copa/Edit/5
        public ActionResult Edit(int id)
        {
            CopaViewModel copa = null;
            SessionInitialize();
            CopaEN copaEN = new CopaCAD(session).ReadOIDDefault(id);
            copa = new AssemblerCopa().ConvertENToModelUI(copaEN);
            SessionClose();

            return View(copa);
        }

        // POST: Copa/Edit/5
        [HttpPost]
        public ActionResult Edit(CopaViewModel articulo)
        {
            try
            {
                CopaCEN cop = new CopaCEN();
                cop.Modify(articulo.id, articulo.Nombre, articulo.Stock, articulo.Precio, articulo.ValMedia, articulo.Descripcion, articulo.Imagen, articulo.Marca, articulo.Capacidad, articulo.Tipo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Copa/Delete/5
        public ActionResult Delete(int id)
        {
            CopaViewModel cop = null;
            SessionInitialize();
            CopaEN usuEN = new CopaCAD(session).ReadOIDDefault(id);
            cop = new AssemblerCopa().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(cop);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(CopaViewModel articulo)
        {
            try
            {
                CopaCEN cop = new CopaCEN();
                cop.Destroy(articulo.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
