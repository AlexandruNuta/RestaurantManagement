﻿using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Models.BusinessLogic
{
    public class OrderBLL
    {
        private OrderDA _orderDA = new OrderDA();

        // Other methods ...

        public List<Order> GetAllOrders()
        {
            return _orderDA.GetAllOrders();
        }
        public List <OrderProduct> GetAllProductsForOrder(int orderId)
        {
            return _orderDA.GetProductsForOrder(orderId);
        }

        public bool DeleteOrder(int orderId)
        {
            return _orderDA.DeleteOrder(orderId);
        }

        public bool AddProductToOrder(int orderId, int productId, int quantity)
        {
            return _orderDA.AddProductToOrder(orderId, productId, quantity);
        }

        public List<OrderProduct> GetProductsForOrder(int orderId)
        {
            return _orderDA.GetProductsForOrder(orderId);
        }
        public bool CreateOrder(int id, decimal totalAmount, DateTime orderDate, string status, int tableId)
        {
            return _orderDA.CreateOrder(id, totalAmount, orderDate, status, tableId);
        }

        // Other methods ...
    }
}
