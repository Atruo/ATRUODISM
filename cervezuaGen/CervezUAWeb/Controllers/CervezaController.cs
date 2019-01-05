using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.CP.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Assembler;
using CervezUAWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                int control = 0;
                foreach (var item in listaAux)
                {
                    if (control == 0)
                    {
                        var aux = item.Replace("[", "").Replace("]", "").Replace("\"", "");
                        System.Diagnostics.Debug.WriteLine("Añado: " + aux);
                        converted.Add(Int32.Parse(aux));
                        control = 1;
                    }else
                    {
                        control = 0;
                    }

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
        public ActionResult Create(CervezaViewModel cerveza, HttpPostedFileBase file)
        {
            string fileName = "", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                System.Diagnostics.Debug.WriteLine("Entro en el if ");
                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                System.Diagnostics.Debug.WriteLine(fileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Content/IMG"), fileName);
                System.Diagnostics.Debug.WriteLine(path);
                //string pathDef = path.Replace(@"\\", @"\");
                file.SaveAs(path);
            }
            try
            {
                fileName = "/Content/IMG/" + fileName;
                System.Diagnostics.Debug.WriteLine("Nombre: "+ fileName);
                CervezaCEN art = new CervezaCEN();
                art.New_(cerveza.Nombre, cerveza.Stock, cerveza.Precio, cerveza.ValMedia, cerveza.Descripcion, fileName, cerveza.Marca, cerveza.Volumen, cerveza.Unidades, cerveza.Graduacion, cerveza.Tipo);
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
        public ActionResult Comprar()
        {
    /*
            SessionInitialize();
            string lista = Request.Cookies["carrito"].Value;

            if (lista != "")
            {
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
                CervezaCEN cerv = new CervezaCEN();
                IList<CervezaEN> listaArticulos = new List<CervezaEN>();
                IList<LineaPedidoEN> linea = new List<LineaPedidoEN>();
                System.Diagnostics.Debug.WriteLine("Antes for each");
                foreach (var item in converted)
                {

                    listaArticulos.Add(cerv.ReadOID(item));
                }
                System.Diagnostics.Debug.WriteLine("Antes for for");
                for (int i = 0; i < converted.Count(); i++)
                {
                    System.Diagnostics.Debug.WriteLine("Entro");
                    LineaPedidoCEN lin = new LineaPedidoCEN();
                    System.Diagnostics.Debug.WriteLine("Peto aqui");
                    System.Diagnostics.Debug.WriteLine(converted2[i]+listaArticulos[i].Nombre);
                    int id = lin.New_(converted2[i], listaArticulos[i]);
                    System.Diagnostics.Debug.WriteLine("Peto aqui 2");

                    linea.Add(lin.ReadOID(id));
                    System.Diagnostics.Debug.WriteLine("Peto aqui 3");

                }
                System.Diagnostics.Debug.WriteLine("Despues for ");

                string usuario = Request.Cookies["id"].Value;
                UsuarioCAD usu = new UsuarioCAD(session);              
                UsuarioEN u = usu.ReadOIDDefault(usuario);
                UsuarioCP usua = new UsuarioCP(session);
                usua.Comprar(usuario, linea);
                System.Diagnostics.Debug.WriteLine("Chorizo");
                
                SessionClose();
                return View(listaArticulos);
            }
            else
            {
                return Redirect("/Cerveza/Carrito"); 
            }*/

            string lista = Request.Cookies["carrito"].Value;
            string usu = Request.Cookies["id"].Value;

            if (lista != "")
            {
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
                        control = 0;
                    }

                }
                CervezaCEN art = new CervezaCEN();
                LineaPedidoCEN linea = new LineaPedidoCEN();
                PedidoCEN pedido = new PedidoCEN();
                IList<LineaPedidoEN> listaLineas = new List<LineaPedidoEN>();
                System.Diagnostics.Debug.WriteLine("Hasta qui bien");
                for (int i = 0; i < converted.Count(); i++)
                {
                    System.Diagnostics.Debug.WriteLine("Entro");
                    LineaPedidoEN lin = linea.ReadOID(linea.New_(converted2[i], art.ReadOID(converted[i])));                    
                    listaLineas.Add(lin);
                }
                 pedido.New_(usu, (CervezUAGenNHibernate.Enumerated.CervezUA.EstadoPedidoEnum)1, listaLineas);
               
                return View();

            }else
             {
               return View();
             }

        }
    }
}
