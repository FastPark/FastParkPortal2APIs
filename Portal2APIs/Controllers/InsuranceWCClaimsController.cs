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
        [Route("api/InsuranceIncidents/SearchIncidentList/")]
        public List<InsuranceIncident> SearchIncidentList(InsuranceIncident I)
        {
            var thisWhere = " where (1 = 1)";

            if (I.IncidentNumber != null)
            {
                thisWhere = thisWhere + " and I.IncidentNumber = '" + I.IncidentNumber + "'";
            }

            if (I.ClaimNumber != null)
            {

                thisWhere = thisWhere + " and c.ClaimNumber = '" + I.ClaimNumber + "'";
            }

            if (I.WCClaimNumber != null)
            {

                thisWhere = thisWhere + " and wcc.WCClaimNumber = '" + I.WCClaimNumber + "'";
            }

            if (I.IncidentDate.ToString() != "1/1/0001 12:00:00 AM")
            {
                thisWhere = thisWhere + " and Convert(nvarchar, I.IncidentDate, 101) =  Convert(nvarchar, CAST('" + I.IncidentDate + "' as date), 101)";
            }

            if (I.IncidentStatus != null)
            {
                thisWhere = thisWhere + " I.IncidentStatus = '" + I.IncidentStatus + "'";
            }

            if (I.ClaimStatusID != 0)
            {
                thisWhere = thisWhere + " and c.ClaimStatusID = " + I.ClaimStatusID;
            }

            if (I.LocationId != 0)
            {
                thisWhere = thisWhere + " and I.LocationId = '" + I.LocationId + "'";
            }

            if (I.ClaimantName != null)
            {
                thisWhere = thisWhere + " and c.ClaimantName = '" + I.ClaimantName + "'";
            }

            if (I.PCAInsuranceClaimNumber != null)
            {
                thisWhere = thisWhere + " and c.PCAInsuranceClaimNumber = '" + I.PCAInsuranceClaimNumber + "'";
            }

            if (I.Closed != null)
            {
                thisWhere = thisWhere + " and c.Closed = " + I.Closed;
            }

            string[] results = I.ViewSettings.Split(',');
            if (results.Length > 1)
            {
                thisWhere = thisWhere + " And i.LocationId in (" + I.ViewSettings + ") " +
                            "And i.IncidentStatusID <> 3 and (i.Deleted is null or i.Deleted = 0)";
            }
            else
            {
                thisWhere = thisWhere + " And i.IncidentCreatedBy = '" + results[1].ToString() + "'  " +
                            "And i.LocationId in (" + results[0].ToString() + ") " +
                            "And i.IncidentStatusID <> 3 and (i.Deleted is null or i.Deleted = 0)";
            }

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select i.IncidentID,i.IncidentNumber,i.PCAReceiveDate,i.LocationId,l.LocationName + '-' + l.LocationGLCode as LocationName,i.LotID,i.IncidentStreetAddress,i.IncidentCity, " +
                            "i.IncidentStateID,i.IncidentZip,i.IncidentPhone,i.IncidentLotRowSpace,i.OperationTypeID,i.IncidentDate, i.IncidentTime, " +
                            "Case When c.Closed = 0 Then 'No' Else 'Yes' End as Closed, " +
                            "i.StayDuration,i.IncidentInjuries,i.PoliceReportNumber,i.OfficerName,i.NumberOfVehilesInvolved,i.PhysicalDamage,istat.IncidentStatus, " +
                            "i.PhysicalDamageDesc,i.IncidentCreatedBy, lot.LotName, locState.StateAbbreviation as LocState, s.StateAbbreviation, o.OperationTypeName, " +
                            "c.ClaimNumber, cs.ClaimStatusDesc, c.ClaimantName, c.PCAInsuranceClaimNumber, wcc.WCClaimNumber + '- 01' as WCClaimNumber, wcc.WCClaimID, c.ClaimID " +
                            "from InsurancePCA.dbo.Incident I " +
                            "Left Outer Join InsurancePCA.dbo.Claim c on i.IncidentID = c.IncidentID " +
                            "Left Outer Join InsurancePCA.dbo.ClaimStatus cs on c.ClaimStatusID = cs.ClaimStatusID " +
                            "Left Outer Join InsurancePCA.dbo.WCClaim wcc on c.ClaimID = wcc.ClaimId " +
                            "Left Outer Join InsurancePCA.dbo.Location l on I.LocationId = l.LocationID " +
                            "Left Outer Join InsurancePCA.dbo.State LocState on l.LocationStateID = LocState.StateId " +
                            "Left Outer Join InsurancePCA.dbo.Lot on I.LotID = Lot.LotId " +
                            "Left Outer Join InsurancePCA.dbo.State s on i.IncidentStateID = s.StateId " +
                            "Left Outer Join InsurancePCA.dbo.OperationType o on i.OperationTypeID = o.OperationTypeID " +
                            "Left Outer Join InsurancePCA.dbo.IncidentStatus istat on i.IncidentStatusID = istat.IncidentStatusID " +
                            thisWhere;


                List<InsuranceIncident> list = new List<InsuranceIncident>();


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
        [Route("api/InsuranceWCClaims/GetWCClaimByID/{Id}")]
        public List<InsuranceWCClaim> GetWCClaimByID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();
                
                strSQL = "SELECT wcc.WCClaimID ,wcc.ClaimID ,wcc.WCClaimNumber ,wcc.WCInvestigationID ,i.IncidentDate as WCIncidentDate ,wcc.ReportedToCarrierDate , " +
                            "wcc.PolicyTypeID ,wcc.PCAInsuranceNumber ,wcc.WCClaimStatusID ,wcc.WCClaimStatusDate ,wcc.OSHALog ,wcc.DaysMissed , " +
                            "wcc.NumberOfDaysMissed ,wcc.LiteRelease ,wcc.NumberOfLiteDutyDays ,wcc.FullReleaseDate ,wcc.ReturnedToWorkDate , " +
                            "wcc.FollowUpApptDate ,wcc.ImpairmentRating ,wcc.Subro ,wcc.JobClass ,wcc.RepFollowUpDate ,wcc.ModifiedDutyRequired , " +
                            "wcc.IndemnityCompPaid ,wcc.IndemnityCompReserve ,wcc.MedicalPaid ,wcc.MedicalReserve ,wcc.WCClaimExpensePaid , " +
                            "wcc.WCExpenseReserve ,wcc.SubroAmount ,wcc.Settlement ,wcc.PoliceReportNumber ,wcc.PCAReceivedClaimDate , " +
                            "wcc.PCARepID , i.IncidentNumber, ipv.DriverName as ClaimantName, i.LocationID, wcc.Closed  " +
                            "FROM InsurancePCA.dbo.WCClaim wcc  " +
                            "Left Outer Join InsurancePCA.dbo.Claim c on wcc.ClaimId = c.ClaimID  " +
                            "Left Outer Join InsurancePCA.dbo.Incident i on c.IncidentID = i.IncidentID  " +
                            "Left Outer Join InsurancePCA.dbo.IncidentPCAVehicle ipv on c.ClaimID = ipv.ClaimID " +
                            "Where wcc.WCCLaimID = " + Id;

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

                PutWCClaim(I);
                
                return "Success";
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
                        "SET ClaimID = " + I.ClaimID +
                        ",WCClaimNumber = '" + I.WCClaimNumber +
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
                        "',PCARepID = " + I.PCARepID +
                        ",Closed = " + I.Closed +
                        " WHERE WCClaimID = " + I.WCClaimID;

                thisADO.updateOrInsert(strSQL, false);
                return "Success";
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
