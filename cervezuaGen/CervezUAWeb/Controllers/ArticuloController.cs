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

namespace CervezUAWeb.Views.Articulo
{
    public class ArticuloController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            ArticuloCEN art = new ArticuloCEN();
            
            IList<ArticuloEN> listaArticulos = art.ReadAll(0, -1).ToList();
            IEnumerable<ArticuloViewModel> list = new AssemblerArticulo().ConvertListENToModel(listaArticulos).ToList();
            return View(list);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Articulo/Create
        public ActionResult Create()

        {
            ArticuloViewModel usuarioEN = new ArticuloViewModel();
            return View(usuarioEN);

        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(ArticuloViewModel articulo)
        {
            try
            {
                ArticuloCEN art = new ArticuloCEN();
                art.New_(articulo.Nombre, articulo.Stock, articulo.Precio, articulo.ValMedia, articulo.Descripcion, articulo.Imagen, articulo.Marca);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            ArticuloViewModel usu = null;
            SessionInitialize();
            ArticuloEN usuEN = new ArticuloCAD(session).ReadOIDDefault(id);
            usu = new AssemblerArticulo().ConvertENToModelUI(usuEN);
            SessionClose();

            return View(usu);

        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(ArticuloViewModel articulo)
        {
            try
            {
                ArticuloCEN art = new ArticuloCEN();
                art.Modify(articulo.id,articulo.Nombre, articulo.Stock, articulo.Precio, articulo.ValMedia, articulo.Descripcion, articulo.Imagen, articulo.Marca);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            ArticuloViewModel usu = null;
            SessionInitialize();
            ArticuloEN usuEN = new ArticuloCAD(session).ReadOIDDefault(id);
            usu = new AssemblerArticulo().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(ArticuloViewModel articulo)
        {
            try
            {
                ArticuloCEN art = new ArticuloCEN();
                art.Destroy(articulo.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
