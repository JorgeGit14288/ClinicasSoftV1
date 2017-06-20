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
    public class ClinicasController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Clinicas
        public async Task<ActionResult> Index()
        {
            return View(await db.clinicas.ToListAsync());
        }

        // GET: Clinicas/Clinicas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinicas clinicas = await db.clinicas.FindAsync(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // GET: Clinicas/Clinicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Clinicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idClinica,nombre,Especialidad,direccion,administrador,tel_1,tel_2,tel_3")] clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.clinicas.Add(clinicas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clinicas);
        }

        // GET: Clinicas/Clinicas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinicas clinicas = await db.clinicas.FindAsync(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Clinicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idClinica,nombre,Especialidad,direccion,administrador,tel_1,tel_2,tel_3")] clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinicas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clinicas);
        }

        // GET: Clinicas/Clinicas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinicas clinicas = await db.clinicas.FindAsync(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            clinicas clinicas = await db.clinicas.FindAsync(id);
            db.clinicas.Remove(clinicas);
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
