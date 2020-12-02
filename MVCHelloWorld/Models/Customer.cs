using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCHelloWorld.Models
{
        
    public class Customer
    {
      
        [Key]
        public int id { get; set; }
        
        public string CustomerName { get; set; }

        public string CustomerWork { get; set; }

        public string Address { get; set; }
        
        public string Country { get; set; }
    }








    public class OurDatabase
    {

        List<Customer> _Customers;
        public List<Customer> Customers
        {
            get
            {

                _Customers = new List<Customer>();

                _Customers.AddRange(new[] {
                   new Customer { id = 1, CustomerName = "Yahya",CustomerWork="Developer", Address = "Gaza", Country = "Germany" },
               new Customer { id = 2, CustomerName = "Khaled",CustomerWork="Developer", Address = "Khanyons", Country = "UEA" },
               new Customer { id = 3, CustomerName = "Lama", CustomerWork="Eng", Address = "Al-Zahra'a", Country = "Palestine"
              }                        });
                return _Customers;
            }

            set
            {
                _Customers = value;
            }
        }

    }

}