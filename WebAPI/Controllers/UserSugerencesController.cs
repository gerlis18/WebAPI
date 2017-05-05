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
    public class UserSugerencesController : ApiController
    {
        private SugerencesContext db = new SugerencesContext();

        // GET: api/UserSugerences
        public IQueryable<UserSugerence> GetUserSugerence()
        {
            return db.UserSugerence;
        }

        // GET: api/UserSugerences?id=5&userRid=5
        [ResponseType(typeof(UserSugerence))]
        public IHttpActionResult GetUserSugerence(int? id, int? userRid)
        {
            var queryJoin = new object();
            if (userRid != null)
            {
                queryJoin = from u in db.User
                            from sgid in db.UserSugerence
                            from sug in db.Sugerence
                            where u.UserId == userRid && sgid.UserRId == u.UserId
                            && sug.SugerenceId == sgid.UserSugerenceId
                            select new { sug.titulo, sug.mensaje, sug.creacion, sgid.UserEId, u.username };
            }
            else if(id != null)
            {
                queryJoin = from u in db.User
                            from userSug in db.UserSugerence
                            from sug in db.Sugerence
                            where u.UserId == id && u.UserId == userSug.UserEId
                            && userSug.UserSugerenceId == sug.SugerenceId
                            select new
                            {
                                userId = u.UserId,
                                username = u.username,
                                userRId = userSug.UserRId,
                                SugerenciaId = sug.SugerenceId,
                                titulo = sug.titulo,
                                mensaje = sug.mensaje,
                                creacion = sug.creacion
                               
                            };
            }

            if (queryJoin == null)
            {
                return NotFound();
            }


            return Ok(queryJoin);
        }
          


            

        /*// GET: api/UserSugerencesById/5
        [ResponseType(typeof(UserSugerence))]
        public IHttpActionResult GetUserSugerence(int userRid, int sugId)
        {

            var queryJoin = from u in db.User
                            from sgid in db.UserSugerence
                            from sug in db.Sugerence
                            where u.UserId == userRid && sgid.UserRId == u.UserId && sgid.UserSugerenceId == sugId
                            && sug.SugerenceId == sgid.UserSugerenceId
                            select new { sug.mensaje };


            if (queryJoin == null)
            {
                return NotFound();
            }


            return Ok(queryJoin);
        }*/

        // PUT: api/UserSugerences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserSugerence(int id, UserSugerence userSugerence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userSugerence.UserSugerenceId)
            {
                return BadRequest();
            }

            db.Entry(userSugerence).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSugerenceExists(id))
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

        // POST: api/UserSugerences
        [ResponseType(typeof(UserSugerence))]
        public IHttpActionResult PostUserSugerence(UserSugerence userSugerence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserSugerence.Add(userSugerence);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserSugerenceExists(userSugerence.UserSugerenceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userSugerence.UserSugerenceId }, userSugerence);
        }

        // DELETE: api/UserSugerences/5
        [ResponseType(typeof(UserSugerence))]
        public IHttpActionResult DeleteUserSugerence(int id)
        {
            UserSugerence userSugerence = db.UserSugerence.Find(id);
            if (userSugerence == null)
            {
                return NotFound();
            }

            db.UserSugerence.Remove(userSugerence);
            db.SaveChanges();

            return Ok(userSugerence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserSugerenceExists(int id)
        {
            return db.UserSugerence.Count(e => e.UserSugerenceId == id) > 0;
        }
    }
}