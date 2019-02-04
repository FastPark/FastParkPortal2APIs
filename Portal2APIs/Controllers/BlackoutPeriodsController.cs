using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;


namespace Portal2APIs.Controllers
{
    public class BlackoutPeriodsController : ApiController
    {
        [HttpGet]
        [Route("api/BlackoutPeriods/GetBlackoutPeriods/")]
        public List<BlackoutPeriod> GetBlackoutPeriods()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT LocationDetails.DisplayName, EffectiveDatetime, ExpiresDatetime " +
                            "FROM BlackoutPeriod INNER JOIN " +
                            "LocationDetails ON BlackoutPeriod.LocationId = LocationDetails.LocationId " +
                            "where blackoutperiodid not in (1,2) " +
                            "ORDER BY LocationDetails.DisplayName, BlackoutPeriod.EffectiveDatetime";

                List<BlackoutPeriod> list = new List<BlackoutPeriod>();

                thisADO.returnSingleValue(strSQL, true, ref list);

                return list;
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
