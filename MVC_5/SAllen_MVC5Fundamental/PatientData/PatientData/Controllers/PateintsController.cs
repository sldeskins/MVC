using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver;
using MongoDB.Bson;

namespace PatientData.Controllers
{
    public class PatientsController : ApiController
    {
        MongoCollection<Patient> _patients;

        public PatientsController ()
        {
            _patients = PatientDb.Open();
        }
        public IEnumerable<Patient> Get ()
        {
            return _patients.FindAll();
        }
        ////way one
        //public HttpResponseMessage Get ( string id )
        //{
        //    var patient = _patients.FindOneById(ObjectId.Parse(id));
        //    if (patient == null)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found!");
        //    }
        //    return Request.CreateResponse(patient);
        //}
        public IHttpActionResult Get ( string id )
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        ////way one
        //[Route("api/patients/{id}/medications")]
        //public HttpResponseMessage GetMedications ( string id )
        //{
        //    var patient = _patients.FindOneById(ObjectId.Parse(id));
        //    if (patient == null)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found!");
        //    }
        //    return Request.CreateResponse(patient.Medications);
        //}
        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications ( string id )
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.Medications);
        }
    }
}
