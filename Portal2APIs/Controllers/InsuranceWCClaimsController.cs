using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Common;
using Portal2APIs.Models;
using System.Net.Http.Headers;

namespace Portal2APIs.Controllers
{
    public class InsuranceWCClaimsController : ApiController
    {
        [HttpPost]
        [Route("api/InsuranceWCClaims/SearchWCClaimsList/")]
        public List<InsuranceWCClaim> SearchIncidentList(InsuranceWCClaim I)
        {
            var thisWhere = " where (1 = 1)";

            if (I.WCClaimNumber != null)
            {
                thisWhere = thisWhere + " and wcc.WCClaimNumber = '" + I.WCClaimNumber + "'";
            }

            if (I.IncidentNumber != null)
            {

                thisWhere = thisWhere + " and i.IncidentNumber = '" + I.IncidentNumber + "'";
            }

            if (I.WCIncidentDate.ToString() != "1/1/0001 12:00:00 AM")
            {

                thisWhere = thisWhere + " and wcc.WCIncidentDate = '" + I.WCIncidentDate + "'";
            }

            if (I.Closed != 0)
            {
                thisWhere = thisWhere + " and wcc.Closed = " + I.Closed;
            }

            if (I.WCClaimStatusID != 0)
            {
                thisWhere = thisWhere + " wcc.WCClaimStatusID = " + I.WCClaimStatusID;
            }

            if (I.LocationID != 0)
            {
                thisWhere = thisWhere + " and wcc.LocationID = " + I.LocationID;
            }

            if (I.ClaimantName != null)
            {
                thisWhere = thisWhere + " and wcc.ClaimantName = '" + I.ClaimantName + "'";
            }

            string[] results = I.ViewSettings.Split(',');
            if (results.Length > 1)
            {
                thisWhere = thisWhere + " And wcc.LocationId in (" + I.ViewSettings + ") ";
            }
            else
            {
                thisWhere = thisWhere + " And wcc.WCClaimCreatedBy = '" + results[1].ToString() + "'  " +
                            "And wcc.LocationId in (" + results[0].ToString() + ") ";
            }

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select WCClaimID, WCClaimNumber, " +
                        "'01' as Number, " +
                        "i.IncidentNumber + '-' + c.ClaimNumber as CompanionIncident, " +
                        "i.IncidentNumber, " +
                        "wcc.WCIncidentDate, " +
                        "wcc.Closed, " +
                        "wcc.PCAInsuranceNumber, " +
                        "wcs.WCStatus, " +
                        "l.LocationName + '-' + l.LocationGLCode as LocationName, " +
                        "wcc.ClaimantName " +
                        "from InsurancePCA.dbo.WCClaim wcc " +
                        "Left Outer Join InsurancePCA.dbo.WCInvestigation wci on wcc.WCInvestigtionID = wci.WCInvestigationID " +
                        "Left Outer Join InsurancePCA.dbo.Claim c on wci.ClaimID = c.ClaimID " +
                        "Left Outer Join InsurancePCA.dbo.Incident i on c.IncidentID = i.IncidentID " +
                        "Left Outer Join InsurancePCA.dbo.WCStatus wcs on wcc.WCClaimStatusID = wcs.WCStatusid " +
                        "Left Outer Join InsurancePCA.dbo.Location l on wcc.locationId = l.LocationID " +
                        thisWhere;


                List<InsuranceWCClaim> list = new List<InsuranceWCClaim>();


                thisADO.returnSingleValue(strSQL, false, ref list);

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
        [Route("api/InsuranceWCClaims/GetWCClaimByWCInvestigationID/{Id}")]
        public List<InsuranceWCClaim> GetWCClaimByID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();
                
                strSQL = "SELECT wcc.WCClaimID ,wcc.WCClaimNumber ,wcc.WCInvestigationID ,wcc.WCIncidentDate ,wcc.ReportedToCarrierDate , " +
                            "wcc.PolicyTypeID ,wcc.PCAInsuranceNumber ,wcc.WCClaimStatusID ,wcc.WCClaimStatusDate ,wcc.OSHALog ,wcc.DaysMissed , " +
                            "wcc.NumberOfDaysMissed ,wcc.LiteRelease ,wcc.NumberOfLiteDutyDays ,wcc.FullReleaseDate ,wcc.ReturnedToWorkDate , " +
                            "wcc.FollowUpApptDate ,wcc.ImpairmentRating ,wcc.Subro ,wcc.JobClass ,wcc.RepFollowUpDate ,wcc.ModifiedDutyRequired , " +
                            "wcc.IndemnityCompPaid ,wcc.IndemnityCompReserve ,wcc.MedicalPaid ,wcc.MedicalReserve ,wcc.WCClaimExpensePaid , " +
                            "wcc.WCExpenseReserve ,wcc.SubroAmount ,wcc.Settlement ,wcc.PoliceReportNumber ,wcc.PCAReceivedClaimDate , " +
                            "wcc.PCARepID , i.IncidentNumber, wcc.ClaimantName, wcc.LocationID, wcc.Closed  " +
                            "FROM InsurancePCA.dbo.WCClaim wcc  " +
                            "Left Outer Join InsurancePCA.dbo.WCInvestigation wci on wcc.WCInvestigationID = wci.WCInvestigationID " +
                            "Left Outer Join InsurancePCA.dbo.Claim c on wci.ClaimId = c.ClaimID  " +
                            "Left Outer Join InsurancePCA.dbo.Incident i on c.IncidentID = i.IncidentID  " +
                            "Left Outer Join InsurancePCA.dbo.IncidentPCAVehicle ipv on c.ClaimID = ipv.ClaimID " +
                            "Where wcc.WCInvestigationID = " + Id;

                List<InsuranceWCClaim> list = new List<InsuranceWCClaim>();

                thisADO.returnSingleValue(strSQL, false, ref list);

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
        [Route("api/InsuranceWCClaims/PostWCClaim")]
        public string PostWCClaim(InsuranceWCClaim I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;
            try
            {
                strSQL = "Select Max(WCClaimNumber) + 1 from InsurancePCA.dbo.WCClaim";

                string thisWCClaimNumber = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                strSQL = "Insert INTO InsurancePCA.dbo.WCClaim (ClaimID, WCCLaimNumber, PoliceReportNumber, PCAReceivedClaimDate, LocationID, ClaimantName, WCIncidentDate) " +
                         "VALUES (" + I.ClaimID + ", '" + thisWCClaimNumber + "', '" + I.PoliceReportNumber + "', '" + I.PCAReceivedClaimDate + "', " + I.LocationID + ", '" + I.ClaimantName + "', '" + I.WCIncidentDate + "')";

                var WCClaimID = thisADO.updateOrInsertWithId(strSQL, false);

                I.WCClaimID = WCClaimID;
                I.WCClaimNumber = thisWCClaimNumber;

                PutWCClaim(I);
                
                return WCClaimID.ToString();
            } 
            catch (Exception ex)
            {
                return "There was an issue posting the workers comp claim.";
            }
            
        }

        [HttpPost]
        [Route("api/InsuranceWCClaims/PutWCClaim")]
        public string PutWCClaim(InsuranceWCClaim I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.WCClaim " +
                        "SET WCClaimNumber = '" + I.WCClaimNumber +
                        "',PolicyTypeID = " + I.PolicyTypeID +
                        ",PCAInsuranceNumber = '" + I.PCAInsuranceNumber +
                        "',WCClaimStatusID = " + I.WCClaimStatusID +
                        ",WCClaimStatusDate = '" + I.WCClaimStatusDate +
                        "',OSHALog = '" + I.OSHALog +
                        "',ReportedToCarrierDate = '" + I.ReportedToCarrierDate +
                        "',DaysMissed = " + I.DaysMissed +
                        ",NumberOfDaysMissed = " + I.NumberOfDaysMissed +
                        ",LiteRelease = " + I.LiteRelease +
                        ",NumberOfLiteDutyDays = " + I.NumberOfLiteDutyDays +
                        ",FullReleaseDate = '" + I.FullReleaseDate +
                        "',ReturnedToWorkDate = '" + I.ReturnedToWorkDate +
                        "',FollowUpApptDate = '" + I.FollowUpApptDate +
                        "',ImpairmentRating = '" + I.ImpairmentRating +
                        "',Subro = '" + I.Subro +
                        "',JobClass = '" + I.JobClass +
                        "',RepFollowUpDate = '" + I.RepFollowUpDate +
                        "',ModifiedDutyRequired = " + I.ModifiedDutyRequired +
                        ",IndemnityCompPaid = " + I.IndemnityCompPaid +
                        ",IndemnityCompReserve = " + I.IndemnityCompReserve +
                        ",MedicalPaid = " + I.MedicalPaid +
                        ",MedicalReserve = " + I.MedicalReserve +
                        ",WCClaimExpensePaid = " + I.WCClaimExpensePaid +
                        ",WCExpenseReserve = " + I.WCExpenseReserve +
                        ",SubroAmount = " + I.SubroAmount +
                        ",Settlement = '" + I.Settlement +
                        "',PoliceReportNumber = '" + I.PoliceReportNumber +
                        "',PCAReceivedClaimDate = '" + I.PCAReceivedClaimDate +
                        "',ClaimantName = '" + I.ClaimantName +
                        "',WCIncidentDate = '" + I.WCIncidentDate +
                        "',PCARepID = " + I.PCARepID +
                        ",LocationID = " + I.LocationID +
                        ",Closed = " + I.Closed +
                        " WHERE WCInvestigationID = " + I.WCInvestigationID;

                thisADO.updateOrInsert(strSQL, false);
                return I.WCClaimID.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceWCClaims/PostWCClaimNote")]
        public string PostClaimNote(InsuranceWCClaimNote I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.WCClaimNote " +
                        "(WCClaimID " +
                        ",WCClaimNoteContent " +
                        ",WCClaimEnteredBy " +
                        ",WCClaimNoteDate) " +
                        "VALUES " +
                        "(" + I.WCClaimID +
                        ",'" + I.WCClaimNoteContent + "'" +
                        ",'" + I.WCClaimEnteredBy + "'" +
                        ",'" + I.WCClaimNoteDate + "')";

                thisADO.updateOrInsert(strSQL, false);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/InsuranceWCClaims/GetWCClaimNote/{id}")]
        public List<InsuranceWCClaimNote> GetClaimNote(string id)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select WCClaimNoteID, WCClaimNoteContent, WCClaimEnteredBy, WCClaimNoteDate from InsurancePCA.dbo.WCClaimNote where WCClaimID = " + id;

                List<InsuranceWCClaimNote> list = new List<InsuranceWCClaimNote>();

                thisADO.returnSingleValue(strSQL, false, ref list);

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
