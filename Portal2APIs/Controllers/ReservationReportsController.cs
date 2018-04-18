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
    public class ReservationReportsController : ApiController
    {
        [HttpGet]
        [Route("api/ReservationReports/GetReservationReport/{LocAndDate}")]
        public ReservationReport GetReservationReport(string LocAndDate)
        {
            try
            {
                LocAndDate = LocAndDate.Replace('-', '/');
                string[] locAndDate = LocAndDate.Split('_');

                string strSQL = "";
                clsADO thisADO = new clsADO();
                ReservationReport thisReport = new ReservationReport();

                ////This is the caluculated available
                //strSQL = "select ( " +
                //               "select top 1 rf.MaxReservationCount " +
                //               "from ReservationFees rf " +
                //               "Where (Cast('" + locAndDate[1].ToString() + "' as datetime) between rf.EffectiveDatetime and rf.ExpiresDatetime or (IsDefault=1  and rf.ExpiresDatetime is null)) " +
                //               "and rf.IsDeleted = 0 " +
                //               "and rf.LocationId = " + locAndDate[0].ToString() + " " +
                //               "Order by CreateDatetime Desc " +
                //            ") - " +
                //            "Count(r.ReservationId) as Available " +
                //            "from Reservations r " +
                //            "Where Cast('" + locAndDate[1].ToString() + " 00:00:00' as datetime) between Cast(Convert(nvarchar, r.StartDatetime, 101) + ' 00:00:00' as datetime) and Cast(Convert(nvarchar, r.EndDatetime, 101) + ' 23:59:59' as datetime) " +
                //            "and r.ReservationStatusId <> 2 " +
                //            "and r.LocationId = " + locAndDate[0].ToString();

                //This is the avaiable from the inventory table
                strSQL = "select r.InventoryCount  as available " +
                         "from ReservationInventory r " +
                         "Where '" + locAndDate[1].ToString() + "' = Convert(nvarchar, r.ReservationInventoryDate, 101) " +
                         "and r.LocationId = " + locAndDate[0].ToString();

                thisReport.available = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                ////This is the counted reserved 
                //strSQL = "Select Count(r.ReservationId)  as reserved " +
                //        "from Reservations r " +
                //        "Where Cast('" + locAndDate[1].ToString() + " 00:00:00' as datetime) between Cast(Convert(nvarchar, r.StartDatetime, 101) + ' 00:00:00' as datetime) and Cast(Convert(nvarchar, r.EndDatetime, 101) + ' 23:59:59' as datetime) " +
                //        "and r.ReservationStatusId <> 2 " +
                //        "and r.LocationId = " + locAndDate[0].ToString();

                //This is the reserved from the location max - the available from the inventory table
                strSQL = "select (" +
                            "select top 1 rf.MaxReservationCount " +
                            "from ReservationFees rf " +
                            "Where " +
                            "(" +
                               "(cast('" + locAndDate[1].ToString() + "' as date) between rf.EffectiveDatetime and rf.ExpiresDatetime) " +
                               "or " +
                               "(IsDefault = 1  and rf.ExpiresDatetime is null)" +
                            ") " +
                            "and rf.IsDeleted = 0 " +
                            "and rf.LocationId = " + locAndDate[0].ToString() + " " +
                            "Order by CreateDatetime Desc" +
                        ") -r.InventoryCount as available " +
                        "from ReservationInventory r " +
                       " Where '" + locAndDate[1].ToString() + "' = Convert(nvarchar, r.ReservationInventoryDate, 101) " +
                        "and r.LocationId =" + locAndDate[0].ToString();

                thisReport.reserved = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                strSQL = "select Count(*) " +
                        "from reservations r " +
                        "where ReservationStatusId <> 2 " +
                        "and Cast(CONVERT(VARCHAR(10), '" + locAndDate[1].ToString() + "', 101) as date) = Cast(CONVERT(VARCHAR(10), StartDatetime, 101) as date) " +
                        "and LocationId = " + locAndDate[0].ToString();

                thisReport.startsCount = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                strSQL = "select Count(*) " +
                        "from reservations r " +
                        "where ReservationStatusId <> 2 " +
                        "and Cast(CONVERT(VARCHAR(10), '" + locAndDate[1].ToString() + "', 101) as date) = Cast(CONVERT(VARCHAR(10), EndDatetime, 101) as date) " +
                        "and LocationId = " + locAndDate[0].ToString();

                thisReport.endsCount = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                return thisReport;
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
