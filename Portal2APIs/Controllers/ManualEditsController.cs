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


                strSQL = "Select * from dbo.ManualEdits where ManualEditID=" + id + "";
                List<ManualEdit> list = new List<ManualEdit>();
                thisADO.returnList(strSQL, false, ref list);

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
                thisADO.returnList(strSQL, false, ref list);

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
        [Route("api/ManualEdits/AddManualEdit/")]
        public void AddManualEdit(ManualEdit man)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "INSERT INTO dbo.ManualEdits (MemberID,LocationID,ManualEditDate,SubmittedDate,PerformedBy, " +
                     "SubmittedBy, ExplanationID,PointsChanged,CertificateNumber,ParkingTransactionNumber,CompanyID, " +
                     "Notes,PerformedByUserID,SubmittedByUserID) " +
                     "Values (" + man.MemberId + ", " + man.LocationId + ", '" + man.ManualEditDate + "', '" + man.SubmittedDate + "', '" +
                     man.PerformedBy + "', '" + man.SubmittedBy + "', " + man.LocationId + ", " + man.PointsChanged + ", '" +
                     man.CertificateNumber + "', '" + man.ParkingTransactionNumber + "', " + man.CompanyId + ", '" + man.Notes + "', '" +
                     man.PerformedByUserId + "', '" + man.SubmittedByUserId + "'";

        }

        [HttpPost]
        [Route("api/ManualEdits/UpdateManualEdit/")]
        public void UpdateManualEdit(ManualEdit man)
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

        [HttpDelete]
        [Route("api/ManualEdits/DeleteManualEditByID/")]
        public void DeleteManualEditByID(int id)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            strSQL = "delete from dbo.ManualEdits where ManualEditID=" + id;

            thisADO.updateOrInsert(strSQL, true);
            
        }
    }
}

