using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppPfeBackEnd.Models;

namespace AppPfeBackEnd.Controllers
{
    public class AdministrateursMVCController : Controller
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: AdministrateursMVC
        public async Task<ActionResult> Index()
        {
            return View(await db.Administrateurs.ToListAsync());
        }

        // GET: AdministrateursMVC/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = await db.Administrateurs.FindAsync(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // GET: AdministrateursMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministrateursMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AdresseEmail,MotDePasse")] Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Administrateurs.Add(administrateur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(administrateur);
        }

        // GET: AdministrateursMVC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = await db.Administrateurs.FindAsync(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // POST: AdministrateursMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AdresseEmail,MotDePasse")] Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrateur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(administrateur);
        }

        // GET: AdministrateursMVC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = await db.Administrateurs.FindAsync(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // POST: AdministrateursMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Administrateur administrateur = await db.Administrateurs.FindAsync(id);
            db.Administrateurs.Remove(administrateur);
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
