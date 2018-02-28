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
    public class AdministrateursController : ApiController
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: api/Administrateurs
        public IQueryable<Administrateur> GetAdministrateurs()
        {
            return db.Administrateurs;
        }

        // GET: api/Administrateurs/5
        [ResponseType(typeof(Administrateur))]
        public async Task<IHttpActionResult> GetAdministrateur(int id)
        {
            Administrateur administrateur = await db.Administrateurs.FindAsync(id);
            if (administrateur == null)
            {
                return NotFound();
            }

            return Ok(administrateur);
        }

        // PUT: api/Administrateurs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdministrateur(int id, Administrateur administrateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrateur.Id)
            {
                return BadRequest();
            }

            db.Entry(administrateur).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrateurExists(id))
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

        // POST: api/Administrateurs
        [ResponseType(typeof(Administrateur))]
        public async Task<IHttpActionResult> PostAdministrateur(Administrateur administrateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administrateurs.Add(administrateur);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = administrateur.Id }, administrateur);
        }

        // DELETE: api/Administrateurs/5
        [ResponseType(typeof(Administrateur))]
        public async Task<IHttpActionResult> DeleteAdministrateur(int id)
        {
            Administrateur administrateur = await db.Administrateurs.FindAsync(id);
            if (administrateur == null)
            {
                return NotFound();
            }

            db.Administrateurs.Remove(administrateur);
            await db.SaveChangesAsync();

            return Ok(administrateur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministrateurExists(int id)
        {
            return db.Administrateurs.Count(e => e.Id == id) > 0;
        }
    }
}