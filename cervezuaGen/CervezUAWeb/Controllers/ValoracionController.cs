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
            ValoracionViewModel val = null;
            SessionInitialize();
            ValoracionEN valEN = new ValoracionCAD(session).ReadOIDDefault(id);
            val = new AssemblerValoracion().ConvertENToModelUI(valEN);
            SessionClose();

            return View(val);
        }

        // GET: Valoracion/Create
        public ActionResult Create(int id)
        {
            try
            {
                if (Request.Cookies["id"].Value != null)
                {
                    string usu = Request.Cookies["id"].Value;
                    ValoracionViewModel ValoracionEN = new ValoracionViewModel();
                    ValoracionEN.Articulo = id;
                    ValoracionEN.Usuario = usu;
                    return View(ValoracionEN);
                }
                else
                {
                    return Redirect("/ArtVal/Details/" + id);
                }
            }
            catch (Exception)
            {

                return Redirect("/ArtVal/Details/" + id);
            }
            
            
        }

        // POST: Valoracion/Create
        [HttpPost]
        public ActionResult Create(int articulo, string usuario, double valoracion, string texto)
        {
            ValoracionCEN valo = new ValoracionCEN();

            IList<ValoracionEN> listaValoraciones = valo.ReadAll(0, -1).ToList();
            IEnumerable<ValoracionViewModel> list = new AssemblerValoracion().ConvertListENToModel(listaValoraciones).ToList();
            bool crear = true;
            foreach (var item in list)
            {
                if (item.Usuario == usuario)
                {
                    crear = false;
                }
            }

            try
            {
                if (crear)
                {
                    ValoracionCEN val = new ValoracionCEN();
                    val.New_(articulo, usuario, valoracion, texto);
                    ArticuloCEN arCEN = new ArticuloCEN();
                    ArticuloEN art = arCEN.ReadOID(articulo);
                    System.Diagnostics.Debug.WriteLine("Peto aqui");

                    ValoracionCEN valor = new ValoracionCEN();
                    IList<ValoracionEN> lis = valor.ReadAll(0, -1).ToList();
                    System.Diagnostics.Debug.WriteLine("Peto aqui2");
                    double sum = 0;
                    int cont = 0;
                    foreach (var item in lis)
                    {
                        if (articulo == art.Id)
                        {
                            sum = sum + item.Valoracion;
                            cont = cont + 1;
                        }
                    }
                    System.Diagnostics.Debug.WriteLine("Peto aqui 3");
                    System.Diagnostics.Debug.WriteLine(sum);
                    System.Diagnostics.Debug.WriteLine(cont);
                    sum = sum / cont;
                    System.Diagnostics.Debug.WriteLine("Peto aqui4");
                    System.Diagnostics.Debug.WriteLine(art.Id);
                    System.Diagnostics.Debug.WriteLine(sum);
                    arCEN.Modify(art.Id,art.Nombre,art.Stock, art.Precio, sum, art.Descripcion, art.Imagen, art.Marca);
                    System.Diagnostics.Debug.WriteLine("Peto aqui5");
                    return Redirect("/ArtVal/Details/" + articulo);
                }
                else
                {
                    return Redirect("/ArtVal/Details/" + articulo);
                }
                
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
                val.Modify(valoracion.id, valoracion.Valoracion, valoracion.Texto);
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

        public ActionResult Valoraciones(string id)
        {
            ValoracionCEN val = new ValoracionCEN();
            IList<ValoracionEN> listaValoraciones = val.ReadAll(0, -1).ToList();
            IList<ValoracionEN> listaValoraciones2 = new List<ValoracionEN>();
            foreach (var item in listaValoraciones)
            {
                if (item.Articulo.Id == Int32.Parse(id))
                {
                    listaValoraciones2.Add(item);
                }
            }
            IEnumerable<ValoracionViewModel> list = new AssemblerValoracion().ConvertListENToModel(listaValoraciones2).ToList();
            return View(list);
        }
    }
}
