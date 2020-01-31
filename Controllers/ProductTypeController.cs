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
    public class ProductTypeController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/ProductType
        public IEnumerable<producttype> Getproducttypes()
        {
            return db.producttypes.AsEnumerable();
        }

        // GET api/ProductType/5
        public producttype Getproducttype(short id)
        {
            producttype producttype = db.producttypes.Find(id);
            if (producttype == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return producttype;
        }

        // PUT api/ProductType/5
        public HttpResponseMessage Putproducttype(short id, producttype producttype)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != producttype.producttypeid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(producttype).State = EntityState.Modified;

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

        // POST api/ProductType
        public HttpResponseMessage Postproducttype(producttype producttype)
        {
            if (ModelState.IsValid)
            {
                db.producttypes.Add(producttype);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, producttype);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = producttype.producttypeid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ProductType/5
        public HttpResponseMessage Deleteproducttype(short id)
        {
            producttype producttype = db.producttypes.Find(id);
            if (producttype == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.producttypes.Remove(producttype);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, producttype);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}