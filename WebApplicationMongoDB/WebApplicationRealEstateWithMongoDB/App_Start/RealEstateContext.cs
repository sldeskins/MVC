using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationRealEstateWithMongoDB.Properties;
using MongoDB.Driver;

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
        public MongoDB.Driver.IMongoCollection<Rentals.Rental> Rentals
        {
            get
            { 
                return Database.GetCollection<Rentals.Rental>(Settings.Default.RealEstateCollectionName);
            }
        }
    }
}