using Connectivity_Pro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;

namespace Connectivity_Pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Connectivity_ProContext mycontext;

       public UserController(Connectivity_ProContext mycontext)
       {
           this.mycontext = mycontext;
       }

       [HttpGet("/{email}")]
       public List<User> GetUserByEmail(string email)
       {
           var data=this.mycontext.Users.Where(x => x.Email == email).ToList();
           return data;
       }

       [HttpGet]
       public List<User> GetAllUser()
           {
               var data = this.mycontext.Users.ToList();
               return data;
           }

        [HttpPost]
        public ActionResult<string> CreateUser(User obj)
        {
            String firstname = obj.FirstName;
            if (IsValidName(firstname) == true)
            {
                return BadRequest("Name should not contain any whitespace");
            }
            else
            {
                this.mycontext.Add(obj);
                this.mycontext.SaveChanges();
                return Ok("Success");
            }
        }


           [HttpPut]
           public ActionResult<string> UpdateUser(User obj)
           {
                String firstname = obj.FirstName;
                if (obj == null || obj.Email == null)
                {
                    return BadRequest("Invalid Request");
                }
                var data = this.mycontext.Users.Find(obj.Email);
                if (data == null)
                {
                    return NotFound("The requested resource was not found.");
                }
                if (IsValidName(firstname) == true)
                {
                    return BadRequest("Name should not contain any whitespace");
                }
                data.FirstName = obj.FirstName;
                data.LastName = obj.LastName;
                data.Email = obj.Email;
                data.Password = obj.Password;
                data.Dob = obj.Dob;
                data.Gender = obj.Gender;
                this.mycontext.SaveChanges();
                return Ok("Success");
           }

           [HttpDelete]
           public ActionResult<string> RemoveUser(string Email)
           {
               var data = this.mycontext.Users.Find(Email);
               if (data == null)
               {
                   return NotFound("The requested resource was not found.");
               }
               this.mycontext.Users.Remove(data);
               this.mycontext.SaveChanges();
               return Ok("Success");
           }

        private bool IsValidName(string Firstname)
        {
            if (Firstname.Any(x => Char.IsWhiteSpace(x)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
