using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AppPfeBackEnd.Models;

namespace AppPfeBackEnd.Controllers
{
    public class PecheursController : ApiController
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: api/Pecheurs
        public IQueryable<Pecheur> GetPecheurs()
        {
            return db.Pecheurs;
        }

        // GET: api/Pecheurs/5
        [ResponseType(typeof(Pecheur))]
        public async Task<IHttpActionResult> GetPecheur(int id)
        {
            Pecheur pecheur = await db.Pecheurs.FindAsync(id);
            if (pecheur == null)
            {
                return NotFound();
            }

            return Ok(pecheur);
        }

        // PUT: api/Pecheurs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPecheur(int id, Pecheur pecheur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pecheur.Id)
            {
                return BadRequest();
            }

            db.Entry(pecheur).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PecheurExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pecheurs
        [ResponseType(typeof(Pecheur))]
        public async Task<IHttpActionResult> PostPecheur(Pecheur pecheur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pecheurs.Add(pecheur);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pecheur.Id }, pecheur);
        }

        // DELETE: api/Pecheurs/5
        [ResponseType(typeof(Pecheur))]
        public async Task<IHttpActionResult> DeletePecheur(int id)
        {
            Pecheur pecheur = await db.Pecheurs.FindAsync(id);
            if (pecheur == null)
            {
                return NotFound();
            }

            db.Pecheurs.Remove(pecheur);
            await db.SaveChangesAsync();

            return Ok(pecheur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PecheurExists(int id)
        {
            return db.Pecheurs.Count(e => e.Id == id) > 0;
        }
    }
}