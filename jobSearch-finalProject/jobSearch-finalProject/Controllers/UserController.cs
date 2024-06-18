using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Collections.Generic;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public string JsonUrl = "E:/תשפד/Angular/angular-finalProject/New folder/.net-Server-for-Angular-jobSearch-/jobSearch-finalProject/jobSearch-finalProject/data/Users.json";
        public string JsonData { get; set; }
        public List<User> UserList { get; set; }
        public User UserDetails { get; set; }
        public UserController()
        {

            JsonData = System.IO.File.ReadAllText(JsonUrl);
            UserList = JsonSerializer.Deserialize<List<User>>(JsonData);
        }
        // GET: api/<PersonController>
        [HttpGet("GetUsers")]
        public List<User> Get()
        {
            return UserList;
        }

        // GET api/<UserController>/5
        [HttpGet("{userName}/{password}")]
        public User Get(string userName , string password)
        {
            if(userName == null || password == null)                
                return null;
            UserDetails = UserList.Find(u => u.userName == userName &&  u.password == password);
            if (UserDetails != null)
                return UserDetails;
            else
                return null;
        }

        // POST api/<PersonController>
        //    [HttpPost("AddPerson")]
        //    public void Post([FromBody] User newPerson)
        //    {
        //        allPeople.Add(newPerson);
        //    }

        // PUT api/<PersonController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string profession)
        //{
        //    var userToUpdate = UserList.Find(u => u.Id == id);
        //    if (userToUpdate != null)
        //    {
        //        userToUpdate.profession == profession;
        //    }
        //}

        //    // DELETE api/<PersonController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
    }
}
