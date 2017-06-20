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
    public class RecetasController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Recetas
        public async Task<ActionResult> Index()
        {
            var recetas = db.recetas.Include(r => r.consultas);
            return View(await recetas.ToListAsync());
        }

        // GET: Clinicas/Recetas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetas recetas = await db.recetas.FindAsync(id);
            if (recetas == null)
            {
                return HttpNotFound();
            }
            return View(recetas);
        }

        // GET: Clinicas/Recetas/Create
        public ActionResult Create()
        {
            ViewBag.idConsulta = new SelectList(db.consultas, "idConsultas", "descripcion");
            return View();
        }

        // POST: Clinicas/Recetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idRecetas,idConsulta,observaciones")] recetas recetas)
        {
            if (ModelState.IsValid)
            {
                db.recetas.Add(recetas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idConsulta = new SelectList(db.consultas, "idConsultas", "descripcion", recetas.idConsulta);
            return View(recetas);
        }

        // GET: Clinicas/Recetas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetas recetas = await db.recetas.FindAsync(id);
            if (recetas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsulta = new SelectList(db.consultas, "idConsultas", "descripcion", recetas.idConsulta);
            return View(recetas);
        }

        // POST: Clinicas/Recetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idRecetas,idConsulta,observaciones")] recetas recetas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recetas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idConsulta = new SelectList(db.consultas, "idConsultas", "descripcion", recetas.idConsulta);
            return View(recetas);
        }

        // GET: Clinicas/Recetas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetas recetas = await db.recetas.FindAsync(id);
            if (recetas == null)
            {
                return HttpNotFound();
            }
            return View(recetas);
        }

        // POST: Clinicas/Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            recetas recetas = await db.recetas.FindAsync(id);
            db.recetas.Remove(recetas);
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
