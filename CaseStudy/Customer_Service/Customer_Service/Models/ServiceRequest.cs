using System;
using System.Collections.Generic;

#nullable disable

namespace Customer_Service.Models
{
    public partial class ServiceRequest
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string ProblemCategory { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ReStatus { get; set; }
        public DateTime? Date { get; set; }
        public string RejectStatus { get; set; }
    }
}
