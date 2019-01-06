using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Assembler;
using CervezUAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CervezUAWeb.Controllers
{
    public class ArtValController : BasicController
    {
        // GET: ArtVal
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArtVal/Details/5
        public ActionResult Details(int id)
        {
            CervezaViewModel usu = null;
            IEnumerable<ValoracionViewModel> val = null;
            ArtValViewModel artVal = new ArtValViewModel();


            CervezaCEN cerCEN = new CervezaCEN();
            CervezaEN usuEN = cerCEN.ReadOID(id);
            ValoracionCEN valCEN = new ValoracionCEN();
            usu = new AssemblerCerveza().ConvertENToModelUI(usuEN);
            IList<ValoracionEN> valEN = valCEN.ReadAll(0, -1).ToList();
            IList<ValoracionEN> bueno = new List<ValoracionEN>();
            foreach (var item in valEN)
            {
                if (item.Articulo.Id == id)
                {
                    bueno.Add(item);
                }
            }
          
            usu = new AssemblerCerveza().ConvertENToModelUI(usuEN);
            val = new AssemblerValoracion().ConvertListENToModel(bueno).ToList();
            artVal.cerveza = usu;
            artVal.valoraciones = val;

            
            return View(artVal);
            
        }

        // GET: ArtVal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtVal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtVal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtVal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtVal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtVal/Delete/5
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
