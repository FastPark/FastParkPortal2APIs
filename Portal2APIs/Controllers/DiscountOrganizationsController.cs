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
    public class DiscountOrganizationsController : ApiController
    {
        [HttpGet]
        [Route("api/DiscountOrganizations/GetDiscountOrganizations/")]
        public List<DiscountOrganization> GetDiscountOrganizations()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select  do.DiscountOrganizationId, do.DiscountOrganizationName " +
                         "from DiscountOrganization do Inner Join DiscountOrganizationHasLocation dohl on do.DiscountOrganizationId = dohl.DiscountOrganizationId  ";

                List<DiscountOrganization> list = new List<DiscountOrganization>();
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
        [Route("api/DiscountOrganizations/GetMemberDO/{id}")]
        public List<DiscountOrganization> GetMemberDO(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select top 1 do.DiscountOrganizationName, dohl.RateCode, mhdo.ExpiresDatetime, mhdo.MembershipNumber, mhdo.EffectiveDatetime, do.DiscountOrganizationId, mhdo.MemberDiscountOrganizationId " +
                        "from MemberHasDiscountOrganization mhdo " +
                        "Inner Join DiscountOrganization do on mhdo.DiscountOrganizationId = do.DiscountOrganizationId " +
                        "Inner Join DiscountOrganizationHasLocation dohl on mhdo.DiscountOrganizationId = dohl.DiscountOrganizationId " +
                        "where mhdo.MemberId = " + id + " " +
                        "and mhdo.IsDeleted = 0";

                List<DiscountOrganization> list = new List<DiscountOrganization>();
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
        [Route("api/DiscountOrganizations/SearchDONumber/{id}")]
        public List<DiscountOrganization> SearchDONumber(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select mi.FirstName + ' ' + mi.LastName as MemberName, mi.EmailAddress as MemberEmail, mhdo.CreateDatetime, mc.FPNumber as MemberCard, mhdo.ExpiresDatetime  " +
                        "from MemberInformationMain mi " +
                        "Inner Join MemberHasDiscountOrganization mhdo on mi.MemberId = mhdo.MemberId " +
                        "Inner Join MemberCard mc on mi.MemberId = mc.MemberId " +
                        "Where mhdo.IsDeleted = 0 " +
                        "And mc.IsPrimary = 1 " +
                        "And mhdo.MembershipNumber = '" + id + "' ";

                List<DiscountOrganization> list = new List<DiscountOrganization>();
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
