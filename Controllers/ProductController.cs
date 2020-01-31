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
    public class ProductController : ApiController
    {
        private BappaEntities db = new BappaEntities();

        // GET api/Product
        public IList<product> Getproducts()
        {
            /*var products = db.products.Include(p => p.author).Include(p => p.category).Include(p => p.language).Include(p => p.producttype);
            return products.AsEnumerable();*/
            var x = (from m in db.products
                     select new { productid = m.productid,
                                 producttitle = m.producttitle, 
                                 price = m.price, 
                                 islibrary = m.islibrary, 
                                 rentcost = m.rentcost,
                                 rentmindays = m.rentmindays,
                                  shortdescription = m.shortdescription,
                                  longdescription = m.longdescription,
                                  imgurl = m.imgurl,
                                  producturl = m.producturl,
                                  avgrating = m.avgrating,
                                  isrent = m.isrent,
                                  author_authorid = m.author_authorid,
                                  category_categoryid = m.category_categoryid,
                                  language_languageid = m.language_languageid,
                                  producttype_producttypeid = m.producttype_producttypeid
                     });
            
            IList<product> l = new List<product>();

            foreach (var m in x)
            {
                                 product p = new product();
                                 p.productid = m.productid;
                                 p.producttitle = m.producttitle;
                                 p.price = m.price;
                                 p.islibrary = m.islibrary;
                                 p.rentcost = m.rentcost;
                                 p.rentmindays = m.rentmindays;
                                  p.shortdescription = m.shortdescription;
                                  p.longdescription = m.longdescription;
                                  p.imgurl = m.imgurl;
                                  p.producturl = m.producturl;
                                  p.avgrating = m.avgrating;
                                  p.isrent = m.isrent;
                                  p.author_authorid = m.author_authorid;
                                  p.category_categoryid = m.category_categoryid;
                                  p.language_languageid = m.language_languageid;
                                  p.producttype_producttypeid = m.producttype_producttypeid;
                l.Add(p);

            }
            return l;
        }

        // GET api/Product/5
        public product Getproduct(short id)
        {
            product product = db.products.Find(id);
            if (product == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return product;
        }

        // PUT api/Product/5
        public HttpResponseMessage Putproduct(short id, product product)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != product.productid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(product).State = EntityState.Modified;

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

        // POST api/Product
        public HttpResponseMessage Postproduct(product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, product);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = product.productid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Product/5
        public HttpResponseMessage Deleteproduct(short id)
        {
            product product = db.products.Find(id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.products.Remove(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}