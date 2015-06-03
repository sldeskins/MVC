using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateWithMongoDB_WOldDriver.Rentals;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace RealEstateWithMongoDB_WOldDriver.Controllers
{
    public class RentalsController : Controller
    {
        public readonly App_Start.RealEstateContext Context = new App_Start.RealEstateContext();
        // GET: Rentals

        public ActionResult Index ()
        {
            //  var filter =Builders<BsonDocument>.Filter.All<Rentals.Rental>(item=>item.)  ;

            //  var cursor = await Context.Rentals.Find(c => c.Id != BsonNull).FirstOrDefaultAsync();


            var rentals = Context.Rentals.FindAll();
            
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
            Context.Rentals.Insert(rental);
            return RedirectToAction("Index");
        }
        public ActionResult AdjustPrice (string id)
        {
            var rental = GetRental(id);
            return View(rental);
        }

        private Rental GetRental ( string id )
        {
            var rental = Context.Rentals.FindOneById(new ObjectId(id));
            return rental;
        }
        [HttpPost]
        public ActionResult AdjustPrice ( string id , AdjustPrice adjustPrice)
        {
            var rental = GetRental(id);
            rental.AdjustPrice(adjustPrice);
            Context.Rentals.Save(rental);
            return RedirectToAction("Index");
        }

    }
}