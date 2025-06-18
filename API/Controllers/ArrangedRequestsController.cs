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
        [Route("api/ArrangedRequests/getArrangedRequestOfVolunteer"), HttpGet]
        public IHttpActionResult getArrangedRequestOfVolunteer(string id)
        {

            return Ok(arrangedRequestsBLL.getArrangedRequestOfVolunteer(id));
        } 

        [Route("api/ArrangedRequests/GetArrangedRequests"), HttpGet]
        public IHttpActionResult GetArrangedRequests()
        {
          
            return Ok(arrangedRequestsBLL.GetArrangedRequests());
        } 
        
        [Route("api/ArrangedRequests/GetConfirmedRequestsDetails"), HttpGet]
        public IHttpActionResult GetConfirmedRequestsDetails()
        {
            return Ok(arrangedRequestsBLL.GetConfirmedRequestsDetails());
        }

      

       
    }
}
