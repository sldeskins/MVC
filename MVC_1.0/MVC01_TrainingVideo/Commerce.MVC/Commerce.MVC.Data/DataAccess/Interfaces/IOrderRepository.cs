using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commerce.MVC.Data;

namespace Commerce.MVC.Data 
{
    public interface IOrderRepository {
        IQueryable<Order> GetOrders();
        IQueryable<OrderItem> GetOrderItems();
        
        IQueryable<Address> GetAddresses();
        IQueryable<Transaction> GetTransactions();


        void SaveAddress(Address address);
        void DeleteAddress(int addressID);

        void SaveItems(Order order);
        bool DeleteOrder(Guid orderID);

        void SaveOrder(Order order);
        void DeleteTransaction(Guid transactionID);
        
    }
}
