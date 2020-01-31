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
    public class MyshelfController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Myshelf
      public IList<myshelf> Getmyshelves()
        {
            //var myshelves = db.myshelves.Include(m => m.customer.customerid).Include(m => m.invoiceheader.invoiceheaderid).Include(m => m.product.productid);
            //return myshelves.AsEnumerable();
            ProductController productController = new ProductController();
           var x = (from m in db.myshelves
                     select new { myshelfid =m.myshelfid ,
                         purchasedate = m.purchasedate ,
                         enddate = m.enddate , 
                         purchasetype = m.purchasetype , 
                         rating = m.rating ,
                         customer_customerid = m.customer_customerid,
                         invoiceheader_invoiceheaderid = m.invoiceheader_invoiceheaderid , 
                         product_productid = m.product_productid ,
                     });
              //var x = db.myshelves.ToList<myshelf>();
           IList<myshelf> l = new List<myshelf>();
          foreach(var a in x)
          {
              myshelf m = new myshelf();
              m.myshelfid = a.myshelfid;
               m.myshelfid =a.myshelfid;
               m.purchasedate = a.purchasedate;
              m.enddate = a.enddate;
              m.purchasetype = a.purchasetype;
              m.rating = a.rating;
              m.customer_customerid = a.customer_customerid;
              m.invoiceheader_invoiceheaderid = a.invoiceheader_invoiceheaderid;
              m.product_productid = a.product_productid;
              l.Add(m);

          }
              return l;
        }

        // GET api/Myshelf/5
        public List<myshelf> Getmyshelf( short cid,string purchasetype)
        {

            //List<myshelf> list = db.myshelves.ToList();
            var x = (from m in db.myshelves
                     select new
                     {
                         myshelfid = m.myshelfid,
                         purchasedate = m.purchasedate,
                         enddate = m.enddate,
                         purchasetype = m.purchasetype,
                         rating = m.rating,
                         customer_customerid = m.customer_customerid,
                         invoiceheader_invoiceheaderid = m.invoiceheader_invoiceheaderid,
                         product_productid = m.product_productid
                     });
            //var x = db.myshelves.ToList<myshelf>();
            IList<myshelf> list = new List<myshelf>();
            foreach (var a in x)
            {
                myshelf m = new myshelf();
                m.myshelfid = a.myshelfid;
                m.myshelfid = a.myshelfid;
                m.purchasedate = a.purchasedate;
                m.enddate = a.enddate;
                m.purchasetype = a.purchasetype;
                m.rating = a.rating;
                m.customer_customerid = a.customer_customerid;
                m.invoiceheader_invoiceheaderid = a.invoiceheader_invoiceheaderid;
                m.product_productid = a.product_productid;
                list.Add(m);

            }
            List<myshelf> myshelf = (from l in list where l.customer_customerid == cid select l).ToList<myshelf>();

            if (myshelf == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            if (purchasetype.Contains("purchase"))
            {
                List<myshelf> purchase = (from l in myshelf where l.purchasetype == "purchase" select l).ToList<myshelf>();

                return purchase;
            }
            else if(purchasetype.Contains("rent"))
            {
                List<myshelf> rent = (from l in myshelf where l.purchasetype == "rent" select l).ToList<myshelf>();
                return rent; 
            }
            else if (purchasetype.Contains("lent"))
            {
                List<myshelf> lent = (from l in myshelf where l.purchasetype == "lent" select l).ToList<myshelf>();
                return lent;
            }
            else
            {
                List<myshelf> cart = (from l in myshelf where l.purchasetype == "cart" select l).ToList<myshelf>();
                return cart;
            }
              
}

        // PUT api/Myshelf/5
        public HttpResponseMessage Putmyshelf(short id, myshelf myshelf)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != myshelf.myshelfid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(myshelf).State = EntityState.Modified;

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

        //myshetlf add to cart receiving an array list
        public HttpResponseMessage Postmyshelf(short days, myshelf[] myshelfarr)
        {
            int cnt=0;
            short  invheaderid=0;
            double sumamt=0;
            if (ModelState.IsValid)
            {
                foreach (myshelf myshelf in myshelfarr)
                {
                    ProductController ProductController = new Controllers.ProductController();
                    product product = ProductController.Getproduct(myshelf.product_productid);
                    sumamt = sumamt + product.price;

                }
                foreach (myshelf myshelf in myshelfarr)
                {
                    myshelf.purchasedate = DateTime.Now;


                    if (myshelf.purchasetype.Equals("purchase"))
                    {
                        myshelf.enddate = null;

                        // myshelf.enddate = Convert.ToDateTime(999912312);
                    }
                    else
                    {
                        myshelf.enddate = myshelf.purchasedate.Value.AddDays(days);

                    }


                    ProductController ProductController = new Controllers.ProductController();
                    product product = ProductController.Getproduct(myshelf.product_productid);

                    if (cnt == 0)
                    {
                        InvoiceheaderController InvoiceheaderController = new InvoiceheaderController();
                        invoiceheader invoiceheader = new Models.invoiceheader();

                        invoiceheader.date = DateTime.Now;
                        invoiceheader.totalamount = sumamt;
                        invoiceheader.customer_customerid = myshelf.customer_customerid;

                        invoiceheader = InvoiceheaderController.Postinvoiceheader(invoiceheader, myshelf, product,myshelf.purchasetype,days);
                        myshelf.invoiceheader_invoiceheaderid = invoiceheader.invoiceheaderid;
                        invheaderid = invoiceheader.invoiceheaderid;
                        myshelf.invoiceheader_invoiceheaderid = invoiceheader.invoiceheaderid;

                        cnt++;
                        db.myshelves.Add(myshelf);


                        db.SaveChanges();


                    }
                    else
                    {

                        InvoicedetailController InvoicedetailController = new Controllers.InvoicedetailController();

                        invoicedetail invoicedetail = new invoicedetail();
                        invoicedetail.invoiceheader_invoiceheaderid = invheaderid;
                        invoicedetail.product_productid = myshelf.product_productid;
                        invoicedetail.amount = product.price;

                        InvoicedetailController.Postinvoicedetail(invoicedetail, myshelf.purchasetype);
                        myshelf.invoiceheader_invoiceheaderid = invheaderid;

                        db.myshelves.Add(myshelf);
                        db.SaveChanges();

                    }
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, myshelfarr);
                return response;
            }


            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
                        
        }

        // DELETE api/Myshelf/5
        public HttpResponseMessage Deletemyshelf(short id)
        {
            myshelf myshelf = db.myshelves.Find(id);
            if (myshelf == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.myshelves.Remove(myshelf);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, myshelf);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}