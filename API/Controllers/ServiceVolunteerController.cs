using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ServiceVolunteerController : ApiController
    {
        ServiceVolunteerBLL serviceVolunteerBLL=new ServiceVolunteerBLL();

        [Route("api/ServiceVolunteer/GetTopPersonRequestsByVolunteer"), HttpGet]
        public IHttpActionResult GetTopPersonRequestsByVolunteer(string id)
        {
            if (string.IsNullOrWhiteSpace(id)||id.Length!=9)
            {
                return BadRequest("Volunteer ID is required.");
            }

            var result = serviceVolunteerBLL.GetTopPersonRequestsByVolunteer(id);

            if (result == null)
            {
                return NotFound(); // לא נמצאו בקשות עבור מתנדב זה
            }

            return Ok(result);
        }

        
    }
}
