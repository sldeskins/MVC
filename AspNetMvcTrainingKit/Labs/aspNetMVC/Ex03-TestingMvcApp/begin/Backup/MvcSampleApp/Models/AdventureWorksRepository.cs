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
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    public class AdventureWorksRepository
    {
        AdventureWorksLTEntities context = new AdventureWorksLTEntities();

        public IEnumerable<Customer> GetCustomers(int page, int size)
        {
            return context.Customer.OrderBy(c => c.CustomerID).Skip(page * size).Take(size);
        }

        public Customer GetCustomerById(int customerId)
        {
            return context.Customer.Include("CustomerAddress.Address").Where(c => c.CustomerID == customerId).First();
        }

        public void AddAddress(Address address, int customerId)
        {
            address.rowguid = Guid.NewGuid();
            address.ModifiedDate = DateTime.Now;
            context.AddObject("Address", address);

            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.Address = address;
            customerAddress.Customer = GetCustomerById(customerId);
            customerAddress.rowguid = Guid.NewGuid();
            customerAddress.AddressType = "Shipping";
            customerAddress.ModifiedDate = DateTime.Today;
            context.AddObject("CustomerAddress", customerAddress);
            context.SaveChanges();
        }

        public void UpdateAddress()
        {
            context.SaveChanges();
        }

        public void DeleteAddress(Address address, int customerId)
        {
            CustomerAddress customerAddress = GetCustomerAddressById(address.AddressID, customerId);
            context.DeleteObject(address);
            context.DeleteObject(customerAddress);
            context.SaveChanges();
        }

        public Address GetAddressById(int addressId)
        {
            return context.Address.Where(a => a.AddressID == addressId).First();
        }

        public CustomerAddress GetCustomerAddressById(int addressId, int customerId)
        {
            return context.CustomerAddress.Where(a => a.AddressID == addressId && a.CustomerID == customerId).First();
        }
    }
}