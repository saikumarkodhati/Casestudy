using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Service.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Customer_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        Customer_ServiceContext db;

        private IConfiguration _config;

        public CustomerController(IConfiguration config, Customer_ServiceContext _db)
        {
            _config = config;
            db = _db;
        }

        [HttpGet]
        public IEnumerable<CustomerService> Get()
        {
            List<CustomerService> customerServices = db.CustomerServices.ToList();

            return customerServices.ToList();
        }

        [HttpPost]
        [Route("login-customer")]
        public IActionResult Login(CustomerService login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login, false);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private CustomerService AuthenticateUser(CustomerService login, bool IsRegister)
        {
            if (IsRegister)
            {
               var log = db.CustomerServices.Where(x => x.Email == login.Email).Count();
                if (log==0)
                {
                    db.CustomerServices.Add(login);
                    db.SaveChanges();
                    return login;
                }
                else
                {
                      return login;
                }
               
            }
            else
            {
                if (db.CustomerServices.Any(x => x.Email == login.Email && x.Password == login.Password))
                {
                    return db.CustomerServices.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }

        }
        private string GenerateToken(CustomerService login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.Email)
                }),
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = credentials
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = TokenHandler.CreateToken(token);
            return TokenHandler.WriteToken(tokenGenerated).ToString();
        }


        [HttpPost]
        [Route("register-customer")]
        public IActionResult Register(CustomerService login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login, true);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [HttpPut]
        public IActionResult Put(CustomerService customerService)
        {
            db.CustomerServices.Add(customerService);
            db.Entry(customerService).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }
    }
}
