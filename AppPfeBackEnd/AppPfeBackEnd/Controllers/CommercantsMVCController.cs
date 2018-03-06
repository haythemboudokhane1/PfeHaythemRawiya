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
    public class CommercantsMVCController : Controller
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: CommercantsMVC
        public async Task<ActionResult> Index()
        {
            return View(await db.Commercants.ToListAsync());
        }

        // GET: CommercantsMVC/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commercant commercant = await db.Commercants.FindAsync(id);
            if (commercant == null)
            {
                return HttpNotFound();
            }
            return View(commercant);
        }

        // GET: CommercantsMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommercantsMVC/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,nom,prenom,adressEmail,motDePasse,ConfirmerMotDePasse,adressMagasin,NumeroTelephone,photo")] Commercant commercant)
        {
            if (ModelState.IsValid)
            {
                db.Commercants.Add(commercant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(commercant);
        }

        // GET: CommercantsMVC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commercant commercant = await db.Commercants.FindAsync(id);
            if (commercant == null)
            {
                return HttpNotFound();
            }
            return View(commercant);
        }

        // POST: CommercantsMVC/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,nom,prenom,adressEmail,motDePasse,ConfirmerMotDePasse,adressMagasin,NumeroTelephone,photo")] Commercant commercant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commercant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(commercant);
        }

        // GET: CommercantsMVC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commercant commercant = await db.Commercants.FindAsync(id);
            if (commercant == null)
            {
                return HttpNotFound();
            }
            return View(commercant);
        }

        // POST: CommercantsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Commercant commercant = await db.Commercants.FindAsync(id);
            db.Commercants.Remove(commercant);
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
