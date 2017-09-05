using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hospital.Models;
using Hospital.Providers;

namespace StudentsApi.Controllers
{
    public class UserController : ApiController
    {

        [HttpGet]
        //  [System.Web.Mvc.Route("api/getUser")]
        public IEnumerable<User> Get()
        {
            return UserProvider.GetList();
        }
        [HttpPost]
        [Route("api/userType")]
        public IEnumerable<User> GetUser([FromBody]int i)
        {
            return UserProvider.GetList(i);
        }

        [Route("api/onlineUsers")]
        public IEnumerable<User> Post([FromBody]string value)
        {
            return UserProvider.GetList("");
        }

        [HttpPost]
        [Route("api/updateUser")]
        // Update
        public void Update([FromBody]User u)
        {
            UserProvider.UpdateUser(u);
        }

        public void Post([FromBody]User value)
        {
            UserProvider.AddUser(value);
        }

        [HttpPost]
        [Route("api/sendMessage")]
        public void sendMessage([FromBody]MessageC m)
        {
            UserProvider.InsertMessage(m);
        }

        [HttpPost]
        [Route("api/getMessages")]
        // AddConsultation
        public IEnumerable<MessageC> GetMessages([FromBody]MessageC m)
        {
            return UserProvider.GetMessages(m);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

      
        [HttpPost]
        [Route("api/getUser")]
        // AddConsultation
        public User GetUser([FromBody]User u)
        {
            return UserProvider.GetUser(u);
        }

    }
}
