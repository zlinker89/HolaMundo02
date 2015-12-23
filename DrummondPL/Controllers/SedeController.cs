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
using HolaMundo;
using Entities.DTOs;

namespace DrummondPL.Controllers
{
    public class SedeController : ApiController
    {
        private Drummond01Entities db = new Drummond01Entities();

        // GET api/Sede
        public IQueryable<SedeDTO> GetSedeSet()
        {
            var sedes = from s in db.SedeSet
                        select new SedeDTO()
                        {
                            Cod = s.Cod,
                            nombre = s.nombre
                        };
            return sedes;
        }

        // GET api/Sede/5
        [ResponseType(typeof(SedeSet))]
        public async Task<IHttpActionResult> GetSedeSet(int id)
        {
            SedeSet sedeset = await db.SedeSet.FindAsync(id);
            if (sedeset == null)
            {
                return NotFound();
            }

            return Ok(sedeset);
        }

        // PUT api/Sede/5
        public async Task<IHttpActionResult> PutSedeSet(int id, SedeSet sedeset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sedeset.Cod)
            {
                return BadRequest();
            }

            db.Entry(sedeset).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeSetExists(id))
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

        // POST api/Sede
        [ResponseType(typeof(SedeSet))]
        public async Task<IHttpActionResult> PostSedeSet(SedeSet sedeset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SedeSet.Add(sedeset);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sedeset.Cod }, sedeset);
        }

        // DELETE api/Sede/5
        [ResponseType(typeof(SedeSet))]
        public async Task<IHttpActionResult> DeleteSedeSet(int id)
        {
            SedeSet sedeset = await db.SedeSet.FindAsync(id);
            if (sedeset == null)
            {
                return NotFound();
            }

            db.SedeSet.Remove(sedeset);
            await db.SaveChangesAsync();

            return Ok(sedeset);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SedeSetExists(int id)
        {
            return db.SedeSet.Count(e => e.Cod == id) > 0;
        }
    }
}