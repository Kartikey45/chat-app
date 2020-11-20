using System;
using BusinessLayer.Interfaces;
using CommonLayer.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ChatApplicationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatappController : ControllerBase
    {
        //Variable declared
        private readonly IUserBL UserBl;
        private readonly IConfiguration _configuration;

        //Constructor 
        public ChatappController(IUserBL UserBl, IConfiguration _configuration)
        {
            this.UserBl = UserBl;
            this._configuration = _configuration;
        }

        //Method to register user details 
        [HttpPost]
        [Route("Registration")]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                var data = UserBl.Registration(user);
                if (data.Email != null)
                {

                   /* string MSMQ = "\n First Name : " + Convert.ToString(user.FirstName) +
                                    "\n Last Name : " + Convert.ToString(user.LastName) +
                                    "\n User Role : " + Convert.ToString("Customer") +
                                    "\n Email : " + Convert.ToString(user.Email);
                    sender.Message(MSMQ);*/

                    return Ok(new { success = true, Message = "registration successfull", Data = data });
                }
                else
                {
                    return Conflict(new { success = false, Message = "registration failed" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

    }
}
