using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text;

namespace RealEstateWithMongoDB_WOldDriver.Rentals
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

        public List<PriceAdjustment> Adjustments = new List<PriceAdjustment>();

        [BsonIgnore]
        public string AddressString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var a in Address)
                {
                    sb.AppendLine(a);
                }
                return sb.ToString();
            }
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

        internal void AdjustPrice ( AdjustPrice adjustPrice )
        {
            var adjustment = new PriceAdjustment(adjustPrice, Price);
            Adjustments.Add(adjustment);
            Price = adjustment.NewPrice;
        }
    }
}