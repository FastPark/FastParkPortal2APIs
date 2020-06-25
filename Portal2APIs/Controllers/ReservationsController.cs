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
    public class ReservationsController : ApiController
    {
        [HttpGet]
        [Route("api/Reservations/GetReservation/{id}")]
        public List<Reservation> Search(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {

                strSQL = "select r.ReservationId, r.ReservationNumber, l.ShortLocationName, r.StartDatetime, r.EndDatetime, r.CanceledDate, mi.FirstName, mi.LastName, mi.MemberId, mc.FPNumber, r.EstimatedCost, mi.EmailAddress " +
                        "from Reservations r " +
                        "Left Outer Join MemberInformationMain mi on r.MemberId = mi.MemberId " +
                        "Left Outer Join MemberCard mc on mi.MemberId = mc.MemberId " +
                        "Inner Join LocationDetails l on r.LocationId = l.LocationId " +
                        "Where r.ReservationNumber = '" + id + "' " +
                        "and isnull(mc.IsPrimary, 1) = 1";

                List<Reservation> list = new List<Reservation>();
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

        [HttpGet]
        [Route("api/Reservations/GetReservationByMemberId/{id}")]
        public List<Reservation> GetReservationByMemberId(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {

                strSQL = "select r.ReservationId, r.ReservationNumber, l.ShortLocationName, r.StartDatetime, r.EndDatetime, r.CreateDatetime, r.CanceledDate, mi.FirstName, mi.LastName, mi.MemberId, mc.FPNumber, r.EstimatedCost, rs.ReservationStatusName, b.BrandName, r.MemberNote " +
                        "from Reservations r " +
                        "Left Outer Join MemberInformationMain mi on r.MemberId = mi.MemberId " +
                        "Left Outer Join MemberCard mc on mi.MemberId = mc.MemberId " +
                        "Inner Join LocationDetails l on r.LocationId = l.LocationId " +
                        "Inner Join ReservationStatus rs on r.ReservationStatusId = rs.ReservationStatusId " +
                        "Inner Join Brands b on l.BrandId = b.BrandId " +
                        "Where r.MemberId = '" + id + "' " +
                        "and isnull(mc.IsPrimary, 1) = 1 " +
                        "Order By r.StartDatetime desc";

                List<Reservation> list = new List<Reservation>();
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

        [HttpGet]
        [Route("api/Reservations/GetReservationIncomingDate/{id}")]
        public List<Reservation> GetReservationIncomingDate(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            string[] thisValues = id.Split('_');

            string thisDate = thisValues[0].Replace('A', '/');

            try
            {

                //strSQL = "select r.ReservationId, r.ReservationNumber, r.StartDatetime, r.EndDatetime, mi.FirstName, mi.LastName, mi.MemberId, mc.FPNumber, mi.IsGuest " +
                //        "from Reservations r " +
                //        "Left Outer Join MemberInformationMain mi on r.MemberId = mi.MemberId " +
                //        "Left Outer Join MemberCard mc on mi.MemberId = mc.MemberId " +
                //        "Inner Join LocationDetails l on r.LocationId = l.LocationId " +
                //        "Where r.StartDateTime between '" + thisDate + " 00:00:00' and '" + thisDate + " 23:59:59' " +
                //        "and r.LocationId = " + thisValues[1] + " " +
                //        "and Isnull(mc.IsPrimary, 1) = 1 " +
                //        "and r.CanceledDate is null " +
                //        "order by r.StartDatetime";

                strSQL = "select r.ReservationId, r.ReservationNumber, r.StartDatetime, r.EndDatetime, mi.FirstName, mi.LastName, mi.MemberId, mc.FPNumber, mi.IsGuest, case when IsNull(rf.ReservationId, 0) = 0 then 0 else 1 end as Options, rs.ReservationStatusName, r.UpdateExternalUserData, mi.EmailAddress " +
                        "from Reservations r " +
                        "Left Outer Join ReservationFeatures rf on r.ReservationId = rf.ReservationId " +
                        "Left Outer Join MemberInformationMain mi on r.MemberId = mi.MemberId " +
                        "Left Outer Join MemberCard mc on mi.MemberId = mc.MemberId " +
                        "Inner Join LocationDetails l on r.LocationId = l.LocationId " +
                        "Inner Join reservationStatus rs on r.ReservationStatusID = rs.ReservationStatusID " +
                        "Where r.StartDateTime between '" + thisDate + " 00:00:00' and '" + thisDate + " 23:59:59' " +
                        "and r.LocationId = " + thisValues[1] + " " +
                        "and Isnull(mc.IsPrimary, 1) = 1 " +
                        "and r.CanceledDate is null " +
                        "order by r.StartDatetime";

                List<Reservation> list = new List<Reservation>();
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

        [HttpGet]
        [Route("api/Reservations/GetReservationOutGoingDate/{id}")]
        public List<Reservation> GetReservationOutGoingDate(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            string[] thisValues = id.Split('_');

            string thisDate = thisValues[0].Replace('A', '/');

            try
            {

                strSQL = "select r.ReservationId, r.ReservationNumber, r.StartDatetime, r.EndDatetime, mi.FirstName, mi.LastName, mi.MemberId, mc.FPNumber, mi.IsGuest, rs.ReservationStatusName, r.UpdateExternalUserData, mi.EmailAddress " +
                        "from Reservations r " +
                        "Left Outer Join MemberInformationMain mi on r.MemberId = mi.MemberId " +
                        "Left Outer Join MemberCard mc on mi.MemberId = mc.MemberId " +
                        "Inner Join LocationDetails l on r.LocationId = l.LocationId " +
                        "Inner Join reservationStatus rs on r.ReservationStatusID = rs.ReservationStatusID " +
                        "Where r.EndDatetime between '" + thisDate + " 00:00:00' and '" + thisDate + " 23:59:59' " +
                        "and r.LocationId = " + thisValues[1] + " " +
                        "and Isnull(mc.IsPrimary, 1) = 1 " +
                        "and r.CanceledDate is null " +
                        "order by r.StartDatetime";

                List<Reservation> list = new List<Reservation>();
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

        [HttpGet]
        [Route("api/Reservations/CompleteReservation/{id}")]
        public string CompleteReservation(string id)
        {
            string strSQL = "";

            string[] Ids = id.Split('_');

            clsADO thisADO = new clsADO();

            try
            {

                strSQL = "Update Reservations set ReservationStatusId = 3, UpdateExternalUserData = '" + Ids[1] + "' where ReservationId = " + Ids[0];
                
                thisADO.updateOrInsert(strSQL, true);

                return "Success";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
