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

                strSQL = "select r.RedemptionId, r.CertificateId, r.RedeemDate, r.DateUsed, rt.RedemptionTypeName, r.IsReturned, IsNull(r.IsExpired, 0) as IsExpired, r.BeenUsed, rs.RedemptionSourceName, CancellationRequestedDatetime as [ReturnRequest], CancellationRequestProcessedDatetime as ReturnProcessed " +
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

        [HttpGet]
        [Route("api/Redemptions/ReturnExpiredRedemption/{id}")]
        public string ReturnExpiredRedemption(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();
            //Get performed by name from string Id
            var thisData = id.Split('~');

            var certId = thisData[0];
            var performedBy = thisData[1];

            try
            {
                //Check to see if certificate is expired return MemberID if so
                strSQL = "Select MemberId " +
                        "from Redemptions " +
                        "WHERE IsExpired = 1 " +
                        "And CertificateId = '" + certId + "' ";

                var exp = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                //Check to see if certificate has been returned. if not return MemberID
                strSQL = "Select MemberId " +
                        "from Redemptions " +
                        "WHERE CancellationRequestedDatetime is null " +
                        "And CertificateId = '" + certId + "' ";

                var cancel = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                //if exp does not have memberId then return cert is not expired
                if (exp == null)
                {
                    return "Certificate is not expired";
                }

                //if cancel does not have memberId then cert already returned.
                if (cancel == null)
                {
                    return "Certificate has already been returned";
                }

                //Update cancel dates on redemption
                strSQL = "Update Redemptions " +
                        "Set CancellationRequestedDatetime = getDate(), CancellationRequestProcessedDatetime = getDate(), IsReturned = 1 " +
                        "OUTPUT INSERTED.RedemptionId " +
                        "WHERE CertificateId = '" + certId + "' ";

                //this will return the redemptionID if successful
                var RedemptionId = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                //If redemptionId is there we need to create a manual edit returning points
                if (RedemptionId != "")
                {
                    //use manualedit api to cretat manual edit
                    var newManualEditInsert = new ManualEditsController();
                    var newManualEdit = new ManualEdit();

                    newManualEdit.CertificateNumber = certId;
                    newManualEdit.MemberId = Convert.ToInt64(exp);
                    //get points and location from original manual edit entry
                    var newRedeptionPoints = new RedemptionsController();
                    var PointsAndLoc = newRedeptionPoints.GetRedemptionPointsAndLocation(RedemptionId);

                    var PointsAndLocArray = PointsAndLoc.Split('~');

                    var points = PointsAndLocArray[0];
                    var loc = PointsAndLocArray[1];

                    //multiply times -1 to make positive
                    newManualEdit.PointsChanged = Convert.ToInt32(points) * -1;
                    newManualEdit.ManualEditDate = DateTime.Now;
                    newManualEdit.Notes = "Returned expired redemption " + certId;
                    newManualEdit.UpdateExternalUserData = performedBy;
                    newManualEdit.LocationId = Convert.ToInt32(loc);
                    newManualEdit.ExplanationId = 53;
                    
                    newManualEditInsert.AddManualEditDirectly(newManualEdit);
                    
                    return "Succes";
                }
                else
                {
                    return "There was an issue updating the return dates. Please contact IT with the Certificate ID.";
                }

            }
            catch (Exception ex)
            {
                return "There was an error.  Please contact IT with the Certificate ID.";
            }
        }

        [HttpGet]
        [Route("api/Redemptions/GetRedemptionPointsAndLocation/{id}")]
        public string GetRedemptionPointsAndLocation(string id)
        {
            string strSQL = "";
            clsADO thisADO = new clsADO();

            try
            {

                strSQL = "Select Cast(PointsChanged as nvarchar) + '~' + Cast(LocationId as nvarchar) as PointsChanged from manualEdits where RedemptionId = " + id;

                var Points = thisADO.returnSingleValueForInternalAPIUse(strSQL, true);

                return Points;

            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}

