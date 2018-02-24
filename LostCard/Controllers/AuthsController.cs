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
using LostCard.Models;

namespace LostCard.Controllers
{
    public class AuthsController : ApiController
    {
        private LostCardsEntities1 db = new LostCardsEntities1();

        // GET: api/Auths
        public IQueryable<UserTable> GetUserTables()
        {
            return db.UserTables;
        }

        // GET: api/Auths/5
        [ResponseType(typeof(UserTable))]
        public IHttpActionResult GetUserTable(string id)
        {
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return NotFound();
            }

            return Ok(userTable);
        }

        // PUT: api/Auths/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserTable(int id, UserTable userTables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userTables.ID)
            {
                return BadRequest();
            }

            db.Entry(userTables).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(id))
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

        private bool UserTableExists(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Auths
        [ResponseType(typeof(UserTable))]
        public IHttpActionResult PostUserTable(UserTable userTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserTables.Add(userTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserTableExists(userTable.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userTable.ID }, userTable);
        }

        // DELETE: api/Auths/5
        [ResponseType(typeof(UserTable))]
        public IHttpActionResult DeleteUserTable(int id)
        {
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return NotFound();
            }

            db.UserTables.Remove(userTable);
            db.SaveChanges();

            return Ok(userTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserTableExists(int id,int s)
        {
            return db.UserTables.Count(e => e.ID == id) > 0;
        }
    }
}