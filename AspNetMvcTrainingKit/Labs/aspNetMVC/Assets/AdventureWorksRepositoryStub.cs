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

namespace MvcSampleApp.Tests
{
    using System;
    using System.Collections.Generic;
    using MvcSampleApp.Models;

    public class AdventureWorksRepositoryStub : IAdventureWorksRepository
    {       
        public IEnumerable<Customer> GetCustomers(int page, int size)
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new Customer();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = new Customer();
            customer.CustomerID = customerId;
            return customer;
        }

        public void AddAddress(Address address, int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress()
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(Address address, int customerId)
        {
            throw new NotImplementedException();
        }

        public Address GetAddressById(int addressId)
        {
            throw new NotImplementedException();
        }

        public CustomerAddress GetCustomerAddressById(int addressId, int customerId)
        {
            throw new NotImplementedException();
        }        
    }
}