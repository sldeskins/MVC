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
    using System.Collections.Generic;    

    public interface IAdventureWorksRepository
    {
        IEnumerable<Customer> GetCustomers(int page, int size);
        Customer GetCustomerById(int customerId);        
        void AddAddress(Address address, int customerId);
        void UpdateAddress(); 
        void DeleteAddress(Address address, int customerId);
        Address GetAddressById(int addressId);
        CustomerAddress GetCustomerAddressById(int addressId, int customerId);        
    }
}