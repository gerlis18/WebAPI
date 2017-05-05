using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SugerencesPostsController : ApiController
    {
        private SugerencesContext db = new SugerencesContext();

        // GET: api/SugerencesPosts
        public IQueryable<SugerencesPost> GetSugerencesPost()
        {
            return db.SugerencesPost;
        }

        // GET: api/SugerencesPosts/5
        [ResponseType(typeof(SugerencesPost))]
        public IHttpActionResult GetSugerencesPost(string categoria)
        {
            var sugerencesPost = new object();
            sugerencesPost = from cats in db.Categoria
                             from sugs in db.Sugerence
                             from uss in db.User
                             from sugsPost in db.SugerencesPost
                             where cats.categoria == categoria && sugsPost.CategoriaId == cats.id
                                    && sugsPost.SugerenceId == sugs.SugerenceId
                                    && sugsPost.UserId == uss.UserId
                             select new { cats.categoria, sugs.titulo, sugs.mensaje, sugs.creacion, uss.username, uss.Rol };

            if (sugerencesPost == null)
            {
                return NotFound();
            }

            return Ok(sugerencesPost);
        }

        // PUT: api/SugerencesPosts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSugerencesPost(int id, SugerencesPost sugerencesPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sugerencesPost.id)
            {
                return BadRequest();
            }

            db.Entry(sugerencesPost).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SugerencesPostExists(id))
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

        // POST: api/SugerencesPosts
        [ResponseType(typeof(SugerencesPost))]
        public IHttpActionResult PostSugerencesPost(SugerencesPost sugerencesPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SugerencesPost.Add(sugerencesPost);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SugerencesPostExists(sugerencesPost.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sugerencesPost.id }, sugerencesPost);
        }

        // DELETE: api/SugerencesPosts/5
        [ResponseType(typeof(SugerencesPost))]
        public IHttpActionResult DeleteSugerencesPost(int id)
        {
            SugerencesPost sugerencesPost = db.SugerencesPost.Find(id);
            if (sugerencesPost == null)
            {
                return NotFound();
            }

            db.SugerencesPost.Remove(sugerencesPost);
            db.SaveChanges();

            return Ok(sugerencesPost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SugerencesPostExists(int id)
        {
            return db.SugerencesPost.Count(e => e.id == id) > 0;
        }
    }
}