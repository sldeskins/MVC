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
           

           // var rentals =  Context.Database.GetCollection<Rental>("rentals");

            var rentals = Context.Rentals ;
            return View(rentals);
        }
       
        public ActionResult Post ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post ( PostRental postRental )
        {
            var rental = new Rental(postRental);
            Context.RentalsDBCollection.InsertOneAsync(rental);
            return RedirectToAction("Index");
        }
        private Rental GetRental ( string id )
        {
            //var filter = new BsonDocument("_id", new ObjectId(id));
            var filter = MongoDB.Driver.Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            // var rental = Context.Rentals.Find<Rental>(filter).FirstOrDefaultAsync<Rental>();
            var rentals = Context.Database.GetCollection<Rental>("rentals");
            var rental = (Rental)rentals.Find<Rental>(r => r.Id == id);
            return rental;
        }
        public ActionResult Delete ( string id )
        {
            throw new NotImplementedException();
           // Context.Rentals.Remove(MongoDB.Driver.Builders.Query.EQ("_id", new ObjectId(id)));
            return RedirectToAction("Index");
        }
        public ActionResult AdjustPrice ( string id )
        {
            var rental = GetRental(id);
            return View(rental);
        }
        [HttpPost]
        public ActionResult AdjustPrice ( string id, AdjustPrice adjustPrice )
        {
            var rental = GetRental(id);
            rental.AdjustPrice(adjustPrice);
            throw new NotImplementedException();
           // Context.Rentals.Save(rental);
            return RedirectToAction("Index");
        }
    }
}