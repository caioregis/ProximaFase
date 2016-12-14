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
    public class ConsoleGamesController : ApiController
    {
        private ProximaFaseContext db = new ProximaFaseContext();

        // GET: api/ConsoleGames
        public IQueryable<ConsoleGame> GetConsoleGames()
        {
            return db.ConsoleGames;
        }

        // GET: api/ConsoleGames/5
        [ResponseType(typeof(ConsoleGame))]
        public IHttpActionResult GetConsoleGame(int id)
        {
            ConsoleGame consoleGame = db.ConsoleGames.Find(id);
            if (consoleGame == null)
            {
                return NotFound();
            }

            return Ok(consoleGame);
        }

        // PUT: api/ConsoleGames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsoleGame(int id, ConsoleGame consoleGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consoleGame.ConsoleGameID)
            {
                return BadRequest();
            }

            db.Entry(consoleGame).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsoleGameExists(id))
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

        // POST: api/ConsoleGames
        [ResponseType(typeof(ConsoleGame))]
        public IHttpActionResult PostConsoleGame(ConsoleGame consoleGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConsoleGames.Add(consoleGame);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consoleGame.ConsoleGameID }, consoleGame);
        }

        // DELETE: api/ConsoleGames/5
        [ResponseType(typeof(ConsoleGame))]
        public IHttpActionResult DeleteConsoleGame(int id)
        {
            ConsoleGame consoleGame = db.ConsoleGames.Find(id);
            if (consoleGame == null)
            {
                return NotFound();
            }

            db.ConsoleGames.Remove(consoleGame);
            db.SaveChanges();

            return Ok(consoleGame);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsoleGameExists(int id)
        {
            return db.ConsoleGames.Count(e => e.ConsoleGameID == id) > 0;
        }
    }
}