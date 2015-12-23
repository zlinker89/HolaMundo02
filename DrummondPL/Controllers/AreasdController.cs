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

namespace DrummondPL.Controllers
{
    public class AreasdController : ApiController
    {
        private Drummond01Entities db = new Drummond01Entities();

        // GET api/Areasd
        public IQueryable<AreasD> GetAreasD()
        {
            return db.AreasD;
        }

        // GET api/Areasd/5
        [ResponseType(typeof(AreasD))]
        public async Task<IHttpActionResult> GetAreasD(int id)
        {
            AreasD areasd = await db.AreasD.FindAsync(id);
            if (areasd == null)
            {
                return NotFound();
            }

            return Ok(areasd);
        }

        // PUT api/Areasd/5
        public async Task<IHttpActionResult> PutAreasD(int id, AreasD areasd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != areasd.Cod)
            {
                return BadRequest();
            }

            db.Entry(areasd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreasDExists(id))
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

        // POST api/Areasd
        [ResponseType(typeof(AreasD))]
        public async Task<IHttpActionResult> PostAreasD(AreasD areasd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AreasD.Add(areasd);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = areasd.Cod }, areasd);
        }

        // DELETE api/Areasd/5
        [ResponseType(typeof(AreasD))]
        public async Task<IHttpActionResult> DeleteAreasD(int id)
        {
            AreasD areasd = await db.AreasD.FindAsync(id);
            if (areasd == null)
            {
                return NotFound();
            }

            db.AreasD.Remove(areasd);
            await db.SaveChangesAsync();

            return Ok(areasd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AreasDExists(int id)
        {
            return db.AreasD.Count(e => e.Cod == id) > 0;
        }
    }
}