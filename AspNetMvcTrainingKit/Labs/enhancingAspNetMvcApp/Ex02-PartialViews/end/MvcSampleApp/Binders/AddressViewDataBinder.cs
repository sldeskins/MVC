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

namespace MvcSampleApp.Binders
{
    using System.Globalization;
    using System.Web.Mvc;
    using Models;
    using ViewData;

    public class AddressViewDataBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            AddressViewData addressViewData = (AddressViewData)bindingContext.Model;
            if (addressViewData.Address == null)
            {
                addressViewData.Address = new Address();
            }

            addressViewData.CustomerId = GetValueFromProvider<int>(bindingContext, "CustomerId");

            return RetrieveAddressViewDataFromContext(addressViewData, bindingContext);
        }

        private static AddressViewData RetrieveAddressViewDataFromContext(AddressViewData addressViewData, ModelBindingContext bindingContext)
        {
            if (bindingContext.PropertyFilter("Address.AddressLine1"))
            {
                addressViewData.Address.AddressLine1 = GetValueFromProvider<string>(bindingContext, "Address.AddressLine1");
            }

            if (bindingContext.PropertyFilter("Address.AddressLine2"))
            {
                addressViewData.Address.AddressLine2 = GetValueFromProvider<string>(
                        bindingContext, "Address.AddressLine2");
            }

            if (bindingContext.PropertyFilter("Address.City"))
            {
                addressViewData.Address.City = GetValueFromProvider<string>(bindingContext, "Address.City");
            }

            if (bindingContext.PropertyFilter("Address.CountryRegion"))
            {
                addressViewData.Address.CountryRegion = GetValueFromProvider<string>(
                        bindingContext, "Address.CountryRegion");
            }

            if (bindingContext.PropertyFilter("Address.PostalCode"))
            {
                addressViewData.Address.PostalCode = GetValueFromProvider<string>(bindingContext, "Address.PostalCode");
            }

            if (bindingContext.PropertyFilter("Address.StateProvince"))
            {
                addressViewData.Address.StateProvince = GetValueFromProvider<string>(
                        bindingContext, "Address.StateProvince");
            }

            return addressViewData;
        }

        private static T GetValueFromProvider<T>(ModelBindingContext bindingContext, string key)
        {
            ValueProviderResult valueProviderResult;
            bindingContext.ValueProvider.TryGetValue(key, out valueProviderResult);
            if (valueProviderResult != null)
            {
                return (T)valueProviderResult.ConvertTo(typeof(T), CultureInfo.CurrentUICulture);
            }

            return default(T);
        }
    }
}