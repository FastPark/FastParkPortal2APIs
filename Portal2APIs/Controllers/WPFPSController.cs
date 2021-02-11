using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Controllers;
using Portal2APIs.Common;
using Portal2APIs.Models;

namespace Portal2APIs.Controllers
{
    public class WPFPSController : ApiController
    {
        [HttpGet()]
        [Route("api/WPFPS/GETFP/")]
        public List<FP> GETFP()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select FPID, FirstName, LastName, WPFPNumber, WPPoints, RFRPoints from WP.dbo.FP Where Deleted is NULL";
                List<FP> list = new List<FP>();

                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpGet()]
        [Route("api/WPFPS/GETOL/")]
        public List<OL> GETOL()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select OLID, FirstName, LastName, OLCardNumber, OLPoints, RFRPoints from WP.dbo.OL Where Deleted is NULLL";
                List<OL> list = new List<OL>();

                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpGet()]
        [Route("api/WPFPS/GetSignUpNoMatch/")]
        public List<SignUpNoMatch> GetSignUpNoMatch()
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Select SignUpNoMatchID, mi.FirstName, mi.LastName, mc.FPNumber, mi.EmailAddress, sunm.MatchCheckDate, sunm.MailerCodeUsed " +
                            "from WP.dbo.SignUpNoMatch sunm " +
                            "Inner Join MemberInformationMain mi on sunm.RFRMemberId = mi.MemberId " +
                            "Inner Join MemberCard mc on sunm.RFRMemberId = mc.MemberId " +
                            "Where mc.IsPrimary = 1 " +
                            "And sunm.Finished = 0";
                List<SignUpNoMatch> list = new List<SignUpNoMatch>();

                thisADO.returnSingleValue(strSQL, false, ref list);

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

        [HttpPut()]
        [Route("api/WPFPS/SetSignUpNoMatchFinished/{id}")]
        public string SetSignUpNoMatchFinished(string Id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Update WP.dbo.SignUpNoMatch Set Finished = 1 Where SignUpNoMatchID = " + Id;

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
