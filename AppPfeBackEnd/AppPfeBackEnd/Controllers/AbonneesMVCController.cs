﻿using System;
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
    public class AbonneesMVCController : Controller
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: AbonneesMVC
        public async Task<ActionResult> Index()
        {
            return View(await db.Abonnees.ToListAsync());
        }

        // GET: AbonneesMVC/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonnee abonnee = await db.Abonnees.FindAsync(id);
            if (abonnee == null)
            {
                return HttpNotFound();
            }
            return View(abonnee);
        }

        // GET: AbonneesMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbonneesMVC/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,nom,prenom,adressEmail,motDePasse,confirmerMotDePasse,photo")] Abonnee abonnee)
        {
            if (ModelState.IsValid)
            {
                db.Abonnees.Add(abonnee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(abonnee);
        }

        // GET: AbonneesMVC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonnee abonnee = await db.Abonnees.FindAsync(id);
            if (abonnee == null)
            {
                return HttpNotFound();
            }
            return View(abonnee);
        }

        // POST: AbonneesMVC/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,nom,prenom,adressEmail,motDePasse,confirmerMotDePasse,photo")] Abonnee abonnee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonnee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(abonnee);
        }

        // GET: AbonneesMVC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonnee abonnee = await db.Abonnees.FindAsync(id);
            if (abonnee == null)
            {
                return HttpNotFound();
            }
            return View(abonnee);
        }

        // POST: AbonneesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Abonnee abonnee = await db.Abonnees.FindAsync(id);
            db.Abonnees.Remove(abonnee);
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
