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

namespace MvcSampleApp.Controllers
{
    using System.Web.Mvc;
    using MvcSampleApp.Models;
    using MvcSampleApp.ViewData;
	using System.Collections.Generic;

    public class AddressController : Controller
    {
        private AdventureWorksRepository repository = new AdventureWorksRepository();

        //
        // GET: /Address/Create

        public ActionResult Create(int customerId)
        {
            AddressViewData addressViewData = new AddressViewData()
            {
                CustomerId = customerId
            };
            return View(addressViewData);
        }

        //
        // POST: /Address/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int customerId, FormCollection collection)
        {
            try
            {
                AddressViewData addressViewData = new AddressViewData();
                UpdateModel(addressViewData);
                this.repository.AddAddress(addressViewData.Address, customerId);
                return RedirectToAction("Info", "Customer", new { id = customerId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int addressId, int customerId)
        {
            AddressViewData addressViewData = new AddressViewData();
            addressViewData.Address = this.repository.GetAddressById(addressId);
            addressViewData.CustomerId = customerId;
            return View(addressViewData);
        }

        //
        // POST: /Address/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int addressId, int customerId, FormCollection collection)
        {
            try
            {
                AddressViewData addressViewData = new AddressViewData();
                addressViewData.Address = this.repository.GetAddressById(addressId);
                UpdateModel(addressViewData);
                this.repository.UpdateAddress();
                return RedirectToAction("Info", "Customer", new { id = customerId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int addressId, int customerId)
        {
            Address address = this.repository.GetAddressById(addressId);
            this.repository.DeleteAddress(address, customerId);
            return RedirectToAction("Info", "Customer", new { id = customerId });
        }
    }
}