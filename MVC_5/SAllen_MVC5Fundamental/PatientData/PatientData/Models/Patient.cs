using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace PatientData 
{
    public class Patient
    {
        [BsonElement("_id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public ICollection<Ailment> Aliments
        {
            get;
            set;
        }
        public ICollection<Medication> Medications
        {
            get;
            set;
        }
    }
    public class Medication
    {
        public string Name
        {
            get;
            set;
        }
        public int Doses
        {
            get;
            set;
        }
    }
    public class Ailment
    {
        public string Name
        {
            get;
            set;
        }

    }
}