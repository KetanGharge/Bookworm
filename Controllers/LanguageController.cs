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
    public class LanguageController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Language
        public IEnumerable<language> Getlanguages()
        {
            return db.languages.AsEnumerable();
        }

        // GET api/Language/5
        public language Getlanguage(short id)
        {
            language language = db.languages.Find(id);
            if (language == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return language;
        }

        // PUT api/Language/5
        public HttpResponseMessage Putlanguage(short id, language language)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != language.languageid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(language).State = EntityState.Modified;

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

        // POST api/Language
        public HttpResponseMessage Postlanguage(language language)
        {
            if (ModelState.IsValid)
            {
                db.languages.Add(language);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, language);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = language.languageid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Language/5
        public HttpResponseMessage Deletelanguage(short id)
        {
            language language = db.languages.Find(id);
            if (language == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.languages.Remove(language);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, language);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}