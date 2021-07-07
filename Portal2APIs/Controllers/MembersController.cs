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

            //var thisWhere = " where (mc.IsPrimary = 1 or mc.IsPrimary = 0)";
            var thisWhere = " where (mc.IsDeleted = 0 or mc.IsPrimary = 1 or mc.IsPrimary = 0 or mc.IsPrimary is null)";

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
                thisWhere = thisWhere + " and mi.EmailAddress Like '" + thisMember.EmailAddress + "%'";
            }

            //if (thisMember.HomePhone != null)
            //{
            //    thisWhere = thisWhere + " and Replace(mi.HomePhone, '-', '') like '%" + thisMember.HomePhone + "%'";
            //}

            if (thisMember.Company != null)
            {
                thisWhere = thisWhere + " and mi.Company like '" + thisMember.Company + "%'";
            }

            if (thisMember.MailerCompany != null)
            {
                thisWhere = thisWhere + " and mi.CompanyId = '" + thisMember.MailerCompany + "'";
            }

            if (thisMember.MarketingCode != null)
            {
                thisWhere = thisWhere + " and mi.MarketingMailerCode = '" + thisMember.MarketingCode + "'";
            }

            if (thisMember.UserName != null)
            {
                thisWhere = thisWhere + " and mi.UserName like '" + thisMember.UserName + "%'";
            }

            try
            {
                //if (thisWhere != " where (mc.IsPrimary = 1 or mc.IsPrimary = 0)" || thisMember.HomePhone != null)
                if (thisWhere != " where (mc.IsDeleted = 0 or mc.IsPrimary = 1 or mc.IsPrimary = 0 or mc.IsPrimary is null)" || thisMember.HomePhone != null)
                {
                    if (thisMember.HomePhone != null)
                    {
                        strSQL = "Select mi.MemberId, mcPrimary.FPNumber, mi.FirstName, mi.LastName, mi.EmailAddress, mi.HomePhone, mi.Company, mi.CompanyId, mi.MarketingCode, mi.UserName, l.ShortLocationName as Home, mi.UserName, mi.CompanyId, mi.CityName as City, mi.StreetAddress " +
                             "from dbo.MemberInformationMain mi " +
                             //"Inner Join MemberCard mc on mi.MemberId = mc.MemberId " +
                             "Left Outer Join MemberCard mc on mi.MemberId = mc.MemberId " +
                             "Left Outer Join (Select MemberId, FPNumber from MemberCard Where IsPrimary = 1)  mcPrimary on mi.MemberId = mcPrimary.MemberId " +
                             "Inner Join MemberHasLocation mhl on mi.MemberId = mhl.MemberId " +
                             "Inner Join LocationDetails l on mhl.LocationId = l.LocationId " +
                             "Inner Join MemberPhone mp on mi.MemberId = mp.MemberId and Replace(mp.Number, '-', '') like '%" + thisMember.HomePhone + "%' " +
                             "left outer join marketingflyer.dbo.companies c on mi.companyId = c.id " +
                             thisWhere +
                             " and mhl.UpdateDatetime is null " +
                             " and mi.IsDeleted = 0 " +
                             //" order by mi.LastName, mi.FirstName, mc.IsPrimary desc, mi.memberid ";
                             " order by l.ShortLocationName, mi.LastName, mi.FirstName, mcPrimary.FPNumber ";

                    }
                    else
                    {
                        strSQL = "Select mi.MemberId, mcPrimary.FPNumber, mi.FirstName, mi.LastName, mi.EmailAddress, mi.HomePhone, mi.Company, mi.CompanyId, mi.MarketingCode, mi.UserName, l.ShortLocationName as Home, mi.UserName, mi.CompanyId, mi.CityName as City, mi.StreetAddress " +
                             "from dbo.MemberInformationMain mi " +
                             //"Inner Join MemberCard mc on mi.MemberId = mc.MemberId " +
                             "Left Outer Join MemberCard mc on mi.MemberId = mc.MemberId " +
                             "Left Outer Join (Select MemberId, FPNumber from MemberCard Where IsPrimary = 1)  mcPrimary on mi.MemberId = mcPrimary.MemberId " +
                             "Inner Join MemberHasLocation mhl on mi.MemberId = mhl.MemberId " +
                             "Inner Join LocationDetails l on mhl.LocationId = l.LocationId " +
                             "left outer join marketingflyer.dbo.companies c on mi.companyId = c.id " +
                             thisWhere +
                             " and mhl.UpdateDatetime is null " +
                             " and mi.IsDeleted = 0 " +
                             //" order by mi.LastName, mi.FirstName, mc.IsPrimary desc, mi.memberid ";
                             " order by l.ShortLocationName, mi.LastName, mi.FirstName, mcPrimary.FPNumber ";

                    }

                    List<Member> list = new List<Member>();
                    thisADO.returnSingleValue(strSQL, true, ref list);

                    return list;

                }
                else
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

        [HttpPost]
        [Route("api/Members/SearchByCompanyLocation")]
        public List<Member> SearchByCompanyLocation(Member thisMember)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            var thisWhere = " where (mc.IsPrimary = 1 or mc.IsPrimary = 0)";

            if (thisMember.Company != null)
            {
                thisWhere = thisWhere + " and mi.Company like '%" + thisMember.Company + "%'";
            }

            if (thisMember.LocationId != 0)
            {
                thisWhere = thisWhere + " and mhl.LocationId = " + thisMember.LocationId;
            }

            try
            {
                if (thisWhere != " where (mc.IsPrimary = 1 or mc.IsPrimary = 0)")
                {
                    strSQL = "Select mi.MemberId, mc.FPNumber, mi.FirstName, mi.LastName, mi.EmailAddress, mi.HomePhone, mi.Company, mi.CompanyId, mi.MarketingCode, mi.UserName, l.NameOfLocation as Home " +
                             "from dbo.MemberInformationMain mi " +
                             "Inner Join MemberCard mc on mi.MemberId = mc.MemberId " +
                             "Inner Join MemberHasLocation mhl on mi.MemberId = mhl.MemberId " +
                             "Inner Join LocationDetails l on mhl.LocationId = l.LocationId " +
                             "left outer join marketingflyer.dbo.companies c on mi.companyId = c.id " +
                             thisWhere +
                             " order by mc.IsPrimary desc";
                    List<Member> list = new List<Member>();
                    thisADO.returnSingleValue(strSQL, true, ref list);

                    return list;
                }
                else
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
        [Route("api/Members/GetMemberNameByCard/{id}")]
        public List<Member> GetMemberNameByCard(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select mi.FirstName, mi.LastName from MemberInformationMain mi " +
                         "Inner Join MemberCard mc on mi.MemberId = mc.MemberId " +
                         "Where mc.FPNumber = '" + id + "'";

                List<Member> list = new List<Member>();
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
