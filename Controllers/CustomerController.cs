using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using bookwrm_03.Models;



namespace bookwrm_03.Controllers
{
    public class CustomerController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Customer
        public IList<customer> Getcustomers()
        {
            //return db.customers.AsEnumerable();

            var x = (from m in db.customers
                     select new
                     {
                         customerid = m.customerid,
                         fname = m.fname,
                         lname = m.lname,
                         address = m.address,
                         age = m.age,
                         emailid = m.emailid,
                         password = m.password,
                         phoneno = m.phoneno
                     }
                    );
            
            IList<customer> l = new List<customer>();
            foreach (var a in x)
            {
                         customer c = new customer();
                         c.customerid = a.customerid;
                         c.fname = a.fname;
                         c.lname = a.lname;
                         c.address = a.address;
                         c.age = a.age;
                         c.emailid = a.emailid;
                         c.password = a.password;
                         c.phoneno = a.phoneno;
                l.Add(c);

            }
            return l;
        }

        // GET api/Customer/5
        public  customer Postcustomer(string emailid , string password)
        {
           // HttpResponse resp=new HttpResponse(new StreamWriter(new MemoryStream()));
            //List<customer> list = db.customers.ToList();

            var x = (from m in db.customers
                     select new
                     {
                         customerid = m.customerid,
                         fname = m.fname,
                         lname = m.lname,
                         address = m.address,
                         age = m.age,
                         emailid = m.emailid,
                         password = m.password,
                         phoneno = m.phoneno
                     }
                  );

            IList<customer> list = new List<customer>();
            foreach (var a in x)
            {
                customer c = new customer();
                c.customerid = a.customerid;
                c.fname = a.fname;
                c.lname = a.lname;
                c.address = a.address;
                c.age = a.age;
                c.emailid = a.emailid;
                c.password = a.password;
                c.phoneno = a.phoneno;
                list.Add(c);

            }

            List<customer> res = (from l in list
                             where l.emailid.Equals(emailid) && l.password.Equals(password)
                             select l).ToList();
            try
            {
                if (res.Count == 0)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }
            }
            catch (Exception e)
            {
               // resp.Write(e);
                return null;
                
            }

            return res[0];


        }

       
        // PUT api/Customer/5
        public HttpResponseMessage Putcustomer(short id, customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != customer.customerid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(customer).State = EntityState.Modified;

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

        // POST api/Customer
        public HttpResponseMessage Postcustomer(customer customer)
        {

            if (ModelState.IsValid)
            {

                List<customer> list = db.customers.ToList();
                List < customer> res= (from l in list where l.emailid.Equals(customer.emailid) select l).ToList<customer>();
             
                
                   if (res.Count == 0)
                   {
                       db.customers.Add(customer);
                       db.SaveChanges();

                       HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
                       response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customer.customerid }));
                       return response;
                   }


                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
                
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // DELETE api/Customer/5
        public HttpResponseMessage Deletecustomer(short id)
        {
            customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.customers.Remove(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}