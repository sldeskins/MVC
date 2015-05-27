using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data
{
    public interface ICoupon
    {
        void ApplyCoupon(Order order);
    }
}
