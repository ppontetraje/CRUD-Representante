using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Representante.Models;


namespace CRUD_Representante.Controllers
{
    public class VistaController : Controller
    {
        // GET: Vista
        public ActionResult Index()
        {
            try
            {
                using (var db = new RepresentantesVista1())
                {
                    return View(db.RepresentanteView.ToList());
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}