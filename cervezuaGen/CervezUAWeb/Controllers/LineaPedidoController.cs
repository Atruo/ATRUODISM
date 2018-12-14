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

namespace CervezUAWeb.Controllers
{
    public class LineaPedidoController : BasicController
    {
        // GET: LineaPedido
        public ActionResult Index()
        {
            LineaPedidoCEN art = new LineaPedidoCEN();

            IList<LineaPedidoEN> listaArticulos = art.ReadAll(0, -1).ToList();
            IEnumerable<LineaPedidoViewModel> list = new AssemblerLineaPedido().ConvertListENToModel(listaArticulos).ToList();
            return View(list);
        }

        // GET: LineaPedido/Details/5
        public ActionResult Details(int id)
        {
            LineaPedidoViewModel copa = null;
            SessionInitialize();
            LineaPedidoEN copaEN = new LineaPedidoCAD(session).ReadOIDDefault(id);
            copa = new AssemblerLineaPedido().ConvertENToModelUI(copaEN);
            SessionClose();

            return View(copa);
        }

        // GET: LineaPedido/Create
        public ActionResult Create()
        {
            LineaPedidoViewModel usuarioEN = new LineaPedidoViewModel();
            return View(usuarioEN);
        }

        // POST: LineaPedido/Create
        [HttpPost]
        public ActionResult Create(LineaPedidoViewModel linea)
        {
            try
            {

                LineaPedidoCEN cop = new LineaPedidoCEN();
                cop.New_(linea.id, linea.Numero, linea.Articulo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LineaPedido/Edit/5
        public ActionResult Edit(int id)
        {
            LineaPedidoViewModel copa = null;
            SessionInitialize();
            LineaPedidoEN copaEN = new LineaPedidoCAD(session).ReadOIDDefault(id);
            copa = new AssemblerLineaPedido().ConvertENToModelUI(copaEN);
            SessionClose();

            return View(copa);
        }

        // POST: LineaPedido/Edit/5
        [HttpPost]
        public ActionResult Edit(LineaPedidoViewModel linea)
        {
            try
            {
                LineaPedidoCEN cop = new LineaPedidoCEN();
                cop.Modify(linea.id, linea.Numero);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LineaPedido/Delete/5
        public ActionResult Delete(int id)
        {
            LineaPedidoViewModel cop = null;
            SessionInitialize();
            LineaPedidoEN usuEN = new LineaPedidoCAD(session).ReadOIDDefault(id);
            cop = new AssemblerLineaPedido().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(cop);
        }

        // POST: LineaPedido/Delete/5
        [HttpPost]
        public ActionResult Delete(LineaPedidoViewModel linea)
        {
            try
            {
                LineaPedidoCEN cop = new LineaPedidoCEN();
                cop.Destroy(linea.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
