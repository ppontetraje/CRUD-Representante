using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Representante.Models;
using Microsoft.Ajax.Utilities;

namespace CRUD_Representante.Controllers
{
    public class RepresentanteController : Controller
    {
        // GET: Representante
        public ActionResult Index(string searchBy, string search)
        {
            try
            {
                using (var db = new RepresentanteContext())
                {
                    if (searchBy == "Nombres")
                    {
                        return View(db.Representante.Where(x => x.Nombres.StartsWith(search) || search == null).ToList());
                    }
                    else
                    {
                        return View(db.Representante.Where(x => x.Apellidos.StartsWith(search) || search == null).ToList());
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Representante representante)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new RepresentanteContext())
                {
                    db.Representante.Add(representante);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al agregar Representante");
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar2(string nombre, string apellido, string parentesco, string telefono)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                Representante rep = new Representante();
                rep.Nombres = nombre;
                rep.Apellidos = apellido;
                rep.Parentesco = parentesco;
                rep.Telefono = Int32.Parse(telefono);

                using (var db = new RepresentanteContext())
                {
                    db.Representante.Add(rep);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al agregar Representante");
                return View();
            }
        }
        public ActionResult Editar(int cedula)
        {
            try
            {
                using (var db = new RepresentanteContext())
                {
                    Representante rep = db.Representante.Find(cedula);
                    return View(rep);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Representante rep)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new RepresentanteContext())
                {
                    Representante representante = db.Representante.Find(rep.Cedula);

                    representante.Nombres = rep.Nombres;
                    representante.Apellidos = rep.Apellidos;
                    representante.Parentesco = rep.Parentesco;
                    representante.Telefono = rep.Telefono;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Detalles(int cedula)
        {
            try
            {
                using (var db = new RepresentanteContext())
                {
                    Representante rep = db.Representante.Find(cedula);
                    return View(rep);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Eliminar(int cedula)
        {
            using (var db = new RepresentanteContext())
            {
                Representante rep = db.Representante.Find(cedula);
                db.Representante.Remove(rep);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Buscar(string searchby, string search)
        {
            try
            {
                using (var db = new RepresentanteContext())
                {
                    if (searchby == "Apellido")
                    {
                        return View(db.Representante.Where(x => x.Apellidos == search || search == null).ToList());
                    }
                    else
                    {
                        return View(db.Representante.Where(x => x.Nombres.StartsWith(search) || search == null).ToList());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}