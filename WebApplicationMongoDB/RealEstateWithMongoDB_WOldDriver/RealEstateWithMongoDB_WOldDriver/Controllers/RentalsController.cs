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

        private Rental GetRental ( string id )
        {
            var rental = Context.Rentals.FindOneById(new ObjectId(id));
            return rental;
        }
        public ActionResult Delete ( string id )
        {
            Context.Rentals.Remove(MongoDB.Driver.Builders.Query.EQ("_id", new ObjectId(id)));
            return RedirectToAction("Index");
        }
        public ActionResult AdjustPrice ( string id )
        {
            var rental = GetRental(id);
            return View(rental);
        }

        #region example save/update document replacement
        [HttpPost]
        public ActionResult AdjustPrice ( string id, AdjustPrice adjustPrice )
        {
            var rental = GetRental(id);
            rental.AdjustPrice(adjustPrice);
            Context.Rentals.Save(rental);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AdjustPriceAlternative ( string id, AdjustPrice adjustPrice )
        {
            var rental = GetRental(id);
            rental.AdjustPrice(adjustPrice);
            Context.Rentals.Update(MongoDB.Driver.Builders.Query.EQ("_id", new ObjectId(id)), MongoDB.Driver.Builders.Update.Replace(rental), MongoDB.Driver.UpdateFlags.Upsert);
            return RedirectToAction("Index");
        }

        //   [HttpPost]
        //   public ActionResult AdjustPriceUsingModification ( string id, AdjustPrice adjustPrice )
        //   {
        //       var rental = GetRental(id);
        //       var adjustment = new PriceAdjustment(adjustPrice, rental.Price);
        //    var modificationUpdate = new MongoDB.Driver.Builders.Update<Rental>
        //        .Push(r=>r.Adjustments, adjustment)
        //        .Set(ref=>ref.Price. adjustPrice.NewPrice);
        //Context.Rentals.Update(MongoDB.Driver.Builders.Query.EQ("_id", new ObjectId(id)),modificationUpdate);

        //       return RedirectToAction("Index");
        //   }
        #endregion

        #region  mongodb update examples

        private class Person
        {
            public int Age
            {
                get;
                set;
            }
        }
        private void updateSamples ()
        {
            ////Mongodb command
            //{
            //    "$set": {
            //    "Age":54
            //    }
            //}

            var update = MongoDB.Driver.Builders.Update.Set("Age", 54);
            var update2 = new MongoDB.Driver.Builders.UpdateBuilder().Set("Age", 54);

            //using strongly typed model
            var update3 = MongoDB.Driver.Builders.Update<Person>.Set(p => p.Age, 54);


            var update4 = new UpdateDocument
            {
                {"set", new BsonDocument{
                    {"Age",54}
                    }
                }
            };

            //example5
            var document = new BsonDocument{
                {
                    "$set", new  BsonDocument{
                        {"Age", 54}
                    }
                }
            };
            var update5 = MongoDB.Driver.Wrappers.UpdateWrapper.Create(document);
        }

        #endregion
    }
}