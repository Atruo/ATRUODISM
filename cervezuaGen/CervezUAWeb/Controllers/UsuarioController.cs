using CervezUAGenNHibernate.CAD.CervezUA;
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
        public ActionResult Create(UsuarioViewModel usu, HttpPostedFileBase file, String psw)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioCEN usuario = new UsuarioCEN();
                IList<UsuarioEN> listUsuEn = usuario.ReadAll(0, -1).ToList();
                Boolean existe = false;
                foreach (var item in listUsuEn)
                {
                    if(item.NUsuario == usu.NUsuario)
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    string fileName = "", path = "";
                    // Verify that the user selected a file
                    if (file != null && file.ContentLength > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("Entro en el if ");
                        // extract only the fielname
                        fileName = Path.GetFileName(file.FileName);
                        fileName = usu.NUsuario +"."+ fileName.Split('.')[1];
                    
                        System.Diagnostics.Debug.WriteLine(fileName);
                        // store the file inside ~/App_Data/uploads folder
                        path = Path.Combine(Server.MapPath("~/Content/Profile"), fileName);
                        System.Diagnostics.Debug.WriteLine(path);
                        //string pathDef = path.Replace(@"\\", @"\");
                        file.SaveAs(path);
                    }
                    System.Diagnostics.Debug.WriteLine(psw);
                    
                    UsuarioCEN usuarioCEN = new UsuarioCEN();
                    fileName = "/Content/Profile/" + fileName;
                    usuarioCEN.New_(usu.NUsuario, usu.Email, usu.FecNam, usu.Nombre, usu.Apellidos, fileName, (CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum)1, psw);

                    return Redirect("Login");
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
        public ActionResult Edit(UsuarioViewModel usu, HttpPostedFileBase file, string psw)
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
                UsuarioCEN cen = new UsuarioCEN();
                UsuarioCEN comp = new UsuarioCEN();
                UsuarioEN compr = comp.ReadOID(usu.NUsuario);               
                String pass = "123";
                if (psw != "")
                {
                    pass = psw;
                }               
                
                
                if (fileName != "")
                {
                    fileName = "/Content/Profile/" + fileName;
                    cen.Modify(usu.NUsuario, usu.Email, usu.FecNam, usu.Nombre, usu.Apellidos, fileName, usu.Tipo, pass);
                }
                else
                {                   
                    cen.Modify(usu.NUsuario, usu.Email, usu.FecNam, usu.Nombre, usu.Apellidos, compr.Foto, usu.Tipo, pass);
                }
              


                /*UsuarioCEN cen = new UsuarioCEN();
                UsuarioEN usuario = new UsuarioEN();
                usuario.NUsuario = usu.NUsuario;
                usuario.Nombre = usu.Nombre;
                usuario.Apellidos = usu.Apellidos;
                usuario.Email = usu.Email;
                usuario.FecNam = usu.FecNam;
                usuario.Pass = usu.Password;
                usuario.Foto = fileName;
               
                cen.Editar( usuario, Request.Cookies["id"].Value, fileName);*/

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
            return Redirect("/Cerveza/Index");
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
                    if (item.NUsuario == usuEN.NUsuario)
                    {
                        if (item.Pass.Equals(CervezUAGenNHibernate.Utils.Util.GetEncondeMD5(psw)))
                        {
                            url = "/?id="+ item.NUsuario;                           

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

        public ActionResult toAdmin(String id, int admin)
        {
            try
            {               
                UsuarioCEN cen = new UsuarioCEN();              
                cen.ToAdmin(id, admin);              
                return Redirect("/Administrador/Panel");
            }
            catch (Exception)
            {

                 return Redirect("/Administrador/Panel");
            }           

        }

        

    }

}

    
        
