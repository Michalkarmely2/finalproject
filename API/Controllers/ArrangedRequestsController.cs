using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ArrangedRequestsController : ApiController
    {
        ArrangedRequestsBLL arrangedRequestsBLL = new ArrangedRequestsBLL();
        // GET: api/ArrangedRequests
        [Route("api/ArrangedRequests/getArrangedRequestOfVolunteer/{id}"), HttpGet]
        public IHttpActionResult getArrangedRequestOfVolunteer(string id)
        {
            if (id.Length != 9)
            {
                return BadRequest("Volunteer ID is required.");
            }

            var result = arrangedRequestsBLL.getArrangedRequestOfVolunteer(id);

            if (result.Count == 0)
            {
                return NotFound(); // לא נמצאו בקשות עבור מתנדב זה
            }

            return Ok(result);
            
        } 
        // work
        [Route("api/ArrangedRequests/GetArrangedRequests"), HttpGet]
        public IHttpActionResult GetArrangedRequests()
        {
            var result = arrangedRequestsBLL.GetArrangedRequests();

            if (result.Count==0 )
            {
                return NotFound(); // לא נמצאו בקשות עבור מתנדב זה
            }

            return Ok(result);

            
        } 
        
        [Route("api/ArrangedRequests/GetConfirmedRequestsDetails"), HttpGet]
        public IHttpActionResult GetConfirmedRequestsDetails()
        {
            var result = arrangedRequestsBLL.GetConfirmedRequestsDetails();

            if (result.Count == 0)
            {
                return NotFound(); // לא נמצאו בקשות עבור מתנדב זה
            }

            return Ok(result);
        }

      

       
    }
}
