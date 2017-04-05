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
        [Route("api/ReservationReports/GetReservationReport/{id}")]
        public List<ReservationReport> GetReservationReport(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "select cast(DATENAME(dw, StartDate) as nvarchar(15)) as DayName, StartDate, startsCount, endsCount from ( " +
                            "SELECT DATEADD(dd,(DATEDIFF(dd, 0, StartDatetime)), 0) as StartDate, " +
                            "COUNT(*) startsCount " +
                            "FROM Reservations " +
                            //"where locationId =  " + id + " " +
                            "GROUP BY DATEADD(dd, (DATEDIFF(dd, 0, StartDatetime)), 0) " +
                        ") starts " +
                        "Inner Join( " +
                            "SELECT DATEADD(dd, (DATEDIFF(dd, 0, EndDatetime)), 0) as EndDate, " +
                            "COUNT(*) endsCount " +
                            "FROM Reservations " +
                            //"where locationId =  " + id + " " +
                            "GROUP BY DATEADD(dd, (DATEDIFF(dd, 0, EndDatetime)), 0) " +
                        ") ends on starts.StartDate = ends.EndDate " +
                        "where StartDate between '12/25/2016 00:00:00' and '12/25/2016 23:59:59' " +
                        "Order by startDate";

                List<ReservationReport> list = new List<ReservationReport>();
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
