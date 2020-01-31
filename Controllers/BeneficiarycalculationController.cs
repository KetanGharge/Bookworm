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
    public class BeneficiarycalculationController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Beneficiarycalculation
        public IEnumerable<beneficiarycalculation> Getbeneficiarycalculations()
        {
            var beneficiarycalculations = db.beneficiarycalculations.Include(b => b.invoicedetail).Include(b => b.productbeneficiary);
            return beneficiarycalculations.AsEnumerable();
        }

        // GET api/Beneficiarycalculation/5
        public beneficiarycalculation Getbeneficiarycalculation(short id)
        {
            beneficiarycalculation beneficiarycalculation = db.beneficiarycalculations.Find(id);
            if (beneficiarycalculation == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return beneficiarycalculation;
        }

        // PUT api/Beneficiarycalculation/5
        public HttpResponseMessage Putbeneficiarycalculation(short id, beneficiarycalculation beneficiarycalculation)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != beneficiarycalculation.beneficiarycalid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(beneficiarycalculation).State = EntityState.Modified;

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

        // POST api/Beneficiarycalculation
        public void Postbeneficiarycalculation(beneficiarycalculation beneficiarycalculation)
        {
            if (ModelState.IsValid)
            {

                
                db.beneficiarycalculations.Add(beneficiarycalculation);
                db.SaveChanges();

               // HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, beneficiarycalculation);
             //   response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = beneficiarycalculation.beneficiarycalid }));
                //return response;
            }
            else
            {
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Beneficiarycalculation/5
        public HttpResponseMessage Deletebeneficiarycalculation(short id)
        {
            beneficiarycalculation beneficiarycalculation = db.beneficiarycalculations.Find(id);
            if (beneficiarycalculation == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.beneficiarycalculations.Remove(beneficiarycalculation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, beneficiarycalculation);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}