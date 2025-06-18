using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using DTO;

namespace API.Controllers
{
    public class AskingForHelpController : ApiController
    {
        AskingForHelpBLL askingForHelpBLL=new AskingForHelpBLL();
        // GET: api/AskingForHelp
        
        [Route("api/AskingForHelp/getNotConfirmedRequestsForEachAskingForHelp") ,HttpGet]
        public IHttpActionResult getNotConfirmedRequestsForEachAskingForHelp()
        {
            return Ok(askingForHelpBLL.getNotConfirmedRequestsForEachAskingForHelp());
        } 


        [Route("api/AskingForHelp/getAskingForHelpWithMostNotConfirmedRequests") ,HttpGet]
        public IHttpActionResult getAskingForHelpWithMostNotConfirmedRequests()
        {
            return Ok(askingForHelpBLL.getAskingForHelpWithMostNotConfirmedRequests());
        }
        

    
    }
}
