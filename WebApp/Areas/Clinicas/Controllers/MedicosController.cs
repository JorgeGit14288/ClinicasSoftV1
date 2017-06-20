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
    public class MedicosController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Medicos
        public async Task<ActionResult> Index()
        {
            var medicos = db.medicos.Include(m => m.clinicas);
            return View(await medicos.ToListAsync());
        }

        // GET: Clinicas/Medicos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicos medicos = await db.medicos.FindAsync(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // GET: Clinicas/Medicos/Create
        public ActionResult Create()
        {
            ViewBag.idClinica = new SelectList(db.clinicas, "idClinica", "nombre");
            return View();
        }

        // POST: Clinicas/Medicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idMedico,colegiado_no,nombres,apellidos,direccion,celular,tel_casa,tel_otro,correo,idClinica")] medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.medicos.Add(medicos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idClinica = new SelectList(db.clinicas, "idClinica", "nombre", medicos.idClinica);
            return View(medicos);
        }

        // GET: Clinicas/Medicos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicos medicos = await db.medicos.FindAsync(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClinica = new SelectList(db.clinicas, "idClinica", "nombre", medicos.idClinica);
            return View(medicos);
        }

        // POST: Clinicas/Medicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idMedico,colegiado_no,nombres,apellidos,direccion,celular,tel_casa,tel_otro,correo,idClinica")] medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idClinica = new SelectList(db.clinicas, "idClinica", "nombre", medicos.idClinica);
            return View(medicos);
        }

        // GET: Clinicas/Medicos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicos medicos = await db.medicos.FindAsync(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // POST: Clinicas/Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            medicos medicos = await db.medicos.FindAsync(id);
            db.medicos.Remove(medicos);
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
