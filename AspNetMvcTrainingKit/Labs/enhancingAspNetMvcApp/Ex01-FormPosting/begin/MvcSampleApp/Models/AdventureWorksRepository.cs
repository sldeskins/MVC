// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace MvcSampleApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    
    public sealed class AdventureWorksRepository : IDisposable
    {
        private AdventureWorksLTEntities context = new AdventureWorksLTEntities();

        public IEnumerable<Customer> GetCustomers(int page, int size)
        {
            return this.context.Customer.OrderBy(c => c.CustomerID).Skip(page * size).Take(size);
        }

        public Customer GetCustomerById(int customerId)
        {
            return this.context.Customer.Include("CustomerAddress.Address").Where(c => c.CustomerID == customerId).First();
        }

        public void AddAddress(Address address, int customerId)
        {
            address.rowguid = Guid.NewGuid();
            address.ModifiedDate = DateTime.Now;
            this.context.AddObject("Address", address);

            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.Address = address;
            customerAddress.Customer = this.GetCustomerById(customerId);
            customerAddress.rowguid = Guid.NewGuid();
            customerAddress.AddressType = "Shipping";
            customerAddress.ModifiedDate = DateTime.Today;
            this.context.AddObject("CustomerAddress", customerAddress);
            this.context.SaveChanges();
        }

        public void UpdateAddress()
        {
            this.context.SaveChanges();
        }

        public void DeleteAddress(Address address, int customerId)
        {
            CustomerAddress customerAddress = this.GetCustomerAddressById(address.AddressID, customerId);
            this.context.DeleteObject(address);
            this.context.DeleteObject(customerAddress);
            this.context.SaveChanges();
        }

        public Address GetAddressById(int addressId)
        {
            return this.context.Address.Where(a => a.AddressID == addressId).First();
        }

        public CustomerAddress GetCustomerAddressById(int addressId, int customerId)
        {
            return this.context.CustomerAddress.Where(a => a.AddressID == addressId && a.CustomerID == customerId).First();
        }

        public void Dispose()
        {
            this.context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}