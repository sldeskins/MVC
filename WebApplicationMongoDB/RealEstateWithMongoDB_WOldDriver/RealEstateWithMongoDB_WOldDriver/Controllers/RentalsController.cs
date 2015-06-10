using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateWithMongoDB_WOldDriver.Rentals;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoDB.Driver.GridFS;

namespace RealEstateWithMongoDB_WOldDriver.Controllers
{
    public class RentalsController : Controller
    {
        public readonly App_Start.RealEstateContext Context = new App_Start.RealEstateContext();
        // GET: Rentals

        public ActionResult Index ( RentalsFilter filters )
        {
            //var rentals = FilterRentals1(filters)
            //    .SetSortOrder(SortBy<Rental>.Ascending(r => r.Price));
            var rentals = FilterRentals(filters);

            var model = new RentalsList
            {
                Rentals = rentals,
                Filters = filters
            };
            return View(model);
        }
        private IEnumerable<Rental> FilterRentals ( RentalsFilter filters )
        {
            //note: need to add using MongoDB.Driver.Linq; to pick up the linq extension methods with the mongodriver
            IQueryable<Rental> rentals = Context.Rentals.AsQueryable()
                .OrderBy(r => r.Price);

            if (filters.MinimunRooms.HasValue)
            {
                rentals = rentals.Where(r => r.NumberOfRooms >= filters.MinimunRooms);
            }
            if (filters.PriceLimit.HasValue)
            {
                var query = MongoDB.Driver.Builders.Query<Rental>.LTE(r => r.Price, filters.PriceLimit);
                rentals = rentals.Where(r => query.Inject());
            }
            return rentals;
        }
        private MongoCursor<Rental> FilterRentals1 ( RentalsFilter filters )
        {
            //before
            if (!filters.PriceLimit.HasValue)
            {
                return Context.Rentals.FindAll();
            }
            var query = MongoDB.Driver.Builders.Query<Rental>.LTE(r => r.Price, filters.PriceLimit);
            return Context.Rentals.Find(query);
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
        public string PriceDistribution ()
        {
            return new QueryPriceDistribution().Run(Context.Rentals).ToJson();
        }
        public ActionResult AttachImage ( string id )
        {
            var rental = GetRental(id);
            return View(rental);
        }
        [HttpPost]
        public ActionResult AttachImage ( string id, HttpPostedFileBase file )
        {
            var rental = GetRental(id);
            if (rental.HasImage())
            {
                DeleteImage(rental);
            }
            StoreImage(file, rental);

            // rental.ImageId = fileInfo.Id.AsObjectId.ToString();
            Context.Rentals.Save(rental);
            return RedirectToAction("Index");
        }

        private void DeleteImage ( Rental rental )
        {
            Context.Database.GridFS.DeleteById(new ObjectId(rental.ImageId));
            rental.ImageId = null;
            Context.Rentals.Save(rental);
        }

        private void StoreImage ( HttpPostedFileBase file, Rental rental )
        {
            var imageId = ObjectId.GenerateNewId();
            rental.ImageId = imageId.ToString();
            Context.Rentals.Save(rental);

            var options = new MongoGridFSCreateOptions
            {
                Id = imageId,
                ContentType = file.ContentType
            };
            var fileInfo = Context.Database.GridFS.Upload(file.InputStream, file.FileName, options);
        }
        public ActionResult GetImage ( string id )
        {
            var image = Context.Database.GridFS.FindOneById(new ObjectId(id));
            if (image == null)
            {
                return HttpNotFound();
            }
            return File(image.OpenRead(), image.ContentType);
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