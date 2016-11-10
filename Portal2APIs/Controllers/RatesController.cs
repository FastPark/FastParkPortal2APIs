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
    public class RatesController : ApiController
    {
        [HttpPost]
        [Route("api/Rates/GetRateByLocationAndCompanyId/")]
        public String LocationByLocationId(Rate thisRate)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select dbo.GetlocationRateFunction (" + thisRate.CompanyId + ", " + thisRate.LocationId + ")";
                
                string thisReturn = Convert.ToString(thisADO.returnSingleValue(strSQL,false, true));

                return thisReturn;
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
