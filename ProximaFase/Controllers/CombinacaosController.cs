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

namespace ProximaFase.Controllers
{
    public class CombinacaosController : ApiController
    {
        private ProximaFaseContext db = new ProximaFaseContext();

        // GET: api/Combinacaos
        public IQueryable<Combinacao> GetCombinacaos()
        {
            return db.Combinacaos;
        }

        // GET: api/Combinacaos/5
        [ResponseType(typeof(Combinacao))]
        public IHttpActionResult GetCombinacao(int id)
        {
            Combinacao combinacao = db.Combinacaos.Find(id);
            if (combinacao == null)
            {
                return NotFound();
            }

            return Ok(combinacao);
        }

        // PUT: api/Combinacaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCombinacao(int id, Combinacao combinacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != combinacao.CombinacaoID)
            {
                return BadRequest();
            }

            db.Entry(combinacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CombinacaoExists(id))
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

        // POST: api/Combinacaos
        [ResponseType(typeof(Combinacao))]
        public IHttpActionResult PostCombinacao(Combinacao combinacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Combinacaos.Add(combinacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = combinacao.CombinacaoID }, combinacao);
        }

        // DELETE: api/Combinacaos/5
        [ResponseType(typeof(Combinacao))]
        public IHttpActionResult DeleteCombinacao(int id)
        {
            Combinacao combinacao = db.Combinacaos.Find(id);
            if (combinacao == null)
            {
                return NotFound();
            }

            db.Combinacaos.Remove(combinacao);
            db.SaveChanges();

            return Ok(combinacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CombinacaoExists(int id)
        {
            return db.Combinacaos.Count(e => e.CombinacaoID == id) > 0;
        }
    }
}