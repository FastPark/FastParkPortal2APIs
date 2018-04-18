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
    public class MemberThankYousController : ApiController
    {
        [HttpGet]
        [Route("api/MemberThankYous/GetMemberThankYou/{id}")]
        public List<MemberThankYou> GetCardDist(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select MemberThankYouId, MemberThankYouUserId, MemberThankYouMemberId, MemberThankYouDate from MemberThankYou where MemberThankYouMemberId = " + id;
                List<MemberThankYou> list = new List<MemberThankYou>();
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
        [Route("api/MemberThankYous/PostMemberThankYou")]
        public string Distribute(MemberThankYou mty)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "insert into MemberThankYou (MemberThankYouUserId, MemberThankYouMemberId, MemberThankYouDate) " +
                                             "values ('" + mty.MemberThankYouUserId + "', " + mty.MemberThankYouMemberId + ", GetDate())";

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
