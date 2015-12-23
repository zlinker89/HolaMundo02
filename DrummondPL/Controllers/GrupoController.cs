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
    public class GrupoController : ApiController
    {
        private Drummond01Entities db = new Drummond01Entities();

        // GET api/Grupo
        public IQueryable<GrupoDTO> GetGrupoSet()
        {
            var grupos = from g in db.GrupoSet
                         select new GrupoDTO()
                         {
                             Id = g.Id,
                             nombre = g.nombre
                         };
            return grupos;
        }

        // GET api/Grupo/5
        [ResponseType(typeof(GrupoSet))]
        public async Task<IHttpActionResult> GetGrupoSet(int id)
        {
            GrupoSet gruposet = await db.GrupoSet.FindAsync(id);
            if (gruposet == null)
            {
                return NotFound();
            }

            return Ok(gruposet);
        }

        // PUT api/Grupo/5
        public async Task<IHttpActionResult> PutGrupoSet(int id, GrupoSet gruposet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gruposet.Id)
            {
                return BadRequest();
            }

            db.Entry(gruposet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoSetExists(id))
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

        // POST api/Grupo
        [ResponseType(typeof(GrupoSet))]
        public async Task<IHttpActionResult> PostGrupoSet(GrupoSet gruposet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GrupoSet.Add(gruposet);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gruposet.Id }, gruposet);
        }

        // DELETE api/Grupo/5
        [ResponseType(typeof(GrupoSet))]
        public async Task<IHttpActionResult> DeleteGrupoSet(int id)
        {
            GrupoSet gruposet = await db.GrupoSet.FindAsync(id);
            if (gruposet == null)
            {
                return NotFound();
            }

            db.GrupoSet.Remove(gruposet);
            await db.SaveChangesAsync();

            return Ok(gruposet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GrupoSetExists(int id)
        {
            return db.GrupoSet.Count(e => e.Id == id) > 0;
        }
    }
}