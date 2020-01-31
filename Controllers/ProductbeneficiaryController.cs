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
    public class ProductbeneficiaryController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Productbeneficiary
        public IEnumerable<productbeneficiary> Getproductbeneficiaries()
        {
            var productbeneficiaries = db.productbeneficiaries.Include(p => p.beneficiary).Include(p => p.product);
            return productbeneficiaries.AsEnumerable();
        }

        // GET api/Productbeneficiary/5
        public productbeneficiary Getproductbeneficiary(short id)
        {
            productbeneficiary productbeneficiary = db.productbeneficiaries.Find(id);
            if (productbeneficiary == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return productbeneficiary;
        }

        // PUT api/Productbeneficiary/5
        public HttpResponseMessage Putproductbeneficiary(short id, productbeneficiary productbeneficiary)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != productbeneficiary.productbeneficiaryid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(productbeneficiary).State = EntityState.Modified;

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

        // POST api/Productbeneficiary
        public HttpResponseMessage Postproductbeneficiary(productbeneficiary productbeneficiary)
        {
            if (ModelState.IsValid)
            {
                db.productbeneficiaries.Add(productbeneficiary);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productbeneficiary);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = productbeneficiary.productbeneficiaryid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Productbeneficiary/5
        public HttpResponseMessage Deleteproductbeneficiary(short id)
        {
            productbeneficiary productbeneficiary = db.productbeneficiaries.Find(id);
            if (productbeneficiary == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.productbeneficiaries.Remove(productbeneficiary);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, productbeneficiary);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}