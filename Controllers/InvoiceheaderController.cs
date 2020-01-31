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
    public class InvoiceheaderController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Invoiceheader
        public IEnumerable<invoiceheader> Getinvoiceheaders()
        {
            var invoiceheaders = db.invoiceheaders.Include(i => i.customer);
            return invoiceheaders.AsEnumerable();
        }

        // GET api/Invoiceheader/5
        public IEnumerable<invoicedetail> Getinvoiceheader(short id)
        {
            IEnumerable<Int16> x = (from l in db.invoiceheaders.ToList() where l.customer_customerid == id select l.invoiceheaderid);
            short x1 = x.Max();

            InvoicedetailController i = new InvoicedetailController();
            IEnumerable<invoicedetail> ilist = i.Getinvoicedetail(x1);
            return ilist;
        }

        // PUT api/Invoiceheader/5
        public HttpResponseMessage Putinvoiceheader(short id, invoiceheader invoiceheader)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != invoiceheader.invoiceheaderid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(invoiceheader).State = EntityState.Modified;

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

        // POST api/Invoiceheader
        public invoiceheader Postinvoiceheader(invoiceheader invoiceheader, myshelf myshelf, product product,string purchasetype,short days)
        {
            if (ModelState.IsValid)
            {
                db.invoiceheaders.Add(invoiceheader);
                
                db.SaveChanges();


                InvoicedetailController InvoicedetailController = new Controllers.InvoicedetailController();

                invoicedetail invoicedetail = new invoicedetail();
                invoicedetail.invoiceheader_invoiceheaderid = invoiceheader.invoiceheaderid;
                invoicedetail.product_productid =myshelf.product_productid ;

                if (purchasetype.Contains("rent"))
                {
                    invoicedetail.amount = product.rentcost * days;
                    invoiceheader.totalamount = product.rentcost * days;
                }
                else
                invoicedetail.amount = Convert.ToInt32(product.price);

                InvoicedetailController.Postinvoicedetail(invoicedetail, purchasetype);

                 db.SaveChanges();
                // HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, invoiceheader);
               // response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = invoiceheader.invoiceheaderid }));
                return invoiceheader;
            }
            else
            {
                return invoiceheader;
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Invoiceheader/5
        public HttpResponseMessage Deleteinvoiceheader(short id)
        {
            invoiceheader invoiceheader = db.invoiceheaders.Find(id);
            if (invoiceheader == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.invoiceheaders.Remove(invoiceheader);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, invoiceheader);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}