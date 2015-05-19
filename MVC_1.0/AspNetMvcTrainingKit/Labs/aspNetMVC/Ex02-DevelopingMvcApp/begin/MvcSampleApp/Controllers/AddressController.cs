using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSampleApp.Models;
using MvcSampleApp.ViewData;

namespace MvcSampleApp.Controllers
{
    public class AddressController : Controller
    {
        private AdventureWorksRepository repository = new AdventureWorksRepository();
        //
        // GET: /Address/

        public ActionResult Create(int customerId)
        {
            AddressViewData addressViewData = new AddressViewData()
            {
                CustomerId = customerId
            };
            return View(addressViewData);
        }

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
        public ActionResult Edit(int addressId, int customerId)
        {
            AddressViewData addressViewData = new AddressViewData();
            addressViewData.Address = this.repository.GetAddressById(addressId);
            addressViewData.CustomerId = customerId;
            return View(addressViewData);
        }
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
