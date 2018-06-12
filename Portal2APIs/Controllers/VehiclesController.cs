using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;
using System.Net;
using System.Net.Http;

namespace Portal2APIs.Controllers
{
    public class VehiclesController : ApiController
    {
        [HttpGet()]
        [Route("api/Vehicles/GetVehiclesByLocation/{id}")]
        public List<Vehicle> GetVehiclesByLocation(int Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select VehicleId, VehicleNumber from Vehicles.dbo.Vehicles where CurrentLocationId = " + Id + " and StatusId = 1 order by VehicleNumber";
                List<Vehicle> list = new List<Vehicle>();
                //thisADO.returnSingleValueForPark09(strSQL, ref list);
                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpGet()]
        [Route("api/Vehicles/GetVehiclesStatusList")]
        public List<VehicleStatus> GetVehiclesStatusList()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select StatusId, StatusDescription from Vehicles.dbo.Status Order By StatusDescription";
                List<VehicleStatus> list = new List<VehicleStatus>();
                //thisADO.returnSingleValueForPark09(strSQL, ref list);
                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpGet]
        [Route("api/Vehicles/GetLocations")]
        public List<Location> GetLocations()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT LocationId, NameOfLocation " +
                         "from Vehicles.dbo.Location " +
                         "Order by NameOfLocation";

                List<Location> list = new List<Location>();
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
