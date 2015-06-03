using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstateWithMongoDB_WOldDriver.Properties;
using MongoDB.Driver;
using MongoDB.Bson;

namespace RealEstateWithMongoDB_WOldDriver.App_Start
{

    public class RealEstateContext
    {
        public  MongoDatabase Database;

        private  MongoClient client;
        private MongoServer server;
        public MongoServer Server
        {
            get
            {
                return server;
            }
        }

        public RealEstateContext ()
        {
            client = new  MongoClient(Settings.Default.RealEstateConnection);
            server = client.GetServer();
            Database = server.GetDatabase(Settings.Default.RealEstateDatabaseName);


            var mongoClient = new MongoDB.Driver.MongoClient(new MongoDB.Driver.MongoClientSettings()
            {
                Server = new MongoDB.Driver.MongoServerAddress("localhost")
            });

        }
        public MongoCollection<Rentals.Rental> Rentals
        {
            get
            {
                return Database.GetCollection<Rentals.Rental>(Settings.Default.RealEstateCollectionName);
            }
        }
        
    }
}