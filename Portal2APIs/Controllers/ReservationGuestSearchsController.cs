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
    public class ReservationGuestSearchsController : ApiController
    {
        [HttpGet()]
        [Route("api/ReservationGuestSearch/GetGuestsByEmail/{id}")]
        public List<ReservationGuestSearch> GetGuestsByEmail(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            id = id.Replace('~', '.');
            id = id.Replace('`', '@');

            string[] emailParts = id.Split('@');

            try
            {
                strSQL = "Select MemberId, FirstName, LastName, EmailAddress, CreateDatetime " +
                         "from MemberInformationMain mi " +
                         "where mi.IsGuest = 1 " +
                         "and mi.EmailAddress like '" + emailParts[0] + "%' " +
                         "and mi.emailAddress like '%" + emailParts[1] + "' " +
                         "order by CreateDatetime desc";

                List<ReservationGuestSearch> list = new List<ReservationGuestSearch>();
                thisADO.returnSingleValue(strSQL, true, ref list);

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
