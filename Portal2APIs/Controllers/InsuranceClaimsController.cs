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
    public class InsuranceClaimsController : ApiController
    {


        [HttpGet]
        [Route("api/InsuranceClaims/GetClaimByID/{Id}")]
        public List<InsuranceClaim> GetIncidentByID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT c.ClaimID ,c.IncidentID ,ClaimTypeID ,PolicyTypeID ,ClaimantName, ClaimantNameClaimID ,ClaimStatusID, i.PCAReceiveDate ," +
                            "Case When Convert(nvarchar, c.ClaimStatusDate, 101) = '01/01/1900' Then NULL Else c.ClaimStatusDate End as ClaimStatusDate " +
                            ",PCAInsuranceClaimNumber ,OtherInsuranceClaimNumber, EmployeeInvolvedClaimID ," +
                            "PCARepID ,PaidByInsurance ,PaidByThridPartyInsurance ,PCADeductible ,PCAOutOfPocket, Reserve, MonthlyAllocation ," +
                            "EmployeePaid ,PendingStatusID, v.VehicleNumber, i.IncidentNumber + '-' + c.ClaimNumber as ClaimNumber, ipv.DriverName , " +
                            "itpv.CustomerName, i.IncidentDate, i.LocationID, Case When Convert(nvarchar, c.RepFollowUpDate, 101) = '01/01/1900' Then NULL Else c.RepFollowUpDate End as RepFollowUpDate, " +
                            "c.PaidByInsurance, c.PaidByThridPartyInsurance, c.Closed, " +
                            "c.PCADeductible,c.PCAOutOfPocket, c.EmployeePaid, i.PoliceReportNumber, l.LocationName + '-' + l.LocationGLCode as IncidentLocationName " +
                            "FROM InsurancePCA.dbo.Claim c " +
                            "Inner Join InsurancePCA.dbo.Incident i on c.IncidentID = i.IncidentID " +
                            "Left Outer Join InsurancePCA.dbo.Location l on i.LocationId = l.LocationID " +
                            "Left outer Join InsurancePCA.dbo.IncidentThirdPartyVehicle itpv on c.ClaimID = itpv.ClaimID " +
                            "Left Outer Join InsurancePCA.dbo.IncidentPCAVehicle ipv on c.ClaimID = ipv.ClaimID " +
                            "Left Outer Join Vehicles.dbo.Vehicles v on ipv.VehicleID = v.VehicleID " +
                            "Where c.ClaimID = " + Id;
                
                List<InsuranceClaim> list = new List<InsuranceClaim>();
                
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
        [Route("api/InsuranceClaims/GetEmployeeInvolved/{Id}")]
        public List<InsuranceClaim> GetEmployeeInvolved(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select ipv.DriverName, c.ClaimID " +
                        "from InsurancePCA.dbo.Claim c " +
                        "Inner Join InsurancePCA.dbo.IncidentPCAVehicle ipv on c.ClaimId = ipv.ClaimID " +
                        "Where c.IncidentID = " + Id;

                List<InsuranceClaim> list = new List<InsuranceClaim>();

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
        [Route("api/InsuranceClaims/GetThirdPartyEnvolved/{Id}")]
        public List<InsuranceClaim> GetThirdPartyEnvolved(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select ipv.CustomerName as ClaimantName, c.ClaimID " +
                        "from InsurancePCA.dbo.Claim c " +
                        "Inner Join InsurancePCA.dbo.IncidentThirdPartyVehicle ipv on c.ClaimId = ipv.ClaimID " +
                        "Where c.IncidentID = " + Id;

                List<InsuranceClaim> list = new List<InsuranceClaim>();

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
        [Route("api/InsuranceClaims/PutInsuranceClaim")]
        public string PutInsuranceClaim(InsuranceClaim I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.Claim " +
                        " SET ClaimTypeID = " + I.ClaimTypeID +
                        " ,PolicyTypeID = " + I.PolicyTypeID +
                        " ,ClaimStatusID = " + I.ClaimStatusID +
                        "  ,ClaimStatusDate = '" + I.ClaimStatusDate +
                        "' ,RepFollowUpDate = '" + I.RepFollowUpDate +
                        "' ,PCAInsuranceClaimNumber = '" + I.PCAInsuranceClaimNumber +
                        "' ,OtherInsuranceClaimNumber = '" + I.OtherInsuranceClaimNumber +
                        "' ,PCARepID = " + I.PCARepID +
                        " ,PaidByInsurance = " + I.PaidByInsurance +
                        " ,PaidByThridPartyInsurance = " + I.PaidByThridPartyInsurance +
                        " ,PCADeductible = " + I.PCADeductible +
                        " ,PCAOutOfPocket = " + I.PCAOutOfPocket +
                        " ,EmployeePaid = " + I.EmployeePaid +
                        " ,PendingStatusID = " + I.PendingStatusID +
                        " ,MonthlyAllocation = " + I.MonthlyAllocation +
                        " ,Reserve = " + I.Reserve +
                        " ,EmployeeInvolvedClaimID = " + I.EmployeeInvolvedClaimID +
                        " ,EmployeeInvolvedName = '" +I.EmployeeInvolvedName +
                        "' ,ClaimantNameClaimID = " + I.ClaimantNameClaimID +
                        " ,ClaimantName = '" + I.ClaimantName +
                        "' ,Closed = " + I.Closed +
                        " WHERE ClaimID = " + I.ClaimID;

                thisADO.updateOrInsert(strSQL, false);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceClaims/PostClaimNote")]
        public string PostClaimNote(InsuranceClaimNote I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.ClaimNote " +
                        "(ClaimID " +
                        ",ClaimNoteContent " +
                        ",ClaimNoteEnteredBy " +
                        ",ClaimNoteDate) " +
                        "VALUES " +
                        "(" + I.ClaimID +
                        ",'" + I.ClaimNoteContent + "'" +
                        ",'" + I.ClaimNoteEnteredBy + "'" +
                        ",'" + I.ClaimNoteDate + "')";

                thisADO.updateOrInsert(strSQL, false);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/InsuranceClaims/GetClaimNote/{id}")]
        public List<InsuranceClaimNote> GetClaimNote(string id)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select ClaimNoteID, ClaimNoteContent, ClaimNoteEnteredBy, ClaimNoteDate from InsurancePCA.dbo.ClaimNote where ClaimID = " + id;

                List<InsuranceClaimNote> list = new List<InsuranceClaimNote>();

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
        [Route("api/InsuranceClaims/PostPayable")]
        public string PostPayable(InsuranceClaimPayable I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.ClaimPayable " +
                        "(ClaimID " +
                        ",ClaimPayablePayee " +
                        ",ClaimPayableCheckNumber " +
                        ",ClaimPayableCheckAmount " +
                        ",ClaimPayableMailedDate) " +
                        "VALUES " +
                        "(" + I.ClaimID +
                        ",'" + I.ClaimPayablePayee + "'" +
                        ",'" + I.ClaimPayableCheckNumber + "'" +
                        "," + I.ClaimPayableCheckAmount + "" +
                        ",'" + I.ClaimPayableMailedDate + "')";

                thisADO.updateOrInsert(strSQL, false);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/InsuranceClaims/GetClaimPayable/{id}")]
        public List<InsuranceClaimPayable> GetClaimPayable(string id)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select ClaimPayableID, ClaimPayablePayee, ClaimPayableCheckNumber, ClaimPayableCheckAmount, ClaimPayableMailedDate from InsurancePCA.dbo.ClaimPayable where ClaimID = " + id;

                List<InsuranceClaimPayable> list = new List<InsuranceClaimPayable>();

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
        [Route("api/InsuranceClaims/PostReceivable")]
        public string PostReceivable(InsuranceClaimReceivable I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.ClaimReceivable " +
                        "(ClaimID " +
                        ",ClaimReceivablePayor " +
                        ",ClaimReceivableCheckNumber " +
                        ",ClaimReceivableCheckAmount) " +
                        "VALUES " +
                        "(" + I.ClaimID +
                        ",'" + I.ClaimReceivablePayor + "'" +
                        ",'" + I.ClaimReceivableCheckNumber + "'" +
                        "," + I.ClaimReceivableCheckAmount + ")";

                thisADO.updateOrInsert(strSQL, false);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/InsuranceClaims/GetClaimReceivable/{id}")]
        public List<InsuranceClaimReceivable> GetClaimReceivable(string id)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select ClaimReceivableID, ClaimReceivablePayor, ClaimReceivableCheckNumber, ClaimReceivableCheckAmount from InsurancePCA.dbo.ClaimReceivable where ClaimID = " + id;

                List<InsuranceClaimReceivable> list = new List<InsuranceClaimReceivable>();

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
        [Route("api/InsuranceClaims/GetPCAInvolvedVehicleNumber/{Id}")]
        public string GetPCAInvolvedVehicleNumber(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select v.VehicleNumber " +
                            "from InsurancePCA.dbo.IncidentPCAVehicle pcav " +
                            "Inner Join Vehicles.dbo.Vehicles v on pcav.VehicleID = v.VehicleId " +
                            "Where pcav.ClaimID = " + Id;

                var thisVehicle = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                return thisVehicle;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++   Loading Type, Status and Rep Drop Downs ++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet]
        [Route("api/InsuranceClaims/GetClaimTypes")]
        public List<InsuranceClaimType> GetClaimTypes()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT ClaimTypeID, ClaimTypeDesc from InsurancePCA.dbo.ClaimType";

                List<InsuranceClaimType> list = new List<InsuranceClaimType>();


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
        [Route("api/InsuranceClaims/GetPolicyTypes")]
        public List<PolicyType> GetPolicyTypes()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT PolicyTypeID, PolicyTypeDesc from InsurancePCA.dbo.PolicyType";

                List<PolicyType> list = new List<PolicyType>();


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
        [Route("api/InsuranceClaims/GetClaimStatuses")]
        public List<InsuranceClaimStatus> GetClaimStatuses()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT ClaimStatusID, ClaimStatusDesc from InsurancePCA.dbo.ClaimStatus";

                List<InsuranceClaimStatus> list = new List<InsuranceClaimStatus>();


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
        [Route("api/InsuranceClaims/GetPendingClaimStatuses")]
        public List<PendingClaimStatus> GetPendingClaimStatuses()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT PendingClaimStatusID, PendingClaimStatusDesc from InsurancePCA.dbo.PendingClaimStatus";

                List<PendingClaimStatus> list = new List<PendingClaimStatus>();


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
        [Route("api/InsuranceClaims/GetPCAReps/")]
        public List<PCARep> GetPCAReps()
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT PCARepID, PCARepFirstName + ' ' + PCARepLastName as PCARepName from InsurancePCA.dbo.PCARep";

                List<PCARep> list = new List<PCARep>();


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
