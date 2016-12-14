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
    public class MensagemsController : ApiController
    {
        private ProximaFaseContext db = new ProximaFaseContext();

        // GET: api/Mensagems
        public IQueryable<Mensagem> GetMensagems()
        {
            return db.Mensagems;
        }

        // GET: api/Mensagems/5
        [ResponseType(typeof(Mensagem))]
        public IHttpActionResult GetMensagem(int id)
        {
            Mensagem mensagem = db.Mensagems.Find(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return Ok(mensagem);
        }

        // PUT: api/Mensagems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMensagem(int id, Mensagem mensagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensagem.MensagemID)
            {
                return BadRequest();
            }

            db.Entry(mensagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemExists(id))
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

        // POST: api/Mensagems
        [ResponseType(typeof(Mensagem))]
        public IHttpActionResult PostMensagem(Mensagem mensagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mensagems.Add(mensagem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mensagem.MensagemID }, mensagem);
        }

        // DELETE: api/Mensagems/5
        [ResponseType(typeof(Mensagem))]
        public IHttpActionResult DeleteMensagem(int id)
        {
            Mensagem mensagem = db.Mensagems.Find(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            db.Mensagems.Remove(mensagem);
            db.SaveChanges();

            return Ok(mensagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MensagemExists(int id)
        {
            return db.Mensagems.Count(e => e.MensagemID == id) > 0;
        }
    }
}