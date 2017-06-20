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
    public class Detalles_RecetaController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Detalles_Receta
        public async Task<ActionResult> Index()
        {
            var detalles_receta = db.detalles_receta.Include(d => d.medicamentos).Include(d => d.recetas);
            return View(await detalles_receta.ToListAsync());
        }

        // GET: Clinicas/Detalles_Receta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles_receta detalles_receta = await db.detalles_receta.FindAsync(id);
            if (detalles_receta == null)
            {
                return HttpNotFound();
            }
            return View(detalles_receta);
        }

        // GET: Clinicas/Detalles_Receta/Create
        public ActionResult Create()
        {
            ViewBag.idMedicamento = new SelectList(db.medicamentos, "idMedicamentos", "nombre");
            ViewBag.idReceta = new SelectList(db.recetas, "idRecetas", "observaciones");
            return View();
        }

        // POST: Clinicas/Detalles_Receta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idDetalle,idReceta,idMedicamento,dosis,observaciones")] detalles_receta detalles_receta)
        {
            if (ModelState.IsValid)
            {
                db.detalles_receta.Add(detalles_receta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idMedicamento = new SelectList(db.medicamentos, "idMedicamentos", "nombre", detalles_receta.idMedicamento);
            ViewBag.idReceta = new SelectList(db.recetas, "idRecetas", "observaciones", detalles_receta.idReceta);
            return View(detalles_receta);
        }

        // GET: Clinicas/Detalles_Receta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles_receta detalles_receta = await db.detalles_receta.FindAsync(id);
            if (detalles_receta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedicamento = new SelectList(db.medicamentos, "idMedicamentos", "nombre", detalles_receta.idMedicamento);
            ViewBag.idReceta = new SelectList(db.recetas, "idRecetas", "observaciones", detalles_receta.idReceta);
            return View(detalles_receta);
        }

        // POST: Clinicas/Detalles_Receta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idDetalle,idReceta,idMedicamento,dosis,observaciones")] detalles_receta detalles_receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalles_receta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idMedicamento = new SelectList(db.medicamentos, "idMedicamentos", "nombre", detalles_receta.idMedicamento);
            ViewBag.idReceta = new SelectList(db.recetas, "idRecetas", "observaciones", detalles_receta.idReceta);
            return View(detalles_receta);
        }

        // GET: Clinicas/Detalles_Receta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles_receta detalles_receta = await db.detalles_receta.FindAsync(id);
            if (detalles_receta == null)
            {
                return HttpNotFound();
            }
            return View(detalles_receta);
        }

        // POST: Clinicas/Detalles_Receta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            detalles_receta detalles_receta = await db.detalles_receta.FindAsync(id);
            db.detalles_receta.Remove(detalles_receta);
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
