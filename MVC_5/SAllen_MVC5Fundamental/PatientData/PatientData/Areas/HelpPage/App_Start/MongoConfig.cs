using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;

namespace PatientData
{
    public static class MongoConfig
    {
        public static void Seed ()
        {
            var patients = PatientDb.Open();
            if (!patients.AsQueryable().Any(p => p.Name == "Scott"))
            {
                var data = new List<Patient>(){
                new Patient{ Name="Scott",
                Aliments = new List<Ailment>() { new Ailment(){ Name="Crazy"}}, 
                Medications = new List<Medication>(){new Medication(){ Doses=2, Name="Paxil"}}
                },new Patient{ Name="Joy",
                Aliments = new List<Ailment>() { new Ailment(){ Name="Crazy"}}, 
                Medications = new List<Medication>(){new Medication(){ Doses=8, Name="ervx"}}
                },
                new Patient{ Name="Sarah",
                Aliments = new List<Ailment>() { new Ailment(){ Name="Crazy"}}, 
                Medications = new List<Medication>(){new Medication(){ Doses=3, Name="levox"}}
                }
                };

                patients.InsertBatch(data);
            }
        }
    }
}