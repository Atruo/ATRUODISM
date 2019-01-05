using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CervezUAWeb.Controllers
{
    public class AdministradorController : BasicController
    {
        // GET: Admin
        public ActionResult Index()
        {
            AdministradorCEN usuario = new AdministradorCEN();
            IList<AdministradorEN> listUsuEn = usuario.ReadAll(0, -1).ToList();
            IEnumerable<AdministradorViewModel> listUsu = new AssemblerAdministrador().ConvertListENToModel(listUsuEn).ToList();
            return View(listUsu);
            
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            
            
                AdministradorViewModel usu = new AdministradorViewModel();
                return View(usu);
            
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(AdministradorViewModel articulo, HttpPostedFileBase file)
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
                path = Path.Combine(Server.MapPath("~/Content/Profile"), fileName);
                System.Diagnostics.Debug.WriteLine(path);
                //string pathDef = path.Replace(@"\\", @"\");
                file.SaveAs(path);
            }
            try
            {
                AdministradorCEN art = new AdministradorCEN();
                fileName = "/Content/Profile/" + fileName;
                art.New_(articulo.NUsuario, articulo.Email, articulo.FecNam, articulo.Nombre, articulo.Apellidos, fileName, articulo.Tipo, articulo.Password, articulo.Sueldo);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
        public ActionResult Panel()
        {
            return View();
        }
    }
}
