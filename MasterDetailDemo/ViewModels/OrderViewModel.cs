using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterDetailDemo.Models;

namespace MasterDetailDemo.ViewModels
{
    public class OrderViewModel
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }

    }
}
