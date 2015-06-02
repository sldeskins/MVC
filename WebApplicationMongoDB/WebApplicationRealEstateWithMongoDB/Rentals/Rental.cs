using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplicationRealEstateWithMongoDB.Rentals
{
    public class Rental
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }

        public int NumberOfRooms
        {
            get;
            set;
        }
        public List<string> Address = new List<string>();
        private PostRental postRental;

        public Rental ()
        {

        }
        public Rental ( PostRental postRental )
        {  //this.postRental = postRental;
            Description = postRental.Description;
            NumberOfRooms = postRental.NumberOfRooms;
            Price = postRental.Price;
            Address = (postRental.Address ?? string.Empty).Split('\n').ToList();
        }

        [BsonRepresentation(BsonType.Double)]
        public decimal Price
        {
            get;
            set;
        }
    }
}