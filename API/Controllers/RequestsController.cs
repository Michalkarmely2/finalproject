using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RequestsController : ApiController
    {
        RequestsBLL requestsBLL = new RequestsBLL();
        // GET: api/Requests
        [Route("api/AskingForHelp/GetOnHoldRequests"), HttpGet]
        public IHttpActionResult GetOnHoldRequests(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || id.Length != 9)
            {
                return BadRequest("enter correct id");
            }

            var result = GetOnHoldRequests(id);

            if (result == null)
            {
                return NotFound(); // לא נמצאו בקשות עבור מתנדב זה
            }

            return Ok(requestsBLL.GetOnHoldRequests(id));
        }
           
        
        
        [Route("api/AskingForHelp/GetVolunteersByAddressForNextMonth"), HttpGet]
        public IHttpActionResult GetVolunteersByAddressForNextMonth()
        {
            return Ok(requestsBLL.GetVolunteersByAddressForNextMonth());
        }

    }} 

