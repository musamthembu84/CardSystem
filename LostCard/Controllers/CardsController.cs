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
    //[RoutePrefix("api/Cards")]
    public class CardsController : ApiController
    {
        private LostCardsEntities1 db = new LostCardsEntities1();

        // GET: api/Cards
        public IQueryable<Card> GetCards()
        {
            return db.Cards;
        }



        [Route("api/cards/{anyString}")]
        [HttpGet, HttpPost]
        public int GetDeliveryItemsOne(string anyString)
        {
            int count = db.Cards.Count(f => f.Campus == anyString.ToLower());
            return count;
        }


        [Route("{name}")]
        [HttpGet]
        public string GetByName(string campus)
        {
            
            //int count = db.Cards.Count(f => f.Campus == campus.ToLower());
            return "test2";
        }

       

        // GET: api/Cards/5
        [ResponseType(typeof(Card))]
        public IHttpActionResult GetCard(int id)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }

            return Ok(card.ID);
        }

        



        // PUT: api/Cards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCard(int id, Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != card.ID)
            {
                return BadRequest();
            }

            db.Entry(card).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        [ResponseType(typeof(Card))]
        public IHttpActionResult PostCard(Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            
            card.DateTime = DateTime.Now;
               
            db.Cards.Add(card);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = card.ID }, card);
        }

        // DELETE: api/Cards/5
        [ResponseType(typeof(Card))]
        public IHttpActionResult DeleteCard(int id)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }

            db.Cards.Remove(card);
            db.SaveChanges();

            return Ok(card);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardExists(int id)
        {
            return db.Cards.Count(e => e.ID == id) > 0;
        }
    }
}