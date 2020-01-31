using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using bookwrm_03.Models;

namespace bookwrm_03.Controllers
{
    public class AuthorController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Author
        public IEnumerable<author> Getauthors()
        {
            return db.authors.AsEnumerable();
        }

        // GET api/Author/5
        public author Getauthor(short id)
        {
            author author = db.authors.Find(id);
            if (author == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return author;
        }

        // PUT api/Author/5
        public HttpResponseMessage Putauthor(short id, author author)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != author.authorid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Author
        public HttpResponseMessage Postauthor(author author)
        {
            if (ModelState.IsValid)
            {
                db.authors.Add(author);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, author);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = author.authorid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Author/5
        public HttpResponseMessage Deleteauthor(short id)
        {
            author author = db.authors.Find(id);
            if (author == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.authors.Remove(author);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, author);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}