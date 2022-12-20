using Customer_Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        Customer_ServiceContext db = new Customer_ServiceContext();

        [HttpGet]
        public IEnumerable<ServiceRequest> Get()
        {
            //List<ServiceRequest> serviceRequests = db.ServiceRequests.ToList();
            List<ServiceRequest> serviceRequests = db.ServiceRequests.Where(x => x.ReStatus != "Rejected" && x.Status != "Close").ToList();

            return serviceRequests.ToList();
        }
        [HttpPut]
        public IActionResult Put(ServiceRequest serviceRequest)
        {
            db.ServiceRequests.Add(serviceRequest);
            db.Entry(serviceRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }

    }
}
