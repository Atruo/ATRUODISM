using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Models;
using CervezUAWeb.Assembler;
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
            IList<PedidoEN> listUsuEn = Pedido.ReadAll(0, -1).ToList();
            IEnumerable<PedidoViewModel> listUsu = new AssemblerPedido().ConvertListENToModel(listUsuEn).ToList();
            return View(listUsu);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            PedidoViewModel ped = null;
            SessionInitialize();
            PedidoEN pedEN = new PedidoCAD(session).ReadOIDDefault(id);
            ped = new AssemblerPedido().ConvertENToModelUI(pedEN);
            SessionClose();
            return View(ped);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            SessionInitialize();
            PedidoViewModel ped = new PedidoViewModel();
            IList<ArticuloEN> listaArticulos = new ArticuloCAD().ReadAllDefault(0, -1);
            IEnumerable<ArticuloViewModel> listaArtView = new AssemblerArticulo().ConvertListENToModel(listaArticulos);
            ViewData["listaArticulos"] = listaArtView;
            SessionClose();

            return View(ped);
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(PedidoViewModel ped)
        {
            try
            {
                PedidoCEN pedidoCEN = new PedidoCEN();
               // pedidoCEN.New_( ped.NUsuario, ped.Estado, ped.Lineas);
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
                //cen.Modify(ped.Id, ped.Estado);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {

                PedidoViewModel ped = null;
                SessionInitialize();
                PedidoEN pedEN = new PedidoCAD(session).ReadOIDDefault(id);
                ped = new AssemblerPedido().ConvertENToModelUI(pedEN);
                SessionClose();
                return View(ped);


        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(PedidoViewModel pedido)
        {
            try
            {
                CopaCEN cop = new CopaCEN();
                cop.Destroy(pedido.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult tramitar()
        {
            string id = Request.Cookies["id"].Value;
            string importe = Request.Cookies["coste"].Value;
            string mPago = Request.Cookies["mPago"].Value;
            string direccion = Request.Cookies["direccion"].Value;
            PedidoCEN pedidoCEN = new PedidoCEN();
            int oid = pedidoCEN.New_(id,(CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum)1 , Convert.ToDouble(importe),direccion, (CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum)Int32.Parse(mPago));
            LineaPedidoCEN lineaCEN = new LineaPedidoCEN();

            string lista = Request.Cookies["carrito"].Value;            
                string[] listaAux = lista.Split(',');
                List<int> converted = new List<int>();
                List<int> converted2 = new List<int>();
                int control = 0;
                foreach (var item in listaAux)
                {
                    if (control == 0)
                    {
                        var aux = item.Replace("[", "").Replace("]", "").Replace("\"", "");
                        System.Diagnostics.Debug.WriteLine("Añado: " + aux);
                        converted.Add(Int32.Parse(aux));
                        control = 1;
                    }
                    else
                    {
                        var aux = item.Replace("[", "").Replace("]", "").Replace("\"", "");
                        System.Diagnostics.Debug.WriteLine("Añado: " + aux);
                        converted2.Add(Int32.Parse(aux));
                        control = 0;
                    }

                }
                CervezaCEN art = new CervezaCEN();
                    for (int i = 0; i < converted.Count(); i++)
                    {
                        lineaCEN.New_( converted2[i], art.ReadOID(converted[i]).Id, oid);
                    }
               
            
            
            
            return Redirect("/Pedido/Pedidos");

        }
        public ActionResult Pedidos()
        {
            PedidoCEN art = new PedidoCEN();
            string id = Request.Cookies["id"].Value;
            IList<PedidoEN> listaPedidos = art.ReadAll(0, -1).ToList();
            IList<PedidoEN> converted = new List<PedidoEN>();
            foreach (var item in listaPedidos)
            {
                if (id == item.Usuario.NUsuario)
                {
                    converted.Add(item);
                }
            }
            IEnumerable<PedidoViewModel> list = new AssemblerPedido().ConvertListENToModel(converted).ToList();
            return View(list);
           
        }
    }
}
