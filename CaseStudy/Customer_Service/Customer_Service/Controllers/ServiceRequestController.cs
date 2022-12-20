using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Service.Models;

namespace Customer_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        Customer_ServiceContext db = new Customer_ServiceContext();


        [HttpGet]
        [Route("Servicedetails")]
        public IEnumerable<ServiceRequest> Get()
        {
            List<ServiceRequest> serviceRequests = db.ServiceRequests.ToList();
           // List<ServiceRequest> serviceRequests = db.ServiceRequests.Where(x => x.EmailId == Email).ToList();

            return serviceRequests.ToList();
        }

        [HttpGet]
        public IEnumerable<ServiceRequest> Get(string Email)
        {
            //List<ServiceRequest> serviceRequests = db.ServiceRequests.ToList();
            List<ServiceRequest> serviceRequests = db.ServiceRequests.Where(x => x.EmailId == Email).ToList();

            return serviceRequests.ToList();
        }

        [HttpPost]
        public IActionResult Post(ServiceRequest serviceRequest)
        {
            db.ServiceRequests.Add(serviceRequest);
            db.SaveChanges();
            var response = new { Status = "Success" };

            return Ok(response);
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
