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
    public class VehicleTrackingsController : ApiController
    {
        [HttpGet()]
        [Route("api/VehicleTrackings/GetTrackingByLocation/{id}")]
        public List<VehicleTracking> GetTrackingByLocation(int Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select vdt.VehicleId, v.VehicleNumber, vdt.TrackingDate, vdt.StartingMileage, vdt.EndingMileage, vdt.StartingEngineHours, vdt.EndingEngineHours, vdt.FuelTotal, vdt.FuelPrice " +
                            "from Vehicles.dbo.VehicleDailyTracking vdt " +
                            "Inner Join Vehicles.dbo.Vehicles v on vdt.VehicleId = v.VehicleId " +
                            "Where v.VehicleId = " + Id + " " +
                            "Order by vdt.TrackingDate desc";

                List<VehicleTracking> list = new List<VehicleTracking>();
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

        [HttpPost]
        [Route("api/VehicleTrackings/UpdateTracking")]
        public string UpdateTracking(VehicleTracking vt)
        {
            string strSQL = "";

            try
            {
                strSQL = "Update Vehicles.dbo.VehicleDailyTracking set StartingMileage = " + vt.StartingMileage + ", EndingMileage = " + vt.EndingMileage + ", StartingEngineHours = " + vt.StartingEngineHours + ", EndingEngineHours = " + vt.EndingEngineHours +
                                                         ", FuelTotal = IsNull(" + vt.FuelTotal + ", 0), FuelPrice = IsNull(" + vt.FuelPrice + ", 0) " +
                         "Where VehicleId = " + vt.VehicleId + " and Convert(nvarchar, TrackingDate, 101) = Convert(nvarchar, Cast('" + vt.TrackingDate + "' as datetime), 101)";

                clsADO thisADO = new clsADO();

                thisADO.updateOrInsert(strSQL, false);

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
