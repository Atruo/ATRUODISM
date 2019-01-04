using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Assembler;
using CervezUAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CervezUAWeb.Controllers
{
    public class CervezaController : BasicController
    {
        // GET: Cerveza
        public ActionResult Index(String data)
        {
            
            if (data != null)
            {
                CervezaCEN art = new CervezaCEN();
                
                IList<CervezaEN> listaArticulos = art.ReadAll(0, -1).ToList();
                IList<CervezaEN> listaArticulos2 = new List<CervezaEN>();
                foreach (var item in listaArticulos)
                {
                    if (item.Nombre.Contains(data))
                    {
                        listaArticulos2.Add(item);
                    }
                }
                IEnumerable<CervezaViewModel> list = new AssemblerCerveza().ConvertListENToModel(listaArticulos2).ToList();
                return View(list);
            }
            else
            {
                CervezaCEN art = new CervezaCEN();

                IList<CervezaEN> listaArticulos = art.ReadAll(0, -1).ToList();
                IEnumerable<CervezaViewModel> list = new AssemblerCerveza().ConvertListENToModel(listaArticulos).ToList();
                return View(list);
            }
           
        }

        public ActionResult Buscar(String data)
        {
         
            if (data != null)
            {
                CervezaCEN art = new CervezaCEN();

                IList<CervezaEN> listaArticulos = art.ReadAll(0, -1).ToList();
                IList<CervezaEN> listaArticulos2 = new List<CervezaEN>();
                foreach (var item in listaArticulos)
                {
                    if (item.Nombre.ToLower().Contains(data.ToLower()))
                    {
                        System.Diagnostics.Debug.WriteLine("Añado: " + item.Nombre);
                        listaArticulos2.Add(item);
                    }
                }
                IEnumerable<CervezaViewModel> list = new AssemblerCerveza().ConvertListENToModel(listaArticulos2).ToList();
                return View(list);
            }
            else
            {
                CervezaCEN art = new CervezaCEN();

                IList<CervezaEN> listaArticulos = art.ReadAll(0, -1).ToList();
                IEnumerable<CervezaViewModel> list = new AssemblerCerveza().ConvertListENToModel(listaArticulos).ToList();
                return View(list);
            }

        }

        public ActionResult Carrito()
        {

                string lista = Request.Cookies["carrito"].Value;
                if (lista != "")
                {
                    string[] listaAux = lista.Split(',');
                    List<int> converted = new List<int>();
                    foreach (var item in listaAux)
                    {
                        var aux = item.Replace("[", "").Replace("]", "").Replace("\"", "");
                        System.Diagnostics.Debug.WriteLine("Añado: " + aux);
                        converted.Add(Int32.Parse(aux));
                    }
                    CervezaCEN art = new CervezaCEN();
                    IList<CervezaEN> listaArticulos = new List<CervezaEN>();
                    foreach (var item in converted)
                    {

                        listaArticulos.Add(art.ReadOID(item));
                    }
                    IEnumerable<CervezaViewModel> list = new AssemblerCerveza().ConvertListENToModel(listaArticulos).ToList();
                    return View(list);
                }else
                {
                    return View();
                }
               

        }


        // GET: Cerveza/Details/5
        public ActionResult Details(int id)
        {
            CervezaViewModel usu = null;
            SessionInitialize();
            CervezaEN usuEN = new CervezaCAD(session).ReadOIDDefault(id);
            usu = new AssemblerCerveza().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        // GET: Cerveza/Create
        public ActionResult Create()
        {
            CervezaViewModel usuarioEN = new CervezaViewModel();
            return View(usuarioEN);
        }

        // POST: Cerveza/Create
        [HttpPost]
        public ActionResult Create(CervezaViewModel articulo)
        {
            try
            {
                CervezaCEN art = new CervezaCEN();
                art.New_(articulo.Nombre, articulo.Stock, articulo.Precio, articulo.ValMedia, articulo.Descripcion, articulo.Imagen, articulo.Marca, articulo.Volumen, articulo.Unidades, articulo.Graduacion, articulo.Tipo);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        // GET: Cerveza/Edit/5
        public ActionResult Edit(int id)
        {
            CervezaViewModel usu = null;
            SessionInitialize();
            CervezaEN usuEN = new CervezaCAD(session).ReadOIDDefault(id);
            usu = new AssemblerCerveza().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        // POST: Cerveza/Edit/5
        [HttpPost]
        public ActionResult Edit(CervezaViewModel articulo)
        {
            try
            {
                CervezaCEN cen = new CervezaCEN();
                cen.Modify(articulo.id, articulo.Nombre, articulo.Stock, articulo.Precio, articulo.ValMedia, articulo.Descripcion, articulo.Imagen, articulo.Marca, articulo.Volumen, articulo.Unidades, articulo.Graduacion, articulo.Tipo);
                return RedirectToAction("Index", new { id = articulo.id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Cerveza/Delete/5
        public ActionResult Delete(int id)
        {
            CervezaViewModel usu = null;
            SessionInitialize();
            CervezaEN usuEN = new CervezaCAD(session).ReadOIDDefault(id);
            usu = new AssemblerCerveza().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        // POST: Cerveza/Delete/5
        [HttpPost]
        public ActionResult Delete(CervezaViewModel articulo)
        {
            try
            {
                CervezaCEN art = new CervezaCEN();
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
