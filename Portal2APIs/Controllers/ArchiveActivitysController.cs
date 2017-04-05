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
    public class ArchiveActivitysController : ApiController
    {
        [HttpGet]
        [Route("api/ArchiveActivitysController/GetArchive/{id}")]
        public List<ArchiveActivity> NotesByMemberId(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select * from (" +
                        "select ParkingTransactionNumber, 0 as ManualEditId, PointsChanged, DateTimeOfEntry, DateTimeOfExit, null as ManualEditDate, ('Parking at ' + l.NameOfLocation) as Description, 'Activity' as ActivityType, a.DateTimeOfEntry as OrderColumn " +
                        "from FrequentParker08Archive.dbo.Activity a " +
                        "Inner Join FrequentParker08Archive.dbo.Location l on  a.LocationId = l.LocationId " +
                        "where MemberId = " + id + " " +
                        "Union All " +
                        "select iso.PaymentTransactionNumber, 0 as ManualEditId, Points as PointsChanged, ph.DateTimeOfEntry, ph.DateTimeOfExit, null as ManualEditDate, ('Parking at ' + l.NameOfLocation) as Description, 'ISO' as ActivityType, ph.DateTimeOfEntry as OrderColumn " +
                        "from FrequentParker08Archive.dbo.ISODiscountTransactions iso " +
                        "Inner Join FrequentParker08Archive.dbo.Location l on  iso.LocationId = l.LocationId " +
                        "Inner Join FrequentParker08Archive.dbo.ParkingPaymentTransactions ppt on iso.PaymentTransactionNumber = ppt.PaymentTransactionNumber " +
                        "Inner Join FrequentParker08Archive.dbo.ParHistory ph on ppt.ParkingTransactionNumber = ph.ParkingTransactionNumber " +
                        "where MemberId = " + id + " " +
                        "Union All " +
                        "select me.ParkingTransactionNumber, ManualEditId, PointsChanged, ph.DateTimeOfEntry, ph.DateTimeOfExit, ManualEditDate, met.Explanation as Description, 'Manual Edit' as ActivityType, me.ManualEditDate as OrderColumn " +
                        "from FrequentParker08Archive.dbo.ManualEdits me " +
                        "Left Outer Join FrequentParker08Archive.dbo.ParHistory ph on me.ParkingTransactionNumber = ph.ParkingTransactionNumber " +
                        "Inner Join FrequentParker08Archive.dbo.ManualEditTypes met on me.ExplanationId = met.ExplanationID " +
                        "where MemberId = " + id + ") archive " +
                        "order by OrderColumn desc";

                List<ArchiveActivity> list = new List<ArchiveActivity>();

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
