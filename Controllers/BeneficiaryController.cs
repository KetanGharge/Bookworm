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
    public class BeneficiaryController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Beneficiary
        public IEnumerable<beneficiary> Getbeneficiaries()
        {
            return db.beneficiaries.AsEnumerable();
        }

        // GET api/Beneficiary/5
        public beneficiary Getbeneficiary(short id)
        {
            beneficiary beneficiary = db.beneficiaries.Find(id);
            if (beneficiary == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return beneficiary;
        }

        // PUT api/Beneficiary/5
        public HttpResponseMessage Putbeneficiary(short id, beneficiary beneficiary)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != beneficiary.beneficiaryid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(beneficiary).State = EntityState.Modified;

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

        // POST api/Beneficiary
        public HttpResponseMessage Postbeneficiary(beneficiary beneficiary)
        {
            if (ModelState.IsValid)
            {
                db.beneficiaries.Add(beneficiary);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, beneficiary);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = beneficiary.beneficiaryid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Beneficiary/5
        public HttpResponseMessage Deletebeneficiary(short id)
        {
            beneficiary beneficiary = db.beneficiaries.Find(id);
            if (beneficiary == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.beneficiaries.Remove(beneficiary);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, beneficiary);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}