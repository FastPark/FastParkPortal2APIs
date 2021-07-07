using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Portal2APIs.Common;
using Portal2APIs.Models;

namespace Portal2APIs.Controllers
{
    public class WPFPSController : ApiController
    {
        [HttpPost()]
        [Route("api/WPFPS/GETFP")]
        public List<FP> GETFP(FP fp)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {

                if (fp.EmailAddress == null)
                {
                    strSQL = "Select FPID, FirstName, LastName, 'DU-' + WPFPNumber as WPFPNumber, WPPoints, RFRPoints, mc.FPNumber, me.ManualEditDate " +
                         "from WP.dbo.FP " +
                         "Left Outer Join (Select * From MemberCard Where IsPrimary = 1 And MemberId <> -1) mc on FP.RFRMemberId = mc.MemberId " +
                         "Left Outer Join (Select * From ManualEdits Where ExplanationId = 88) me on FP.RFRMemberId = me.MemberId And '%' + FP.WPFPNumber + '%' like me.Notes " +
                         "Where Deleted is NULL";
                }
                else
                {
                    strSQL = "Select FPID, FirstName, LastName, 'DU-' + WPFPNumber as WPFPNumber, WPPoints, RFRPoints, mc.FPNumber, me.ManualEditDate " +
                         "from WP.dbo.FP " +
                         "Left Outer Join (Select * From MemberCard Where IsPrimary = 1 And MemberId <> -1) mc on FP.RFRMemberId = mc.MemberId " +
                         "Left Outer Join (Select * From ManualEdits Where ExplanationId = 88) me on FP.RFRMemberId = me.MemberId And '%' + FP.WPFPNumber + '%' like me.Notes " +
                         "Where Deleted is NULL " +
                         "And FP.EmailAddress = '" + fp.EmailAddress + "'";
                }
                
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

        [HttpPost()]
        [Route("api/WPFPS/GETOL")]
        public List<OL> GETOL(OL ol)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                if (ol.EmailAddress == null)
                {
                    strSQL = "Select OLID, FirstName, LastName, 'OL-' + OLCardNumber as OLCardNumber, OLPoints, RFRPoints, mc.FPNumber, me.ManualEditDate " +
                         "from WP.dbo.OL " +
                         "Left Outer Join (Select * From MemberCard Where IsPrimary = 1 And MemberId <> -1) mc on OL.RFRMemberId = mc.MemberId " +
                         "Left Outer Join (Select * From ManualEdits Where ExplanationId = 92) me on OL.RFRMemberId = me.MemberId And '%' + OL.OLCardNumber + '%' like me.Notes " +
                         "Where Deleted is NULL";
                }
                else
                {
                    strSQL = "Select OLID, FirstName, LastName, 'OL-' + OLCardNumber as OLCardNumber, OLPoints, RFRPoints, mc.FPNumber, me.ManualEditDate " +
                         "from WP.dbo.OL " +
                         "Left Outer Join (Select * From MemberCard Where IsPrimary = 1 And MemberId <> -1) mc on OL.RFRMemberId = mc.MemberId " +
                         "Left Outer Join (Select * From ManualEdits Where ExplanationId = 92) me on OL.RFRMemberId = me.MemberId And '%' + OL.OLCardNumber + '%' like me.Notes " +
                         "Where Deleted is NULL " +
                         "And OL.EmailAddress = '" + ol.EmailAddress + "'";
                }
                
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
                strSQL = "Select SignUpNoMatchID, mi.FirstName, mi.LastName, mc.FPNumber, mi.EmailAddress, sunm.MatchCheckDate, sunm.MailerCodeUsed, sunm.Finished, sunm.EmailSent " +
                            "from WP.dbo.SignUpNoMatch sunm " +
                            "Inner Join MemberInformationMain mi on sunm.RFRMemberId = mi.MemberId " +
                            "Inner Join MemberCard mc on sunm.RFRMemberId = mc.MemberId " +
                            "Where mc.IsPrimary = 1 ";
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

        [HttpPost]
        [Route("api/WPFPS/SetSignUpNoMatchFinished/")]
        public void SetSignUpNoMatchFinished(SignUpNoMatch sunm)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {
                strSQL = "Update WP.dbo.SignUpNoMatch Set Finished = " + sunm.Finished + " Where SignUpNoMatchID = " + sunm.SignUpNoMatchID;

                thisADO.updateOrInsert(strSQL, false);

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
