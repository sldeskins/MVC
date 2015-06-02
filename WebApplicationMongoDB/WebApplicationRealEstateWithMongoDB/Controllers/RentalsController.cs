using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRealEstateWithMongoDB.Rentals;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace WebApplicationRealEstateWithMongoDB.Controllers
{
    public class RentalsController : Controller
    {
        public readonly App_Start.RealEstateContext Context = new App_Start.RealEstateContext();
        // GET: Rentals

        public ActionResult Index ()
        {
            //  var filter =Builders<BsonDocument>.Filter.All<Rentals.Rental>(item=>item.)  ;

            //  var cursor = await Context.Rentals.Find(c => c.Id != BsonNull).FirstOrDefaultAsync();
            var t = this.getCollection();
            t.Wait();
            
            return View("Post");
        }
        private async Task getCollection ()
        {
            await Context.Rentals.Find(c => c.NumberOfRooms>0).FirstOrDefaultAsync();
        }
        public ActionResult Post ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post ( PostRental postRental )
        {
            var rental = new Rental(postRental);
            Context.Rentals.InsertOneAsync(rental);
            return RedirectToAction("Index");
        }
    }
}