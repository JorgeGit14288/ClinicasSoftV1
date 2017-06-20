using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Clinicas.Models;

namespace WebApp.Areas.Clinicas.Controllers
{
    public class EmpleadosController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Empleados
        public async Task<ActionResult> Index()
        {
            var empleados = db.empleados.Include(e => e.clinicas);
            return View(await empleados.ToListAsync());
        }

        // GET: Clinicas/Empleados/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = await db.empleados.FindAsync(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Clinicas/Empleados/Create
        public ActionResult Create()
        {
            ViewBag.idClinica = new SelectList(db.clinicas, "idClinica", "nombre");
            return View();
        }

        // POST: Clinicas/Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idEmpleado,nombres,apellidos,direccion,celular,tel_casa,correo,activo,cargo,idClinica")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.empleados.Add(empleados);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idClinica = new SelectList(db.clinicas, "idClinica", "nombre", empleados.idClinica);
            return View(empleados);
        }

        // GET: Clinicas/Empleados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = await db.empleados.FindAsync(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClinica = new SelectList(db.clinicas, "idClinica", "nombre", empleados.idClinica);
            return View(empleados);
        }

        // POST: Clinicas/Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idEmpleado,nombres,apellidos,direccion,celular,tel_casa,correo,activo,cargo,idClinica")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idClinica = new SelectList(db.clinicas, "idClinica", "nombre", empleados.idClinica);
            return View(empleados);
        }

        // GET: Clinicas/Empleados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = await db.empleados.FindAsync(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Clinicas/Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            empleados empleados = await db.empleados.FindAsync(id);
            db.empleados.Remove(empleados);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
