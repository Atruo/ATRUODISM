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
        public ActionResult Create(AdministradorViewModel articulo)
        {
            try
            {
                AdministradorCEN art = new AdministradorCEN();

                art.New_(articulo.NUsuario, articulo.Email, articulo.FecNam, articulo.Nombre, articulo.Apellidos, articulo.Foto, articulo.Tipo, articulo.Password, articulo.Sueldo);
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
    }
}
