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
    public class MedicamentosController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Medicamentos
        public async Task<ActionResult> Index()
        {
            return View(await db.medicamentos.ToListAsync());
        }

        // GET: Clinicas/Medicamentos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicamentos medicamentos = await db.medicamentos.FindAsync(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            return View(medicamentos);
        }

        // GET: Clinicas/Medicamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Medicamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idMedicamentos,nombre,productora,presentacion,precio,descripcion")] medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                db.medicamentos.Add(medicamentos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(medicamentos);
        }

        // GET: Clinicas/Medicamentos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicamentos medicamentos = await db.medicamentos.FindAsync(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            return View(medicamentos);
        }

        // POST: Clinicas/Medicamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idMedicamentos,nombre,productora,presentacion,precio,descripcion")] medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamentos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(medicamentos);
        }

        // GET: Clinicas/Medicamentos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicamentos medicamentos = await db.medicamentos.FindAsync(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            return View(medicamentos);
        }

        // POST: Clinicas/Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            medicamentos medicamentos = await db.medicamentos.FindAsync(id);
            db.medicamentos.Remove(medicamentos);
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
