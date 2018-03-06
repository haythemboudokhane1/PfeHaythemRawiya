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
    public class PublicationPecheursController : ApiController
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: api/PublicationPecheurs
        public IQueryable<PublicationPecheur> GetPublicationPecheurs()
        {
            return db.PublicationPecheurs;
        }

        // GET: api/PublicationPecheurs/5
        [ResponseType(typeof(PublicationPecheur))]
        public async Task<IHttpActionResult> GetPublicationPecheur(int id)
        {
            PublicationPecheur publicationPecheur = await db.PublicationPecheurs.FindAsync(id);
            if (publicationPecheur == null)
            {
                return NotFound();
            }

            return Ok(publicationPecheur);
        }

        // PUT: api/PublicationPecheurs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPublicationPecheur(int id, PublicationPecheur publicationPecheur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publicationPecheur.Id)
            {
                return BadRequest();
            }

            db.Entry(publicationPecheur).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationPecheurExists(id))
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

        // POST: api/PublicationPecheurs
        [ResponseType(typeof(PublicationPecheur))]
        public async Task<IHttpActionResult> PostPublicationPecheur(PublicationPecheur publicationPecheur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PublicationPecheurs.Add(publicationPecheur);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = publicationPecheur.Id }, publicationPecheur);
        }

        // DELETE: api/PublicationPecheurs/5
        [ResponseType(typeof(PublicationPecheur))]
        public async Task<IHttpActionResult> DeletePublicationPecheur(int id)
        {
            PublicationPecheur publicationPecheur = await db.PublicationPecheurs.FindAsync(id);
            if (publicationPecheur == null)
            {
                return NotFound();
            }

            db.PublicationPecheurs.Remove(publicationPecheur);
            await db.SaveChangesAsync();

            return Ok(publicationPecheur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PublicationPecheurExists(int id)
        {
            return db.PublicationPecheurs.Count(e => e.Id == id) > 0;
        }
    }
}