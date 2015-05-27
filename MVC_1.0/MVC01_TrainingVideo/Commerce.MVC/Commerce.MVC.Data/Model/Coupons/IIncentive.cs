using System;

namespace Commerce.MVC.Data
{
    public interface IIncentive
    {
        string Code { get; set; }
        Commerce.MVC.Data.ICoupon Coupon { get; set; }
        bool Equals(object obj);
        DateTime ExpiresOn { get; set; }
        bool IsExpired { get; }
        int MinimumItems { get; set; }
        decimal MininumPurchase { get; set; }
        string[] MustHaveProducts { get; set; }
        void ValidateUse(Commerce.MVC.Data.Order order);
    }
}
