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
    public class PackageDetailsController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/PackageDetails
        public IEnumerable<packagedetail> Getpackagedetails()
        {
            var packagedetails = db.packagedetails.Include(p => p.product);
            return packagedetails.AsEnumerable();
        }

        // GET api/PackageDetails/5
        public packagedetail Getpackagedetail(short id)
        {
            packagedetail packagedetail = db.packagedetails.Find(id);
            if (packagedetail == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return packagedetail;
        }

        // PUT api/PackageDetails/5
        public HttpResponseMessage Putpackagedetail(short id, packagedetail packagedetail)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != packagedetail.packagedetailsid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(packagedetail).State = EntityState.Modified;

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

        // POST api/PackageDetails
        public HttpResponseMessage Postpackagedetail(packagedetail packagedetail)
        {
            if (ModelState.IsValid)
            {
                db.packagedetails.Add(packagedetail);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, packagedetail);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = packagedetail.packagedetailsid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/PackageDetails/5
        public HttpResponseMessage Deletepackagedetail(short id)
        {
            packagedetail packagedetail = db.packagedetails.Find(id);
            if (packagedetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.packagedetails.Remove(packagedetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, packagedetail);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}