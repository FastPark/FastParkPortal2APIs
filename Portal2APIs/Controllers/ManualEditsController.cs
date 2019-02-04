using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Common;
using System.Data.SqlClient;
using Portal2APIs.Models;

namespace Portal2APIs.Controllers
{
    public class ManualEditsController : ApiController
    {
        [HttpGet]
        [Route("api/ManualEdits/ManualEditById/{id}")]
        public List<ManualEdit> ManualEditById(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select met.Explanation, isnull(me.UpdateExternalUserData, '') as UpdateExternalUserData, isnull(mi.FirstName + ' ' + mi.LastName, '') as Name, me.* " +
                         "from dbo.ManualEdits me " +
                         "Left Outer Join ManualEditTypes met on me.ExplanationId = met.ExplanationId " +
                         "Left Outer Join MemberInformationMain mi on me.CreateUserId = mi.MemberId  and me.CreateUserId <> -1 and me.CreateUserId <> 1 " +
                         "where ManualEditID = " + id;

                List<ManualEdit> list = new List<ManualEdit>();
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
        [Route("api/ManualEdits/ManualEditByMemberId/{id}")]
        public List<ManualEdit> ManualEditByMemberId(int id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select * from dbo.ManualEdits where MemberId=" + id + "";
                List<ManualEdit> list = new List<ManualEdit>();
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

        [HttpPost]
        [Route("api/ManualEdits/Post/")]
        public HttpResponseMessage Post(ManualEdit man)
        {
            Console.Write(man.MemberId);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            return response;
        }


        [HttpPost]
        [Route("api/ManualEdits/AddManualEdit/")]
        public string  AddManualEdit(ManualEdit man)
        {
            try
            {
                string strSQL;
                clsADO thisADO = new clsADO();

                strSQL = "INSERT INTO ManualEditHoldingArea " +
                         "(Points, LocationId, MemberID, DateOfRequest, CertificateNumber, ExplanationID, Delivery, Notes, UpdateExternalUserData, CompanyId, CreateUserId, CreateDatetime) " +
                         "VALUES (" + man.PointsChanged + ", " + man.LocationId + ", " + man.MemberId + ", '" + man.ManualEditDate + "', '" + man.CertificateNumber + 
                         "', " + man.ExplanationId + ", 0, '" + man.Notes + "', '" + man.PerformedBy + "', " + man.CompanyId + ", -1, '" + DateTime.Now + "')";


                //strSQL = "INSERT INTO dbo.ManualEdits (MemberID,LocationID,ManualEditDate,SubmittedDate,PerformedBy, " +
                //         "SubmittedBy, ExplanationID,PointsChanged,CertificateNumber,ParkingTransactionNumber,CompanyID, " +
                //         "Notes,PerformedByUserID,SubmittedByUserID) " +
                //         "Values (" + man.MemberId + ", " + man.LocationId + ", '" + man.ManualEditDate + "', '" + man.SubmittedDate + "', '" +
                //         man.PerformedBy + "', '" + man.SubmittedBy + "', " + man.ExplanationId + ", " + man.PointsChanged + ", '" +
                //         man.CertificateNumber + "', '" + man.ParkingTransactionNumber + "', " + man.CompanyId + ", '" + man.Notes + "', '" +
                //         man.PerformedByUserId + "', '" + man.SubmittedByUserId + "')";

                thisADO.updateOrInsert(strSQL, true);

                return "Success";

            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(Convert.ToString(ex), System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpPost]
        [Route("api/ManualEdits/UpdateManualEdit/")]
        public void UpdateManualEdit(ManualEdit man)
        {
            try
            {
                clsADO thisADO = new clsADO();
                string strSQL = null;

                strSQL = "Update dbo.ManualEdits set MemberID = " + man.MemberId + ", locationID = " + man.LocationId +
                        ", ManualEditDate = '" + man.ManualEditDate + "', SubmittedDate = '" + man.SubmittedDate + "', PerformedBy = " +
                        man.PerformedBy + ", SubmittedBy = " + man.SubmittedBy + ", ExplanationID = " + man.ExplanationId +
                        ", CertificateNumber = '" + man.CertificateNumber + "', ParkingTransactionNumber = '" + man.ParkingTransactionNumber +
                        "', CompanyID = " + man.CompanyId + ", Notes = '" + man.Notes + "', PointsChanged = " + man.PointsChanged +
                        " Where ManualEditID = " + man.ManualEditId;

                thisADO.updateOrInsert(strSQL, true);
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

        [HttpDelete]
        [Route("api/ManualEdits/DeleteManualEditByID/{id}")]
        public void DeleteManualEditByID(int id)
        {
            try
            {
                clsADO thisADO = new clsADO();
                string strSQL = null;

                strSQL = "delete from dbo.ManualEdits where ManualEditID=" + id;

                thisADO.updateOrInsert(strSQL, true);
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
        [Route("api/ManualEdits/GetManualEditTypes")]
        public List<ManualEditType> GetManualEditTypes()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select Explanation, ExplanationID from dbo.ManualEditTypes where (TypeStatus='All' or TypeStatus='ActivityOnly') order by Explanation";
                List<ManualEditType> list = new List<ManualEditType>();
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

