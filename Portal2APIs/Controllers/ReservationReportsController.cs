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

                strSQL = "select (" +
                                "select top 1 rf.MaxReservationCount " +
                                "from ReservationFees rf " +
                                "Where '" + locAndDate[1].ToString() + "' between rf.EffectiveDatetime and rf.ExpiresDatetime " +
                                "and rf.IsDeleted = 0 " +
                                "and rf.LocationId = " + locAndDate[0].ToString() + " " +
                                "Order by CreateDatetime Desc " +
                            ") - r.InventoryCount as Avaiable " +
                            "from ReservationInventory r " +
                            "Where '" + locAndDate[1].ToString() + "' = Convert(nvarchar, r.ReservationInventoryDate, 101) " +
                            "and r.LocationId = " + locAndDate[0].ToString();

                thisReport.reserved = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));
                //thisReport.onLot = 127;

                strSQL = "select r.InventoryCount  as Reserved " +
                            "from ReservationInventory r " +
                            "Where '" + locAndDate[1].ToString() + "' = Convert(nvarchar, r.ReservationInventoryDate, 101) " +
                            "and r.LocationId = " + locAndDate[0].ToString();

                thisReport.available = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));

                strSQL = "select Count(*) " +
                        "from reservations r " +
                        "where ReservationStatusId <> 2 " +
                        "and ReservationStatusId <> 3 " +
                        "and Cast(CONVERT(VARCHAR(10), '" + locAndDate[1].ToString() + "', 101) as date) = Cast(CONVERT(VARCHAR(10), StartDatetime, 101) as date) " +
                        "and LocationId = " + locAndDate[0].ToString();

                thisReport.startsCount = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));
                //thisReport.startsCount = 44;

                strSQL = "select Count(*) " +
                        "from reservations r " +
                        "where ReservationStatusId <> 2 " +
                        "and ReservationStatusId <> 3 " +
                        "and Cast(CONVERT(VARCHAR(10), '" + locAndDate[1].ToString() + "', 101) as date) = Cast(CONVERT(VARCHAR(10), EndDatetime, 101) as date) " +
                        "and LocationId = " + locAndDate[0].ToString();

                thisReport.endsCount = Convert.ToInt16(thisADO.returnSingleValueForInternalAPIUse(strSQL, true));
                //thisReport.endsCount = 25;

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
