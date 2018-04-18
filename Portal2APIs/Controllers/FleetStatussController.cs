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
    public class FleetStatussController : ApiController
    {
        [HttpGet()]
        [Route("api/FleetStatuss/GetFleetStatusBus/{id}")]
        public List<FleetStatus> GetFleetStatusBus(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select fs.FleetStatusID, v.VehicleNumber, v.VehicleId, " +
                               "Case When fs.FrontACStatus = 1 Then 'Good' Else 'Issue' End as FrontACStatus, " +
                               "Case When fs.RearACStatus = 1 Then 'Good' Else 'Issue' End as RearACStatus, " +
                               "fs.LastExWash, " +
                               "fs.LastInExWash, " +
                               "Case When fs.Status = 1 Then 'In Service' Else 'Out of Service' End as Status, " +
                               "fs.OOSDate, " +
                               "fs.EstReturn, " +
                               "fs.Notes " +
                        "from Vehicles.dbo.FleetStatus fs " +
                        "Inner Join Vehicles.dbo.Vehicles v on fs.VehicleId = v.VehicleId " +
                        "Inner Join Vehicles.dbo.VehicleModels vm on v.ModelId = vm.ModelId " +
                        "Where v.CurrentLocationId = " + id + " " +
                        "and fs.UpdatedDate is null " +
                        "and v.VehicleNumber not like '%Stock%' " +
                        "and v.StatusId = 1 " +
                        "and vm.TypeId = 1 " +
                        "Order by v.VehicleNumber";

                List<FleetStatus> list = new List<FleetStatus>();
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
        [Route("api/FleetStatuss/GetFleetStatusOther/{id}")]
        public List<FleetStatus> GetFleetStatusOther(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select fs.FleetStatusID, v.VehicleNumber, v.VehicleId, " +
                               "Case When fs.FrontACStatus = 1 Then 'Good' Else 'Issue' End as FrontACStatus, " +
                               "Case When fs.RearACStatus = 1 Then 'Good' Else 'Issue' End as RearACStatus, " +
                               "fs.LastExWash, " +
                               "fs.LastInExWash, " +
                               "Case When fs.Status = 1 Then 'In Service' Else 'Out of Service' End as Status, " +
                               "fs.OOSDate, " +
                               "fs.EstReturn, " +
                               "fs.Notes " +
                        "from Vehicles.dbo.FleetStatus fs " +
                        "Inner Join Vehicles.dbo.Vehicles v on fs.VehicleId = v.VehicleId " +
                        "Inner Join Vehicles.dbo.VehicleModels vm on v.ModelId = vm.ModelId " +
                        "Where v.CurrentLocationId = " + id + " " +
                        "and fs.UpdatedDate is null " +
                        "and v.VehicleNumber not like '%Stock%' " +
                        "and vm.TypeId <> 1 " +
                        "and v.StatusId = 1 " +
                        "Order by v.VehicleNumber";

                List<FleetStatus> list = new List<FleetStatus>();
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
        [Route("api/FleetStatuss/UpdateFleetStatus/")]
        public string UpdateFleetStatus(FleetStatus fs)
        {
            try
            {
                string strSQL;
                clsADO thisADO = new clsADO();

                var FAC = "";
                var RAC = "";
                var thisStatus = "";

                if (fs.FrontACStatus == "Good") { FAC = "1"; } else { FAC = "0"; };
                if (fs.RearACStatus == "Good") { RAC = "1"; } else { RAC = "0"; };
                if (fs.Status == "In Service") { thisStatus = "1"; } else { thisStatus = "0"; };

                strSQL = "INSERT INTO Vehicles.dbo.FleetStatus " +
                         "(VehicleId, FrontACStatus, RearACStatus, LastExWash, LastInExWash, Status, OOSDate, EstReturn, Notes) " +
                         "VALUES (" + fs.VehicleId + ", " + FAC + ", " + RAC + ", '" + fs.LastExWash + "', '" + fs.LastInExWash +
                         "', " + thisStatus + ", '" + fs.OOSDate + "', '" + fs.EstReturn + "', '" + fs.Notes + "')";

                if (fs.OOSDate.ToString() == "NULL")
                {
                    strSQL = "INSERT INTO Vehicles.dbo.FleetStatus " +
                         "(VehicleId, FrontACStatus, RearACStatus, LastExWash, LastInExWash, Status, OOSDate, EstReturn, Notes) " +
                         "VALUES (" + fs.VehicleId + ", " + FAC + ", " + RAC + ", '" + fs.LastExWash + "', '" + fs.LastInExWash +
                         "', " + thisStatus + ", " + fs.OOSDate + ", '" + fs.EstReturn + "', '" + fs.Notes + "')";
                }

                if (fs.EstReturn.ToString() == "NULL")
                {
                    strSQL = "INSERT INTO Vehicles.dbo.FleetStatus " +
                         "(VehicleId, FrontACStatus, RearACStatus, LastExWash, LastInExWash, Status, OOSDate, EstReturn, Notes) " +
                         "VALUES (" + fs.VehicleId + ", " + FAC + ", " + RAC + ", '" + fs.LastExWash + "', '" + fs.LastInExWash +
                         "', " + thisStatus + ", '" + fs.OOSDate + "', " + fs.EstReturn + ", '" + fs.Notes + "')";
                }

                if (fs.OOSDate.ToString() == "NULL" && fs.EstReturn.ToString() == "NULL")
                {
                    strSQL = "INSERT INTO Vehicles.dbo.FleetStatus " +
                         "(VehicleId, FrontACStatus, RearACStatus, LastExWash, LastInExWash, Status, OOSDate, EstReturn, Notes) " +
                         "VALUES (" + fs.VehicleId + ", " + FAC + ", " + RAC + ", '" + fs.LastExWash + "', '" + fs.LastInExWash +
                         "', " + thisStatus + ", " + fs.OOSDate + ", " + fs.EstReturn + ", '" + fs.Notes + "')";
                }


                thisADO.updateOrInsert(strSQL, false);

                strSQL = "Update Vehicles.dbo.FleetStatus set UpdatedDate = GetDate() Where FleetStatusID = " + fs.FleetStatusID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";

            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(Convert.ToString(ex), System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpGet]
        [Route("api/FleetStatuss/GetLocationsByUserId/{id}")]
        public List<Location> GetLocationsByUserId(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT l.LocationId, l.NameOfLocation " +
                         "from Vehicles.dbo.UserVehicleLocations uvl " +
                         "inner join Vehicles.dbo.Location l on uvl.LocationId = l.LocationId " +
                         "Where uvl.UserId = '" + id + "'";

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
        [Route("api/FleetStatuss/LocationByLocationIds/{ids}")]
        public List<Location> LocationByLocationIds(string ids)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select LocationId, NameOfLocation from Vehicles.dbo.Location where LocationId in (" + ids + ") order by NameOfLocation";
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

        [HttpPost]
        [Route("api/FleetStatuss/InsertFleetStatus/{id}")]
        public string InsertFleetStatus(string id)
        {
            string strSQL = "";

            try
            {
                strSQL = "INSERT INTO Vehicles.dbo.FleetStatus " +
                         "(VehicleId, FrontACStatus, RearACStatus, LastExWash, LastInExWash, Status, OOSDate, EstReturn, Notes) " +
                         "VALUES (" + id + ", 1, 1, getdate(), getdate(), 1, NULL, NULL, '')";

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

        [HttpGet()]
        [Route("api/FleetStatuss/GetFleetStatusEmailAddresses/{id}")]
        public List<Email> GetFleetStatusEmailAddresses(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select FleetStatusEmailAddress as ToEmailAddress from Vehicles.dbo.FleetStatusEmail where FleetStatusEmailLocationId = " + id;

                List<Email> list = new List<Email>();
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
