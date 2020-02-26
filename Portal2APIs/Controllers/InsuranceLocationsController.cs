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
    public class InsuranceLocationsController : ApiController
    {
        [HttpGet]
        [Route("api/InsuranceLocations/GetUserLocations/{ids}")]
        public List<InsuranceLocation> GetUserLocations(string ids)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT LocationID, LocationName + '-' + LocationGLCode as LocationName from InsurancePCA.dbo.Location where VehicleLocationId in (" + ids + ") Order by LocationName";

                List<InsuranceLocation> list = new List<InsuranceLocation>();


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
        [Route("api/InsuranceLocations/GetLocationInfo/{id}")]
        public List<InsuranceLocation> GetLocationInfo(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select l.LocationAddress, c.City, s.StateAbbreviation, l.LocationZip, l.LocationPhone, l.LocationFax, fm.FacilityManagerFirstName + ' ' + fm.FacilityManagerLastName as FacilityManager " +
                            "from InsurancePCA.dbo.Location l " +
                            "Inner Join InsurancePCA.dbo.City c on l.LocationCityID = c.CityID " +
                            "Inner Join InsurancePCA.dbo.State s on l.LocationStateID = s.StateId " +
                            "Inner Join InsurancePCA.dbo.FacilityManager fm on l.FacilityManagerID = fm.FacilityManagerID " +
                            "Where LocationId = " + id;

                List<InsuranceLocation> list = new List<InsuranceLocation>();


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
        [Route("api/InsuranceLocations/GetStates/")]
        public List<InsuranceLocation> GetStates()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select StateId as LocationStateID, StateAbbreviation from InsurancePCA.dbo.State order by StateAbbreviation";

                List<InsuranceLocation> list = new List<InsuranceLocation>();


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
