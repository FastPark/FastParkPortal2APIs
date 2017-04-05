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
    public class LocationHasFeaturesController : ApiController
    {
        [HttpGet]
        [Route("api/LocationHasFeatures/GetFeature/{id}")]
        public List<LocationHasFeature> GetFeature(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();


            try
            {

                strSQL = "SELECT lhf.LocationHasFeatureId, lhf.OptionalExtrasName " +
                          "FROM Reservations r " +
                          "Inner Join ReservationFeatures rf on r.ReservationId = rf.ReservationId " +
                          "Inner Join LocationHasFeature lhf on rf.LocationHasFeatureId = lhf.LocationHasFeatureId " +
                          "Where r.ReservationId = " + id;

                List<LocationHasFeature> list = new List<LocationHasFeature>();
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
