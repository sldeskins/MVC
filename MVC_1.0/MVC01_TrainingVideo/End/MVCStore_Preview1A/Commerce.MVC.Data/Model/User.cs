using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data {
    public class User {

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Order  Cart { get; set; }
        public bool IsAnonymous { get; set; }

        public string FullName {
            get {
                return this.FirstName + " " + this.LastName;
            }
        }

        public User() {
            this.UserName = Guid.NewGuid().ToString();
            this.Cart = new Order();
            this.IsAnonymous = true;
        }
        public User(string first, string last, string email, string userName) {
            this.FirstName = first;
            this.LastName = last;
            this.Email = email;
            this.UserName = userName;
            this.Cart = new Order(userName);
            this.IsAnonymous = false;
        }

    }
}
