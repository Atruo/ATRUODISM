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

namespace CervezUAWeb.Views
{
    public class FacturaController : BasicController
    {
        // GET: Factura
        public ActionResult Index()
        {
            FacturaCEN fac = new FacturaCEN();

            IList<FacturaEN> listaFactura = fac.ReadAll(0, -1).ToList();
            IEnumerable<FacturaViewModel> list = new AssemblerFactura().ConvertListENToModel(listaFactura).ToList();
            return View(list);
        }

        // GET: Factura/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            FacturaViewModel facturaEN = new FacturaViewModel();
            return View(facturaEN);
        }

        // POST: Factura/Create
        [HttpPost]
        public ActionResult Create(FacturaViewModel factura)
        {
            try
            {
                FacturaCEN fac = new FacturaCEN();
                fac.New_(factura.Pedido, factura.Importe, factura.Direccion, factura.MetodoPago);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int id)
        {
            FacturaViewModel fac = null;
            SessionInitialize();
            FacturaEN facEN = new FacturaCAD(session).ReadOIDDefault(id);
            fac = new AssemblerFactura().ConvertENToModelUI(facEN);
            SessionClose();

            return View(fac);
        }

        // POST: Factura/Edit/5
        [HttpPost]
        public ActionResult Edit(FacturaViewModel factura)
        {
            try
            {
                FacturaCEN fac = new FacturaCEN();
                fac.Modify(factura.id, factura.Importe, factura.Direccion, factura.MetodoPago);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int id)
        {
            FacturaViewModel fac = null;
            SessionInitialize();
            FacturaEN facEN = new FacturaCAD(session).ReadOIDDefault(id);
            fac = new AssemblerFactura().ConvertENToModelUI(facEN);
            SessionClose();
            return View(fac);
        }

        // POST: Factura/Delete/5
        [HttpPost]
        public ActionResult Delete(FacturaViewModel factura)
        {
            try
            {
                FacturaCEN fac = new FacturaCEN();
                fac.Destroy(factura.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
