using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace CervezUAWeb.Controllers
{
    public class PedidoController : BasicController
    {
        // GET: Pedido
        public ActionResult Index()
        {
            PedidoCEN Pedido = new PedidoCEN();
            IList<PedidoEN> listUsuEn = Pedido.ReadAll(0, -1);
            IEnumerable<PedidoViewModel> listUsu = new AssemblerPedido().ConvertListENToModel(listUsuEn).ToList();
            return View(listUsu);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            PedidoViewModel ped = new PedidoViewModel();
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(PedidoViewModel ped)
        {
            try
            {
                // TODO: Add insert logic here
                PedidoCEN pedidoCEN = new PedidoCEN();
                pedidoCEN.New_(ped.NombreUsuario.NUsuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            PedidoViewModel ped = null;
            SessionInitialize();
            PedidoEN pedEN = new PedidoCAD(session).ReadOIDDefault(id);
            ped = new AssemblerPedido().ConvertENToModelUI(pedEN);
            SessionClose();
            return View(ped);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public ActionResult Edit(PedidoViewModel ped)
        {
            try
            {
                PedidoCEN cen = new PedidoCEN();
                cen.Modify(ped.Id, ped.Estado);
                return RedirectToAction("Index", new { id = ped.Id });
            }
            catch
            {
                return View();
            }

        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PedidoCEN cen = new PedidoCEN();
                cen.Destroy(id);
                return RedirectToAction(" Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
