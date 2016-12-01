using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Common;
using Portal2APIs.Models;

namespace Portal2APIs.Controllers
{
    public class RedemptionsController : ApiController
    {
        [HttpPost]
        [Route("api/Redemptions/SetBeenUsed/")]
        public String SetBeenUsed(Redemption Red)
        {
            try
            {
                clsADO thisADO = new clsADO();

                string rateSQL = "Update Redemptions set BeenUsed = 1, DateUsed = '" + DateTime.Now + "', UpdateExternalUserData = '" + Red.UpdateExternalUserData  + "' where RedemptionId = " + Red.RedemptionId;

                thisADO.updateOrInsert(rateSQL, true);

                return "Success";
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

