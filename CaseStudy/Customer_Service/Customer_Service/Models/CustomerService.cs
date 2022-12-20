using System;
using System.Collections.Generic;

#nullable disable

namespace Customer_Service.Models
{
    public partial class CustomerService
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Pan { get; set; }
        public string Contact { get; set; }
        public string DateofBirth { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
