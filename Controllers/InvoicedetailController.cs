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
    public class InvoicedetailController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Invoicedetail
        public IList<invoicedetail> Getinvoicedetails()
        {
            var x = (from m in db.invoicedetails
                     select new
                     {
                         invoicedetailsid = m.invoicedetailsid,
                         amount = m.amount,
                         product_productid = m.product_productid,
                         invoiceheader_invoiceheaderid = m.invoiceheader_invoiceheaderid

                     });

            IList<invoicedetail> list = new List<invoicedetail>();
            foreach (var a in x)
            {
                invoicedetail m = new invoicedetail();
                m.invoicedetailsid = a.invoicedetailsid;
                m.amount = a.amount;
                m.product_productid = a.product_productid;
                m.invoiceheader_invoiceheaderid = a.invoiceheader_invoiceheaderid;
                list.Add(m);

            }
            return list;
        }

        // GET api/Invoicedetail/5
        public IEnumerable<invoicedetail> Getinvoicedetail(short id)
        {
            //var list = db.invoicedetails.ToList();
            IList<invoicedetail> list = Getinvoicedetails();
            IEnumerable<invoicedetail> invoicedetaillist = (from l in list where l.invoiceheader_invoiceheaderid == id select l);
            //invoicedetail invoicedetail = db.invoicedetails.Find(id);
            //if (invoicedetail == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}

            return invoicedetaillist;
        }

        // PUT api/Invoicedetail/5
        public HttpResponseMessage Putinvoicedetail(short id, invoicedetail invoicedetail)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != invoicedetail.invoicedetailsid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(invoicedetail).State = EntityState.Modified;

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

        // POST api/Invoicedetail
        public invoicedetail Postinvoicedetail(invoicedetail invoicedetail, string purchasetype)
        {

            double amt = 0;

            if (ModelState.IsValid)
            {
                db.invoicedetails.Add(invoicedetail);
                db.SaveChanges();


                BeneficiarycalculationController BeneficiarycalculationController = new Controllers.BeneficiarycalculationController();

                beneficiarycalculation beneficiarycalculation = new Models.beneficiarycalculation();

                List<productbeneficiary> list = db.productbeneficiaries.ToList();
                List<productbeneficiary> productbeneficiarylist = (from l in list where l.product_productid == invoicedetail.product_productid select l).ToList<productbeneficiary>();

                
                foreach(var i in productbeneficiarylist)
                {
                    beneficiarycalculation.purchasetype = purchasetype;
                    amt = invoicedetail.amount * i.royalty / 100;
                    beneficiarycalculation.royaltyamt = amt;
                    beneficiarycalculation.productbeneficiary_productbeneficiaryid = i.productbeneficiaryid;
                    beneficiarycalculation.invoicedetails_invoicedetailsid = invoicedetail.invoicedetailsid;

                    BeneficiarycalculationController.Postbeneficiarycalculation(beneficiarycalculation);

                }

                return invoicedetail;
            }
            else
            {
                return invoicedetail;
                 }
        }

        // DELETE api/Invoicedetail/5
        public HttpResponseMessage Deleteinvoicedetail(short id)
        {
            invoicedetail invoicedetail = db.invoicedetails.Find(id);
            if (invoicedetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.invoicedetails.Remove(invoicedetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, invoicedetail);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}