using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace Commerce.MVC.Data
{
    public interface IShippingService
    {
        IList<ShippingMethod> CalculateRates(Order order);
    }
}
