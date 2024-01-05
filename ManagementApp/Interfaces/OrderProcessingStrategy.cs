using ManagementApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Interfaces
{
    public interface IOrderProcessingStrategy
    {
        void ProcessOrder(Order order);
    }
}
