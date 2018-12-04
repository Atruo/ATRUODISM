using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.EN.CervezUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CervezUAWeb.Controllers
{
    public class UsuarioController : BasicController
    {
        private object articuloCAD;

        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioCEN usuario = new UsuarioCEN();
            IEnumerable<UsuarioEN> listaUsuarios = usuario.ReadAll(0, -1).ToList();
            return View(listaUsuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            UsuarioEN usuarioEN = new UsuarioEN();
            return View(usuarioEN);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioEN usu)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.New_(usu.NUsuario, usu.Email, usu.FecNam, usu.Nombre, usu.Apellidos, usu.Foto, usu.Tipo, usu.Pass);
                this.SessionClose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(String id)
        {
            UsuarioEN usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);

            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
