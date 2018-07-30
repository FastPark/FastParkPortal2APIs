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
    public class ReferralsController : ApiController
    {
        [HttpGet]
        [Route("api/Referrals/GetReferrals/{id}")]
        public List<Referral> GetReferrals(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select mi.MemberId, r.ReferralId, rt.ReferralTypeName, r.SentToEmail, r.CreateDatetime As RefferedDate, mi.MemberSince as SignedDate, mi.ReferralPointsAwarded, DATEADD(DAY, -1, mi.ReferralCompleteDate) " +
                        "from referral r " +
                        "Inner Join ReferralType rt on r.ReferralTypeId = rt.ReferralTypeId " +
                        "Left Outer Join MemberInformationMain mi on r.ReferralId = mi.ReferralId " +
                        "where r.MemberId = " + id + " " +
                        "order by r.CreateDatetime desc";

                List<Referral> list = new List<Referral>();
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
