using System;
using System.Collections.Generic;

#nullable disable

namespace Customer_Service.Models
{
    public partial class TblLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
