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
    public class MailerCodesController : ApiController
    {
        [HttpGet]
        [Route("api/MailerCodes/GetMailerCode/{id}")]
        public List<MailerCode> GetMailerCode(string id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "select fl.flyer_id, fl.promo_code, mr.FirstName, mr.LastName, cast(fl.rate_code as nvarchar(10)) + ' - ' + cast(cast(ra.RateAmount as float) / 100.00 as nvarchar(10)) as rate_code , fl.created_at, fl.updated_at, c.name as CompanyName, l.ShortLocationName " +
                        "from MarketingFlyer.dbo.flyer_locations fl " +
                        "Inner Join LocationDetails l on fl.location_id = l.LocationId " +
                        "Inner Join MarketingReps mr on Substring(fl.promo_code, 5, 1) = mr.RepMailerId " +
                        "Inner Join MarketingFlyer.dbo.flyers f on fl.flyer_id = f.id " +
                        "Inner Join MarketingFlyer.dbo.companies c on f.company_id = c.id " +
                        "Inner JOin RateAmounts ra on fl.rate_code = ra.RateCode and fl.Location_Id = ra.LocationId " +
                        "where fl.promo_code = '" + id + "' " +
                        "and mr.UserId <> '00000000-0000-0000-0000-000000000000' " +
                        "and ra.UpdateDatetime is null";

                List<MailerCode> list = new List<MailerCode>();

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
        [Route("api/MailerCodes/GetMailerCodeSends/{id}")]
        public List<MailerCodeSend> GetMailerCodeSends(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "select contact_email, email_subject, email_body, created_at, updated_at from MarketingFlyer.dbo.flyer_sends where flyer_id = " + id + " order by created_at desc";

                List<MailerCodeSend> list = new List<MailerCodeSend>();

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
