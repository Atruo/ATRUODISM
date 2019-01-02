﻿using CervezUAGenNHibernate.CAD.CervezUA;
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
        public ActionResult Details(String id)
        {
            UsuarioViewModel usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = new AssemblerUsuario().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        // GET: Usuario/Create
        public ActionResult Create(String access)
        {
            if (access != null)
            {
                return Redirect("/Usuario/Create/?access=no");
            }
            else
            {
                UsuarioViewModel usu = new UsuarioViewModel();
                return View(usu);
            }
            
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usu)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioCEN usuario = new UsuarioCEN();
                IList<UsuarioEN> listUsuEn = usuario.ReadAll(0, -1).ToList();
                Boolean existe = false;
                foreach (var item in listUsuEn)
                {
                    if(item.Nombre == usu.Nombre)
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    UsuarioCEN usuarioCEN = new UsuarioCEN();
                    usuarioCEN.New_(usu.NUsuario, usu.Email, usu.FecNam, usu.Nombre, usu.Apellidos, usu.Foto, usu.Tipo, usu.Password);

                    return RedirectToAction("Index");
                }
                else
                {
                    return Redirect("/Usuario/Create/?access=no");
                }

                
                
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

        public ActionResult Login()
        {
            UsuarioCEN usuario = new UsuarioCEN();
            IList<UsuarioEN> listUsuEn = usuario.ReadAll(0, -1).ToList();
            IEnumerable<UsuarioViewModel> listUsu = new AssemblerUsuario().ConvertListENToModel(listUsuEn).ToList();
            return View(listUsu);
        }
        public ActionResult Denegado()
        {
            return Redirect("/Articulo/Index");
        }

        public ActionResult Pass(String id)
        {
            if (id != "")
            {
                ViewData["nombre"] = id;
            }
            else
            {
                ViewData["nombre"] = "";
            }
           
            return View();
        }

        // GET: Usuario/LoginV/5
        public ActionResult LoginV(String id, String psw)
        {
            
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            UsuarioCEN usuario = new UsuarioCEN();
            IList<UsuarioEN> listUsuEn = usuario.ReadAll(0, -1).ToList();
            String url = "/Usuario/Login/?access=no";
            try
            {
                foreach (var item in listUsuEn)
                {
                    if (item.Nombre == usuEN.Nombre)
                    {
                        if (item.Pass.Equals(CervezUAGenNHibernate.Utils.Util.GetEncondeMD5(psw)))
                        {
                            url = "/?id="+ item.Nombre;                           

                        }

                    }
                }
            }
            catch (Exception)
            {

                
            }
            
            SessionClose();
            return Redirect(url);
        }

        public ActionResult Carrito()
        {
            
            return View();
        }

    }
}
        
    
        
