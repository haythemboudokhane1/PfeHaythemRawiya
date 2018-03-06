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
    public class PecheursMVCController : Controller
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: PecheursMVC
        public async Task<ActionResult> Index()
        {
            return View(await db.Pecheurs.ToListAsync());
        }

        // GET: PecheursMVC/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecheur pecheur = await db.Pecheurs.FindAsync(id);
            if (pecheur == null)
            {
                return HttpNotFound();
            }
            return View(pecheur);
        }

        // GET: PecheursMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PecheursMVC/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,nom,prenom,adressEmail,motDePasse,confirmerMotDePasse,adressMagasin,Experience,NumeroTelephone,photo")] Pecheur pecheur)
        {
            if (ModelState.IsValid)
            {
                db.Pecheurs.Add(pecheur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pecheur);
        }

        // GET: PecheursMVC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecheur pecheur = await db.Pecheurs.FindAsync(id);
            if (pecheur == null)
            {
                return HttpNotFound();
            }
            return View(pecheur);
        }

        // POST: PecheursMVC/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,nom,prenom,adressEmail,motDePasse,confirmerMotDePasse,adressMagasin,Experience,NumeroTelephone,photo")] Pecheur pecheur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pecheur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pecheur);
        }

        // GET: PecheursMVC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecheur pecheur = await db.Pecheurs.FindAsync(id);
            if (pecheur == null)
            {
                return HttpNotFound();
            }
            return View(pecheur);
        }

        // POST: PecheursMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pecheur pecheur = await db.Pecheurs.FindAsync(id);
            db.Pecheurs.Remove(pecheur);
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
