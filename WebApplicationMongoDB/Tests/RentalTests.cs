using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationRealEstateWithMongoDB.Rentals;
using MongoDB.Bson;

namespace Tests
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void ToDocument_RentalWithPrice_PriceRepresentedAsDouble ()
        {
            var rental = new Rental();
            rental.Price = 1;

            var document = rental.ToBsonDocument();

            Assert.AreEqual(BsonType.Double, document["Price"].BsonType);
        }
        [TestMethod]
        public void ToDocument_RentalWithAnId_IdIsRepresentedAsAnObjectId ()
        {
            var rental = new Rental();
            rental.Id = ObjectId.GenerateNewId().ToString();

            var document = rental.ToBsonDocument();

            Assert.AreEqual(BsonType.ObjectId, document["_id"].BsonType);
        }
    }
}
