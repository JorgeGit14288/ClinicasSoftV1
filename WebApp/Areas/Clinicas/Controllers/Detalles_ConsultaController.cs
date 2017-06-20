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
    public class Detalles_ConsultaController : Controller
    {
        private ClinicasBdEntities db = new ClinicasBdEntities();

        // GET: Clinicas/Detalles_Consulta
        public async Task<ActionResult> Index()
        {
            var detalles_consulta = db.detalles_consulta.Include(d => d.consultas).Include(d => d.padecimientos);
            return View(await detalles_consulta.ToListAsync());
        }

        // GET: Clinicas/Detalles_Consulta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles_consulta detalles_consulta = await db.detalles_consulta.FindAsync(id);
            if (detalles_consulta == null)
            {
                return HttpNotFound();
            }
            return View(detalles_consulta);
        }

        // GET: Clinicas/Detalles_Consulta/Create
        public ActionResult Create()
        {
            ViewBag.idConsulta = new SelectList(db.consultas, "idConsultas", "descripcion");
            ViewBag.idPadecimiento = new SelectList(db.padecimientos, "idPadecimientos", "nombre");
            return View();
        }

        // POST: Clinicas/Detalles_Consulta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idDetalle,idConsulta,idPadecimiento,descripcion")] detalles_consulta detalles_consulta)
        {
            if (ModelState.IsValid)
            {
                db.detalles_consulta.Add(detalles_consulta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idConsulta = new SelectList(db.consultas, "idConsultas", "descripcion", detalles_consulta.idConsulta);
            ViewBag.idPadecimiento = new SelectList(db.padecimientos, "idPadecimientos", "nombre", detalles_consulta.idPadecimiento);
            return View(detalles_consulta);
        }

        // GET: Clinicas/Detalles_Consulta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles_consulta detalles_consulta = await db.detalles_consulta.FindAsync(id);
            if (detalles_consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsulta = new SelectList(db.consultas, "idConsultas", "descripcion", detalles_consulta.idConsulta);
            ViewBag.idPadecimiento = new SelectList(db.padecimientos, "idPadecimientos", "nombre", detalles_consulta.idPadecimiento);
            return View(detalles_consulta);
        }

        // POST: Clinicas/Detalles_Consulta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idDetalle,idConsulta,idPadecimiento,descripcion")] detalles_consulta detalles_consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalles_consulta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idConsulta = new SelectList(db.consultas, "idConsultas", "descripcion", detalles_consulta.idConsulta);
            ViewBag.idPadecimiento = new SelectList(db.padecimientos, "idPadecimientos", "nombre", detalles_consulta.idPadecimiento);
            return View(detalles_consulta);
        }

        // GET: Clinicas/Detalles_Consulta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalles_consulta detalles_consulta = await db.detalles_consulta.FindAsync(id);
            if (detalles_consulta == null)
            {
                return HttpNotFound();
            }
            return View(detalles_consulta);
        }

        // POST: Clinicas/Detalles_Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            detalles_consulta detalles_consulta = await db.detalles_consulta.FindAsync(id);
            db.detalles_consulta.Remove(detalles_consulta);
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
