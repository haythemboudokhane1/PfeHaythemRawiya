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
    public class AbonneesController : ApiController
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: api/Abonnees
        public IQueryable<Abonnee> GetAbonnees()
        {
            return db.Abonnees;
        }

        // GET: api/Abonnees/5
        [ResponseType(typeof(Abonnee))]
        public async Task<IHttpActionResult> GetAbonnee(int id)
        {
            Abonnee abonnee = await db.Abonnees.FindAsync(id);
            if (abonnee == null)
            {
                return NotFound();
            }

            return Ok(abonnee);
        }

        // PUT: api/Abonnees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAbonnee(int id, Abonnee abonnee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abonnee.Id)
            {
                return BadRequest();
            }

            db.Entry(abonnee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonneeExists(id))
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

        // POST: api/Abonnees
        [ResponseType(typeof(Abonnee))]
        public async Task<IHttpActionResult> PostAbonnee(Abonnee abonnee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Abonnees.Add(abonnee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = abonnee.Id }, abonnee);
        }

        // DELETE: api/Abonnees/5
        [ResponseType(typeof(Abonnee))]
        public async Task<IHttpActionResult> DeleteAbonnee(int id)
        {
            Abonnee abonnee = await db.Abonnees.FindAsync(id);
            if (abonnee == null)
            {
                return NotFound();
            }

            db.Abonnees.Remove(abonnee);
            await db.SaveChangesAsync();

            return Ok(abonnee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbonneeExists(int id)
        {
            return db.Abonnees.Count(e => e.Id == id) > 0;
        }
    }
}