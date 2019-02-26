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
        [Route("api/Vehicles/GetVehicleByID/{id}")]
        public List<Vehicle> GetVehiclesByID(int Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select v.VehicleId, v.VehicleNumber, v.Year,  vm.MakeName, vmd.ModelName, Vehicles.dbo.GetMileage(V.VehicleId) as Mileage, Vehicles.dbo.GetHours(V.VehicleId) as Hours, VINNumber, v.ModelId, v.FuelTypeId " +
                         "from Vehicles.dbo.Vehicles v " +
                         "inner join Vehicles.dbo.VehicleModels vmd on v.ModelID = vmd.ModelID " +
                         "inner join Vehicles.dbo.VehicleMakes vm on vmd.MakeID = vm.MakeID " +
                         "where VehicleID = " + Id;
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

        [HttpPost()]
        [Route("api/Vehicles/GetVehicleMileageByDate/")]
        public string GetVehicleMileageByDate(Vehicle v)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select EndingMileage from Vehicles.dbo.VehicleDailyTracking where vehicleId = " + v.VehicleId + " and Convert(nvarchar, TrackingDate, 101) = Convert(nvarchar, CAST('" + v.MileageDate + "' as datetime), 101)";
                List<Vehicle> list = new List<Vehicle>();
                //thisADO.returnSingleValueForPark09(strSQL, ref list);
                string thisMileage = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                return thisMileage; ;
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

        [HttpPost()]
        [Route("api/Vehicles/GetVehicleHoursByDate/")]
        public string GetVehicleHoursByDate(Vehicle v)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select EndingEngineHours as Hours from Vehicles.dbo.VehicleDailyTracking where vehicleId = " + v.VehicleId + " and Convert(nvarchar, TrackingDate, 101) = Convert(nvarchar, CAST('" + v.MileageDate + "' as datetime), 101)";
                List<Vehicle> list = new List<Vehicle>();
                //thisADO.returnSingleValueForPark09(strSQL, ref list);
                string thisMileage = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                return thisMileage; ;
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

        [HttpGet]
        [Route("api/Vehicles/GetUsersVehicleLocations/{id}")]
        public List<Location> GetUsersVehicleLocations(string Id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select ShortLocationName " +
                        "from aspnetdb.dbo.aspnet_users u " +
                        "Inner Join Vehicles.dbo.UserVehicleLocations vl on u.UserId = vl.UserId " +
                        "Inner Join Location l on vl.LocationId = l.LocationId " +
                        "where u.UserName = '" + Id + "'";

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
