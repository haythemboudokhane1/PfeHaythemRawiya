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
    public class CommercantsController : ApiController
    {
        private AdministrateursContext db = new AdministrateursContext();

        // GET: api/Commercants
        public IQueryable<Commercant> GetCommercants()
        {
            return db.Commercants;
        }

        // GET: api/Commercants/5
        [ResponseType(typeof(Commercant))]
        public async Task<IHttpActionResult> GetCommercant(int id)
        {
            Commercant commercant = await db.Commercants.FindAsync(id);
            if (commercant == null)
            {
                return NotFound();
            }

            return Ok(commercant);
        }

        // PUT: api/Commercants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCommercant(int id, Commercant commercant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commercant.Id)
            {
                return BadRequest();
            }

            db.Entry(commercant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercantExists(id))
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

        // POST: api/Commercants
        [ResponseType(typeof(Commercant))]
        public async Task<IHttpActionResult> PostCommercant(Commercant commercant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Commercants.Add(commercant);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = commercant.Id }, commercant);
        }

        // DELETE: api/Commercants/5
        [ResponseType(typeof(Commercant))]
        public async Task<IHttpActionResult> DeleteCommercant(int id)
        {
            Commercant commercant = await db.Commercants.FindAsync(id);
            if (commercant == null)
            {
                return NotFound();
            }

            db.Commercants.Remove(commercant);
            await db.SaveChangesAsync();

            return Ok(commercant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommercantExists(int id)
        {
            return db.Commercants.Count(e => e.Id == id) > 0;
        }
    }
}