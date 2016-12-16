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
    public class MembersController : ApiController
    {
        [HttpPost]
        [Route("api/Members/Search")]
        public List<Member> Search(Member thisMember)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            var thisWhere = " where(mc.IsPrimary = 1 or mc.IsPrimary = 0)";

            if (thisMember.FPNumber != null)
            {
                thisWhere = thisWhere + " and mc.FPNumber = '" + thisMember.FPNumber + "'";
            }

            if (thisMember.FirstName != null) {

                thisWhere = thisWhere + " and mi.FirstName like '" + thisMember.FirstName + "%'";
            }

            if (thisMember.LastName != null)
            {
                
                thisWhere = thisWhere + " and mi.LastName like '" + thisMember.LastName + "%'";
            }

            if (thisMember.EmailAddress != null)
            {
                thisWhere = thisWhere + " and mi.EmailAddress Like '%" + thisMember.EmailAddress + "%'";
            }

            if (thisMember.HomePhone != null)
            {
                thisWhere = thisWhere + " and mi.HomePhone = '" + thisMember.HomePhone + "'";
            }

            if (thisMember.Company != null)
            {
                thisWhere = thisWhere + " and mi.Company = '" + thisMember.Company + "'";
            }

            if (thisMember.MailerCompany != null)
            {
                thisWhere = thisWhere + " and c.name = '" + thisMember.MailerCompany + "'";
            }

            if (thisMember.MarketingCode != null)
            {
                thisWhere = thisWhere + " and mi.MarketingCode = '" + thisMember.MarketingCode + "'";
            }

            if (thisMember.UserName != null)
            {
                thisWhere = thisWhere + " and mi.UserName = '" + thisMember.UserName + "'";
            }

            try
            {
                if (thisWhere != " where mc.IsPrimary = 1")
                {
                    strSQL = "Select mi.MemberId, mc.FPNumber, mi.FirstName, mi.LastName, mi.EmailAddress, mi.HomePhone, mi.Company, mi.MarketingCode, mi.UserName, l.NameOfLocation as Home " +
                             "from dbo.MemberInformationMain mi " +
                             "Inner Join MemberCard mc on mi.MemberId = mc.MemberId " +
                             "Inner Join MemberHasLocation mhl on mi.MemberId = mhl.MemberId " +
                             "Inner Join LocationDetails l on mhl.LocationId = l.LocationId " +
                             "left outer join marketingflyer.dbo.companies c on mi.companyId = c.id " +
                             thisWhere;
                    List<Member> list = new List<Member>();
                    thisADO.returnSingleValue(strSQL, true, ref list);

                    return list;
                }else
                {
                    return null;
                }
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
        [Route("api/Members/DeleteEmail/{id}")]
        public string Get(int id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Update MemberInformationMain set EmailAddress = '', EmailStatus = 0 where MemberId = " + id + "";

                thisADO.updateOrInsert(strSQL, true);

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
