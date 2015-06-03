using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationRealEstateWithMongoDB.Properties;
using MongoDB.Driver;
using System.Collections;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace WebApplicationRealEstateWithMongoDB.App_Start
{

    public class RealEstateContext
    {
        public MongoDB.Driver.IMongoDatabase Database;

        private MongoDB.Driver.MongoClient client;
        private MongoDB.Driver.MongoServerAddress server;
        public MongoDB.Driver.MongoServerAddress Server
        {
            get
            {
                return server;
            }
        }

        public RealEstateContext ()
        {
            client = new MongoDB.Driver.MongoClient(Settings.Default.RealEstateConnection);
            server = client.Settings.Server;
            Database = client.GetDatabase(Settings.Default.RealEstateDatabaseName);


            var mongoClient = new MongoDB.Driver.MongoClient(new MongoDB.Driver.MongoClientSettings()
            {
                Server = new MongoDB.Driver.MongoServerAddress("localhost")
            });

        }
        public  MongoDB.Driver.IMongoCollection<Rentals.Rental> RentalsDBCollectionAsync
        {
            get
            {
                return  Database.GetCollection<Rentals.Rental>(Settings.Default.RealEstateCollectionName);
            }
        }
        public MongoDB.Driver.IMongoCollection<Rentals.Rental> RentalsDBCollection
        {
            get
            {
                return Database.GetCollection<Rentals.Rental>(Settings.Default.RealEstateCollectionName);
            }
        }
         public List<Rentals.Rental> Rentals
        {
            get
            {
                throw new NotImplementedException();
            }
            //get
            //{
            //    List<Rentals.Rental> rentals = new List<WebApplicationRealEstateWithMongoDB.Rentals.Rental>();
            //    var t= Database.GetCollection<Rentals.Rental>(Settings.Default.RealEstateCollectionName).Find(a => a.Id != "").ToListAsync();
            //    rentals = t.Result;

            //    return rentals;
            //}
            //get
            //{
            //    var filter = new BsonDocument();
            //    using (var cursor = await RentalsDBCollection.Find(filter).ToCursorAsync())
            //    {
            //        while (await cursor.MoveNextAsync())
            //        {
            //            foreach (var doc in cursor.Current)
            //            {
            //                // do something with the documents
            //            }
            //        }
            //    }
            //}
        }
        
    }
}