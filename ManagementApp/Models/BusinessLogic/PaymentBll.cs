using ManagementApp.Models.DataAccess;
using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementApp.Models.Entity.FactoriInterfaces;

namespace ManagementApp.Models.BusinessLogic
{
    public class PaymentBLL
    {
        public IPaymentDA _paymentDA;

        public PaymentBLL(IPaymentDAFactory paymentDAFactory)
        {
            _paymentDA = paymentDAFactory.Create();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentDA.ReadPayment(id);
        }
        public bool UpdatePayment(int paymentId, int orderId, decimal amount, DateTime paymentDate)
        {

            return _paymentDA.UpdatePayment(paymentId, orderId, amount, paymentDate);
        }

        public bool CreatePayment(int orderId, decimal amount, DateTime paymentDate)
        {

            return _paymentDA.CreatePayment(orderId, amount, paymentDate);
        }

        public bool DeletePayment(int paymentId)
        {

            return _paymentDA.DeletePayment(paymentId);
        }
    }
}
