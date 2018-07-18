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
    public class MailChimpsController : ApiController
    {
        [HttpGet]
        [Route("api/MailChimps/MailChimpCleanUp/")]
        public List<MailChimp> MailChimpCleanUp()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select mce.MemberId, mce.[First Name] as MCFirstName, mce.[Last Name] as MCLastName, mce.[Email Address] as MCEmailAddress, mce.Member# as MCFPNumber, mi.FirstName, mi.LastName, mi.EmailAddress  " +
                        "from MAILCHIMP.dbo.MAILCHIMPEXPORT mce " +
                        "Inner Join FrequentParker08.dbo.MemberInformationMain mi on mce.MemberId = mi.MemberId " +
                        "where mi.IsDeleted = 1";

                List<MailChimp> list = new List<MailChimp>();
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
