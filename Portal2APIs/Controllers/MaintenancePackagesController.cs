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
    public class VehicleMaintenancePackagesController : ApiController
    {
        [HttpGet()]
        [Route("api/MaintenancePackages/GetPMIByVehicleID/{id}")]
        public List<VehicleMaintenancePackages> GetPMIByVehicleID(int Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select mp.PackageId, mp.PackageName " +
                         "from Vehicles.dbo.Vehicles v " +
                         "Inner Join Vehicles.dbo.Location l on v.CurrentLocationId = l.LocationId " +
                         "inner Join Vehicles.dbo.MaintenancePackages mp on l.AirportId = mp.AirportId and v.ModelId = mp.ModelId and v.FuelTypeId = mp.FuelTypeId " +
                         "Where v.VehicleId = " + Id + " " +
                         "Order by mp.PackageName";

                List<VehicleMaintenancePackages> list = new List<VehicleMaintenancePackages>();
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
        [Route("api/MaintenancePackages/GetPMIDescription/{id}")]
        public List<VehicleMaintenancePackages> GetPMIDescription(int Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select PackageDescription from Vehicles.dbo.MaintenancePackages Where PackageId = " + Id;

                List<VehicleMaintenancePackages> list = new List<VehicleMaintenancePackages>();
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
    }
}
