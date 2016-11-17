using System;
using System.Collections.Generic;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;
using System.Net;
using System.Net.Http;

namespace Portal2APIs.Controllers
{
    public class MarketingRepsController : ApiController
    {
        [HttpGet()]
        [Route("api/MarketingReps/Get")]
        public List<MarketingRep> Get()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select (FirstName + ' ' + LastName) as RepName, RepID, EmailAddress from dbo.MarketingReps";
                List<MarketingRep> list = new List<MarketingRep>();
                thisADO.returnSingleValue(strSQL, true, ref list);

                return list; ;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }
    }
}
