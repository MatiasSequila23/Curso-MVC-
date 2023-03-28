using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WEB_PROYECTOS.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            var dptos= DepartamentoCN.ListarDepartamentos();
            return View(dptos);
        }
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Departamento dpto)
        {
            try
            {
                if (dpto.NombreDepartamento==null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre de un departamento.");
                    return View(dpto);
                }
                DepartamentoCN.Agregar(dpto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Ocurrio un error al agregar un Departamento");
                return View(dpto);
            }
        }

        public ActionResult GetDepartamento(int id)
        {
            var dpto = DepartamentoCN.GetDepartamento(id); 
            return View(dpto);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var dpto = DepartamentoCN.GetDepartamento(id);
            return View(dpto);
        }
        [HttpPost]
        public ActionResult Editar(Departamento dpto)
        {
            try
            {
                if (dpto.NombreDepartamento == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre de un departamento.");
                    return View(dpto);
                }
                DepartamentoCN.Editar(dpto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al editar un Departamento");
                return View(dpto);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            if (id== null)
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var dpto = DepartamentoCN.GetDepartamento(id.Value);
            return View(dpto);
        }
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                DepartamentoCN.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al eliminar un Departamento");
                return View();
            }
        }
    }
}