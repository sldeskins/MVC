using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace PatientData
{
    public class PatientDb
    {
        public static MongoCollection<Patient> Open ()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb://localhost");
            var server = client.GetServer();
            var db = server.GetDatabase("PatientDb");
            return db.GetCollection<Patient>("Patients");
        }

    }
}