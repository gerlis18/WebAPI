using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Description;
using WebAPI.Models;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SugerencesController : ApiController
    {

        private SugerencesContext db = new SugerencesContext();

        // GET: api/Sugerences
        public IQueryable<Sugerence> GetSugerence()
        {
            return db.Sugerence;
        }

        // GET: api/Sugerences/5
        [ResponseType(typeof(Sugerence))]
        public IHttpActionResult GetSugerence(int? id, string titulo)
        {
            var sugerence = new object();
            if (id != null)
            {
                 sugerence = db.Sugerence.Find(id);
            }
            else if (!string.IsNullOrEmpty(titulo))
            {
                sugerence = from sugs in db.Sugerence
                            where sugs.titulo.Equals(titulo)
                            select sugs;
            }
            
            if (sugerence == null)
            {
                return NotFound();
            }

            return Ok(sugerence);
        }

        // PUT: api/Sugerences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSugerence(int id, Sugerence sugerence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sugerence.SugerenceId)
            {
                return BadRequest();
            }

            db.Entry(sugerence).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SugerenceExists(id))
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

        // POST: api/Sugerences
        [ResponseType(typeof(Sugerence))]
        public IHttpActionResult PostSugerence(Sugerence sugerence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sugerence.Add(sugerence);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sugerence.SugerenceId }, sugerence);
        }

        // DELETE: api/Sugerences/5
        [ResponseType(typeof(Sugerence))]
        public IHttpActionResult DeleteSugerence(int id)
        {
            Sugerence sugerence = db.Sugerence.Find(id);
            if (sugerence == null)
            {
                return NotFound();
            }

            db.Sugerence.Remove(sugerence);
            db.SaveChanges();

            return Ok(sugerence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SugerenceExists(int id)
        {
            return db.Sugerence.Count(e => e.SugerenceId == id) > 0;
        }
    }
}