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
    public class RedemptionsController : ApiController
    {
        [HttpPost]
        [Route("api/Redemptions/SetBeenUsed/")]
        public String SetBeenUsed(Redemption Red)
        {
            try
            {
                clsADO thisADO = new clsADO();

                string rateSQL = "Update Redemptions set BeenUsed = 1, DateUsed = '" + DateTime.Now + "', UpdateExternalUserData = '" + Red.UpdateExternalUserData  + "' where RedemptionId = " + Red.RedemptionId;

                thisADO.updateOrInsert(rateSQL, true);

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

        [HttpGet]
        [Route("api/Redemptions/GetRedemption/{id}")]
        public List<Redemption> Search(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {

                strSQL = "select r.RedemptionId, r.CertificateId, r.RedeemDate, r.DateUsed, rt.RedemptionTypeName, r.IsReturned, mi.FirstName, mi.LastName, mi.MemberId, mi.EmailAddress " +
                        "from Redemptions r " +
                        "Left Outer Join MemberInformationMain mi on r.MemberId = mi.MemberId " +
                        "Inner Join RedemptionTypes rt on r.RedemptionTypeId = rt.RedemptionTypeId " +
                        "Where r.CertificateId = '" + id + "'";

                List<Redemption> list = new List<Redemption>();
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
        [Route("api/Redemptions/GetMemberRedemption/{id}")]
        public List<Redemption> GetMemberRedemption(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {

                strSQL = "select r.RedemptionId, r.CertificateId, r.RedeemDate, r.DateUsed, rt.RedemptionTypeName, r.IsReturned, r.BeenUsed, rs.RedemptionSourceName " +
                        "from Redemptions r " +
                        "Inner Join MemberInformationMain mi on r.MemberId = mi.MemberId " +
                        "Inner Join RedemptionTypes rt on r.RedemptionTypeId = rt.RedemptionTypeId " +
                        "Inner Join RedemptionSource rs on r.RedemptionSourceId = rs.RedemptionSourceId " +
                        "Where mi.MemberId = '" + id + "' order by RedeemDate desc";

                List<Redemption> list = new List<Redemption>();
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

