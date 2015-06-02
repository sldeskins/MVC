using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson.IO;
using MongoDB.Bson; // need to add this to have the toJson extentsion method work with the person object
using MongoDB.Bson.Serialization.Attributes; //need to add this to have [BsonIgnore] to work

namespace Tests
{
    [TestClass]
    public class PocoTests
    {
        public PocoTests ()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }
        public class Person
        {
            public string FirstName
            {
                get;
                set;
            }
            public int Age
            {
                get;
                set;
            }
            public List<string> Address = new List<string>();

             [BsonIgnoreIfNull]
            public Contact Contact;

            [BsonIgnore]
            public string IgnoreMe
            {
                get;
                set;
            }
            [BsonElement("NewName")]
            public string Old
            {
                get;
                set;
            }
            private string privateWillNotShowWithoutSpecialAttribute;

            [BsonElement]
            private string Encapulated="yes";

        }
       
        public class Contact
        {
            public string Email
            {
                get;
                set;
            }
            public string Phone
            {
                get;
                set;
            }
        }
        [TestMethod]
        public void Automatic ()
        {
            var person = new Person
            {
                Age = 52,
                FirstName = "jane"
            };
            person.Address.Add("101 Some Road");
            person.Address.Add("Unit 604");

            person.Contact = new Contact();

            person.Contact.Email = "email#email.com";
            person.Contact.Phone = "123-456-7890";

            Console.WriteLine(person.ToJson());
        }
        [TestMethod]
        public void AutomaticIgnoreIfNull ()
        {
            var person = new Person
            {
                Age = 52,
                FirstName = "jane"
            };
            person.Address.Add("101 Some Road");
            person.Address.Add("Unit 604"); 

            Console.WriteLine(person.ToJson());
        }

    }
}
