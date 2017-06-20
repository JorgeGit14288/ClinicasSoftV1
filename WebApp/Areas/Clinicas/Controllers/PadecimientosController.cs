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
    public class PadecimientosController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Padecimientos
        public async Task<ActionResult> Index()
        {
            return View(await db.padecimientos.ToListAsync());
        }

        // GET: Clinicas/Padecimientos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            padecimientos padecimientos = await db.padecimientos.FindAsync(id);
            if (padecimientos == null)
            {
                return HttpNotFound();
            }
            return View(padecimientos);
        }

        // GET: Clinicas/Padecimientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Padecimientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idPadecimientos,nombre,descripcion")] padecimientos padecimientos)
        {
            if (ModelState.IsValid)
            {
                db.padecimientos.Add(padecimientos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(padecimientos);
        }

        // GET: Clinicas/Padecimientos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            padecimientos padecimientos = await db.padecimientos.FindAsync(id);
            if (padecimientos == null)
            {
                return HttpNotFound();
            }
            return View(padecimientos);
        }

        // POST: Clinicas/Padecimientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idPadecimientos,nombre,descripcion")] padecimientos padecimientos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(padecimientos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(padecimientos);
        }

        // GET: Clinicas/Padecimientos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            padecimientos padecimientos = await db.padecimientos.FindAsync(id);
            if (padecimientos == null)
            {
                return HttpNotFound();
            }
            return View(padecimientos);
        }

        // POST: Clinicas/Padecimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            padecimientos padecimientos = await db.padecimientos.FindAsync(id);
            db.padecimientos.Remove(padecimientos);
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
