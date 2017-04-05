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
    public class AuditsController : ApiController
    {
        [HttpGet]
        [Route("api/Audits/GetAudits/{id}")]
        public List<Audit> AuditsByMemberId(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select MemberId, FirstName, LastName, DataChanged, OldValue, NewValue, ChangeType, changeUser, changeDate from (" +
                        "select mi.MemberId as MemberId, mi.FirstName, mi.LastName, DataChanged as DataChanged, OldValue, NewValue, Case When al.CreateUserId = al.MemberId then 'USER' Else 'AWS' End as ChangeType, Cast(al.CreateUserId as  nvarchar(25)) as changeUser,  dateAdd(Hour,-5,al.CreateDatetime) as  changeDate, dateAdd(Hour,-5,al.CreateDatetime) as orderColumn " +
                        "from AuditLog al " +
                        "Inner Join MemberInformationMain mi on al.MemberId = mi.MemberId " +
                        "where al.MemberId = " + id + " " +
                        "Union All " +
                        "select cl.changeID as MemberId, mi.FirstName, mi.LastName, ChangeNote as DataChanged, ChangeValOld as OldValue, changeValNew as NewValue, 'Portal' as ChangeType, changeUser, changeDate, changeDate as orderColumn " +
                        "from changelog cl " +
                        "Left Outer Join MemberInformationMain mi on cl.ChangeId = mi.memberId " +
                        "where cl.ChangeId = " + id + ") audits " +
                        "order by orderColumn desc";

                List<Audit> list = new List<Audit>();

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
