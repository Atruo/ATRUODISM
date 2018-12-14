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
    public class UsuarioController : BasicController
    {

        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioCEN usuario = new UsuarioCEN();
            IList<UsuarioEN> listUsuEn = usuario.ReadAll(0, -1).ToList();
            IEnumerable<UsuarioViewModel> listUsu = new AssemblerUsuario().ConvertListENToModel(listUsuEn).ToList();
            return View(listUsu);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            UsuarioViewModel usu = new UsuarioViewModel();
            return View(usu);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usu)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.New_(usu.NUsuario, usu.Email, usu.FecNam, usu.Nombre, usu.Apellidos, usu.Foto, usu.Tipo, usu.Password);
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
            UsuarioViewModel usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = new AssemblerUsuario().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usu)
        {
            try
            {
                UsuarioCEN cen = new UsuarioCEN();
                cen.Modify(usu.NUsuario, usu.Email, usu.FecNam, usu.Nombre, usu.Apellidos, usu.Foto, usu.Tipo, usu.Password);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(String id)
        {
            UsuarioViewModel usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = new AssemblerUsuario().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);

        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                UsuarioCEN usu = new UsuarioCEN();
                usu.Destroy(usuario.NUsuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
        
    
        
