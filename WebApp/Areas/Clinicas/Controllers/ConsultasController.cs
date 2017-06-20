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
    public class ConsultasController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Consultas
        public async Task<ActionResult> Index()
        {
            var consultas = db.consultas.Include(c => c.medicos).Include(c => c.pacientes);
            return View(await consultas.ToListAsync());
        }

        // GET: Clinicas/Consultas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultas consultas = await db.consultas.FindAsync(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            return View(consultas);
        }

        // GET: Clinicas/Consultas/Create
        public ActionResult Create()
        {
            ViewBag.idMedico = new SelectList(db.medicos, "idMedico", "colegiado_no");
            ViewBag.idPaciente = new SelectList(db.pacientes, "idPaciente", "dpi");
            return View();
        }

        // POST: Clinicas/Consultas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idConsultas,idMedico,idPaciente,fecha,hora_inicio,hora_fin,descripcion")] consultas consultas)
        {
            if (ModelState.IsValid)
            {
                db.consultas.Add(consultas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idMedico = new SelectList(db.medicos, "idMedico", "colegiado_no", consultas.idMedico);
            ViewBag.idPaciente = new SelectList(db.pacientes, "idPaciente", "dpi", consultas.idPaciente);
            return View(consultas);
        }

        // GET: Clinicas/Consultas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultas consultas = await db.consultas.FindAsync(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedico = new SelectList(db.medicos, "idMedico", "colegiado_no", consultas.idMedico);
            ViewBag.idPaciente = new SelectList(db.pacientes, "idPaciente", "dpi", consultas.idPaciente);
            return View(consultas);
        }

        // POST: Clinicas/Consultas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idConsultas,idMedico,idPaciente,fecha,hora_inicio,hora_fin,descripcion")] consultas consultas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idMedico = new SelectList(db.medicos, "idMedico", "colegiado_no", consultas.idMedico);
            ViewBag.idPaciente = new SelectList(db.pacientes, "idPaciente", "dpi", consultas.idPaciente);
            return View(consultas);
        }

        // GET: Clinicas/Consultas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultas consultas = await db.consultas.FindAsync(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            return View(consultas);
        }

        // POST: Clinicas/Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            consultas consultas = await db.consultas.FindAsync(id);
            db.consultas.Remove(consultas);
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
