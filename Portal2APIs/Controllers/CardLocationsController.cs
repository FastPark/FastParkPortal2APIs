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
    public class CardLocationsController : ApiController
    {
        [HttpGet]
        [Route("api/CardLocations/LocationByLocationId/{id}")]
        public List<CardLocation> LocationByLocationId(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select LocationId, ShortLocationName as NameOfLocation from CardDistribution.dbo.LocationDetails where LocationId = " + id + " order by ShortLocationName";
                List<CardLocation> list = new List<CardLocation>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpGet]
        [Route("api/CardLocations/LocationByLocationIds/{ids}")]
        public List<CardLocation> LocationByLocationIds(string ids)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select LocationId, ShortLocationName as NameOfLocation from CardDistribution.dbo.LocationDetails where LocationId in (" + ids + ")";
                List<CardLocation> list = new List<CardLocation>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpGet]
        [Route("api/CardLocations/Locations/")]
        public List<CardLocation> Locations()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select LocationId, ShortLocationName as NameOfLocation from CardDistribution.dbo.LocationDetails where LocationID not in (5, 8)";
                List<CardLocation> list = new List<CardLocation>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpGet]
        [Route("api/CardLocations/LocationsAll/")]
        public List<CardLocation> LocationsAll()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select LocationId, ShortLocationName as NameOfLocation from CardDistribution.dbo.LocationDetails";
                List<CardLocation> list = new List<CardLocation>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpGet]
        [Route("api/CardLocations/GetLocationsAirportID/{id}")]
        public List<CardLocation> LocationByAirportId(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select AirportId from CardDistribution.dbo.LocationDetails where LocationId = " + id;
                List<CardLocation> list = new List<CardLocation>();
                thisADO.returnSingleValue(strSQL, false, ref list);

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
