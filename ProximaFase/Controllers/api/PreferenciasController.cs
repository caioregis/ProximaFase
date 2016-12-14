using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProximaFase.Models;

namespace ProximaFase.Controllers.api
{
    public class PreferenciasController : ApiController
    {
        private ProximaFaseContext db = new ProximaFaseContext();

        // GET: api/Preferencias
        public IQueryable<Preferencias> GetPreferencias()
        {
            return db.Preferencias;
        }

        // GET: api/Preferencias/5
        [ResponseType(typeof(Preferencias))]
        public IHttpActionResult GetPreferencias(int id)
        {
            Preferencias preferencias = db.Preferencias.Find(id);
            if (preferencias == null)
            {
                return NotFound();
            }

            return Ok(preferencias);
        }

        // PUT: api/Preferencias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPreferencias(int id, Preferencias preferencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preferencias.id)
            {
                return BadRequest();
            }

            db.Entry(preferencias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenciasExists(id))
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

        // POST: api/Preferencias
        [ResponseType(typeof(Preferencias))]
        public IHttpActionResult PostPreferencias(Preferencias preferencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preferencias.Add(preferencias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = preferencias.id }, preferencias);
        }

        // DELETE: api/Preferencias/5
        [ResponseType(typeof(Preferencias))]
        public IHttpActionResult DeletePreferencias(int id)
        {
            Preferencias preferencias = db.Preferencias.Find(id);
            if (preferencias == null)
            {
                return NotFound();
            }

            db.Preferencias.Remove(preferencias);
            db.SaveChanges();

            return Ok(preferencias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreferenciasExists(int id)
        {
            return db.Preferencias.Count(e => e.id == id) > 0;
        }
    }
}