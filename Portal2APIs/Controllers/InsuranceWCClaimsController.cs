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
    public class InsuranceWCClaimsController : ApiController
    {
        [HttpGet]
        [Route("api/InsuranceWCClaims/GetWCClaimByID/{Id}")]
        public List<InsuranceWCClaim> GetWCClaimByID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();
                
                strSQL = "SELECT wcc.WCClaimID ,wcc.ClaimId ,wcc.WCClaimNumber ,wcc.WCInvestigationID ,i.IncidentDate as WCIncidentDate ,wcc.ReportedToCarrierDate , " +
                            "wcc.PolicyTypeID ,wcc.PCAInsuranceNumber ,wcc.WCClaimStatusID ,wcc.WCClaimStatusDate ,wcc.OSHALog ,wcc.DaysMissed , " +
                            "wcc.NumberOfDaysMissed ,wcc.LiteRelease ,wcc.NumberOfLiteDutyDays ,wcc.FullReleaseDate ,wcc.DateReturnedToWork , " +
                            "wcc.FollowUpApptDate ,wcc.ImpairmentRating ,wcc.Subro ,wcc.JobClass ,wcc.RepFollowUpDate ,wcc.ModifiedDutyRequired , " +
                            "wcc.IndemnityCompPaid ,wcc.IndemnityCompReserve ,wcc.MedicalPaid ,wcc.MedicalReserve ,wcc.WCClaimExpensePaid , " +
                            "wcc.WCExpenseReserve ,wcc.SubroAmount ,wcc.Settlement ,wcc.PoliceReportNumber ,wcc.PCAReceivedClaimDate , " +
                            "wcc.PCARepID , i.IncidentNumber, ipv.DriverName as ClaimantName, i.LocationID  " +
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
    }
}
