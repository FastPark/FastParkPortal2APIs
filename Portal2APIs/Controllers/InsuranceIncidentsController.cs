using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;

namespace Portal2APIs.Controllers
{
    public class InsuranceIncidentsController : ApiController
    {
        [HttpGet]
        [Route("api/InsuranceIncidents/GetIncidentList/{Id}")]
        public List<InsuranceIncident> GetIncidentList(string Id)
        {
            string Where = "";

            string[] results = Id.Split('~');
            if (results.Length == 1)
            {
                Where = "Where i.LocationId in (" + results[0].ToString() + ") " +
                            "And i.IncidentStatusID <> 3 and (i.Deleted is null or i.Deleted = 0)";
            }
            else
            {
                Where = "Where i.IncidentCreatedBy = '" + results[1].ToString() + "'  " +
                            "And i.LocationId in (" + results[0].ToString() + ") " +
                            "And i.IncidentStatusID <> 3 and (i.Deleted is null or i.Deleted = 0)";
            }
            
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select i.IncidentID,i.IncidentNumber,i.PCAReceiveDate,i.LocationId,l.LocationName + '-' + l.LocationGLCode as LocationName,i.LotID,i.IncidentStreetAddress,i.IncidentCity, " +
                            "i.IncidentStateID,i.IncidentZip,i.IncidentPhone,i.IncidentLotRowSpace,i.OperationTypeID,i.IncidentDate, i.IncidentTime, " +
                            "Case When wcc.Closed is null Then Case When c.Closed = 0 Then 'No' Else 'Yes' End Else Case When wcc.Closed = 0 Then 'No' Else 'Yes' End End as Closed, " +
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
                            Where;
                            

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
        [Route("api/InsuranceIncidents/GetIncidentByID/{Id}")]
        public List<InsuranceIncident> GetIncidentByID(string Id)
        {
           
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select i.IncidentID,i.IncidentNumber,i.PCAReceiveDate,i.LocationId,l.LocationName + '-' + l.LocationGLCode as LocationName,i.LotID,i.IncidentStreetAddress,i.IncidentCity, " +
                            "i.IncidentStateID,i.IncidentZip,i.IncidentPhone,i.IncidentLotRowSpace,i.OperationTypeID,i.IncidentDate, i.IncidentTime, " +
                            "i.StayDuration,i.IncidentInjuries,i.PoliceReportNumber, i.PoliceReportDate,i.OfficerName,i.NumberOfVehilesInvolved,i.PhysicalDamage,istat.IncidentStatus, " +
                            "i.PhysicalDamageDesc,i.IncidentCreatedBy, lot.LotName, locState.StateAbbreviation as LocState, s.StateAbbreviation, o.OperationTypeName, " +
                            "i.IncidentCustomerSignature, i.IncidentEmployeeSignature, i.IncidentManagerSignature, fm.FacilityManagerFirstName + ' ' + fm.FacilityManagerLastName as FacilityManagerName " +
                            "from InsurancePCA.dbo.Incident I " +
                            "Left Outer Join InsurancePCA.dbo.Location l on I.LocationId = l.LocationID " +
                            "Left Outer Join InsurancePCA.dbo.FacilityManager fm on l.FacilityManagerID = fm.FacilityManagerID " +
                            "Left Outer Join InsurancePCA.dbo.State LocState on l.LocationStateID = LocState.StateId " +
                            "Left Outer Join InsurancePCA.dbo.Lot on I.LotID = Lot.LotId " +
                            "Left Outer Join InsurancePCA.dbo.State s on i.IncidentStateID = s.StateId " +
                            "Left Outer Join InsurancePCA.dbo.OperationType o on i.OperationTypeID = o.OperationTypeID " +
                            "Left Outer Join InsurancePCA.dbo.IncidentStatus istat on i.IncidentStatusID = istat.IncidentStatusID " +
                            "Where I.IncidentID = " + Id;


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

        [HttpPost]
        [Route("api/InsuranceIncidents/PostIncident")]
        public string PostIncident(InsuranceIncident I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select Max(IncidentNumber) + 1 from InsurancePCA.dbo.Incident";

                string thisIncidentNumber = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);


                strSQL = "INSERT INTO InsurancePCA.dbo.Incident " +
                            "(PCAReceiveDate, IncidentNumber, LocationId, IncidentStreetAddress, " +
                             "IncidentCity, IncidentStateID, IncidentZip, IncidentPhone, IncidentLotRowSpace, OperationTypeID, " +
                             "IncidentDate, IncidentTime, StayDuration, IncidentInjuries, PoliceReportNumber, PoliceReportDate, " +
                             "OfficerName, NumberOfVehilesInvolved, PhysicalDamage, PhysicalDamageDesc, IncidentCreatedBy, " +
                             "IncidentCustomerSignature, IncidentEmployeeSignature, IncidentManagerSignature, i.IncidentStatusID) " +
                             "VALUES " +
                            "('" + I.PCAReceiveDate + "','" + thisIncidentNumber + "', " + I.LocationId + ", '" + I.IncidentStreetAddress + "', '" + I.IncidentCity + "', " +
                             I.IncidentStateID + ", '" + I.IncidentZip + "', '" + I.IncidentPhone + "', '" + I.IncidentLotRowSpace + "', " + I.OperationTypeID + ", '" + I.IncidentDate + "', " +
                             "'" + I.IncidentTime + "', '" + I.StayDuration + "', " + I.IncidentInjuries + ", '" + I.PoliceReportNumber + "', '" + I.PoliceReportDate + "', '" + I.OfficerName + "', " +
                             I.NumberOfVehilesInvolved + ", " + I.PhysicalDamage + ", '" + I.PhysicalDamageDesc + "', '" + I.IncidentCreatedBy + "', '" + I.IncidentCustomerSignature + "', " +
                             "'" + I.IncidentEmployeeSignature + "', '" + I.IncidentManagerSignature + "', " + I.IncidentStatusID + ")";
                
                string IncidentID = thisADO.updateOrInsertWithId(strSQL, false).ToString();

                strSQL = "Insert Into InsurancePCA.dbo.IncidentCheckList (IncidentID) values (" + IncidentID + ")";

                thisADO.updateOrInsert(strSQL, false);

                return IncidentID;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceIncidents/PutIncident")]
        public string PutIncident(InsuranceIncident I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.Incident " +
                            "SET LocationId = " + I.LocationId + " " +
                            ",IncidentStatusID = " + I.IncidentStatusID + " " +
                            ",IncidentStreetAddress = '" + I.IncidentStreetAddress + "' " +
                            ",IncidentCity = '" + I.IncidentCity + "' " +
                            ",IncidentStateID = " + I.IncidentStateID + " " +
                            ",IncidentZip = '" + I.IncidentZip + "' " +
                            ",IncidentPhone = '" + I.IncidentPhone + "' " +
                            ",IncidentLotRowSpace = '" + I.IncidentLotRowSpace + "' " +
                            ",OperationTypeID = " + I.OperationTypeID + " " +
                            ",IncidentDate = '" + I.IncidentDate + "' " +
                            ",IncidentTime = '" + I.IncidentTime + "' " +
                            ",StayDuration = '" + I.StayDuration + "' " +
                            ",IncidentInjuries = '" + I.IncidentInjuries + "' " +
                            ",PoliceReportNumber = '" + I.PoliceReportNumber + "' " +
                            ",PoliceReportDate = '" + I.PoliceReportDate + "' " +
                            ",OfficerName = '" + I.OfficerName + "' " +
                            ",NumberOfVehilesInvolved = '" + I.NumberOfVehilesInvolved + "' " +
                            ",PhysicalDamage = '" + I.PhysicalDamage + "' " +
                            ",PhysicalDamageDesc = '" + I.PhysicalDamageDesc + "' " +
                            ",IncidentCreatedBy = '" + I.IncidentCreatedBy + "' " +
                            ",IncidentCustomerSignature = '" + I.IncidentCustomerSignature + "' " +
                            ",IncidentEmployeeSignature = '" + I.IncidentEmployeeSignature + "' " +
                            ",IncidentManagerSignature = '" + I.IncidentManagerSignature + "' " +
                            ",Deleted = " + I.Deleted + " " +
                            "WHERE IncidentId = " + I.IncidentID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceIncidents/UpdateIncidentStatus")]
        public string UpdateIncidentStatus(InsuranceIncident I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.Incident " +
                            "SET IncidentStatusID = " + I.IncidentStatusID + " " +
                            "WHERE IncidentId = " + I.IncidentID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceIncidents/PostPCAVehicle")]
        public string PostPCAVehicle(PCAVehicleClaim I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.IncidentPCAVehicle " +
                        "(ClaimID, VehicleID, DriverName, DriverLicenseNumber, Injuries, TagNumber, TagStateID) " +
                        "VALUES " +
                        "(" + I.ClaimID + ", " + I.VehicleID + ", '" + I.DriverName + "', '" + I.DriverLicenseNumber + "', " + I.Injuries + ", '" + I.TagNumber + "', '" + I.TagStateID + "')";
                
                thisADO.updateOrInsert(strSQL, false);

                if (I.Injuries == 1)
                {
                    strSQL = "Select Max(WCClaimNumber) + 1 from InsurancePCA.dbo.WCClaim";

                    string thisWCClaimNumber = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                    strSQL = "Insert INTO InsurancePCA.dbo.WCClaim (ClaimID, WCCLaimNumber, PoliceReportNumber, PCAReceivedClaimDate, LocationID, ClaimantName, WCIncidentDate) " +
                            "VALUES (" + I.ClaimID + ", '" + thisWCClaimNumber + "', '" + I.PoliceReportNumber + "', '" + I.PCAReceivedClaimDate + "', " + I.LocationID + ", '" + I.DriverName + "', '" + I.WCIncidentDate + "')";

                    thisADO.updateOrInsert(strSQL, false);
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceIncidents/PutPCAVehicle")]
        public string PutPCAVehicle(PCAVehicleClaim I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.IncidentPCAVehicle " +
                            "SET VehicleID = " + I.VehicleID + " " +
                            ",DriverName = '" + I.DriverName + "' " +
                            ",DriverLicenseNumber = '" + I.DriverLicenseNumber + "' " +
                            ",Injuries = " + I.Injuries + " " +
                            ",TagNumber = '" + I.TagNumber + "' " +
                            ",TagStateID = " + I.TagStateID + " " +
                            "WHERE ClaimID = " + I.ClaimID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceIncidents/PutPCAVehicleFromInvestigation")]
        public string PutPCAVehicleFromInvestigation(PCAVehicleClaim I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.IncidentPCAVehicle " +
                            " Set DateOfHire = '" + I.DateOfHire + "' " +
                            ",DrugTest = " + I.DrugTest + " " +
                            "WHERE ClaimID = " + I.ClaimID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++ Start Incident Witness +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet]
        [Route("api/InsuranceIncidents/GetIncidentWitnessByManagerInvestigationID/{Id}")]
        public List<InsuranceIncidentWitness> GetIncidentWitnessByManagerInvestigationID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select ManagerInvestigationID from InsurancePCA.dbo.ManagerInvestigation where IncidentID = " + Id;

                string thisManagerInvestigationID = thisADO.returnSingleValueForInternalAPIUse(strSQL, false).ToString();

                strSQL = "SELECT WitnessID " +
                        ",ManagerInvestigationID " +
                        ",WitnessName " +
                        ",WitnessAddress " +
                        ",WitnessStateID " +
                        ",WitnessCity " +
                        ",WitnessZip " +
                        ",WitnessPhone " +
                        ",Passenger " +
                        "FROM InsurancePCA.dbo.IncidentWitness " +
                        "Where ManagerInvestigationID = " + thisManagerInvestigationID;

                List<InsuranceIncidentWitness> list = new List<InsuranceIncidentWitness>();

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
        [Route("api/InsuranceIncidents/PostIncidentWitness")]
        public string PostIncidentWitness(InsuranceIncidentWitness I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.IncidentWitness " +
                        "(ManagerInvestigationID " +
                        ",WitnessName " +
                        ",WitnessAddress " +
                        ",WitnessStateID " +
                        ",WitnessCity " +
                        ",WitnessZip " +
                        ",WitnessPhone " +
                        ",Passenger) " +
                        "VALUES " +
                        "(" + I.ManagerInvestigationID + " " +
                        ",'" + I.WitnessName + "' " +
                        ",'" + I.WitnessAddress + "' " +
                        "," + I.WitnessStateID + " " +
                        ",'" + I.WitnessCity + "' " +
                        ",'" + I.WitnessZip + "' " +
                        ",'" + I.WitnessPhone + "' " +
                        ",'" + I.Passenger + "')";

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [HttpPost]
        [Route("api/InsuranceIncidents/PutIncidentWitness")]
        public string PutIncidentWitness(InsuranceIncidentWitness I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.IncidentWitness " +
                        "SET WitnessName = '" + I.WitnessName + "' " +
                        ",WitnessAddress = '" + I.WitnessAddress + "' " +
                        ",WitnessStateID = " + I.WitnessStateID + " " +
                        ",WitnessCity = '" + I.WitnessCity + "' " +
                        ",WitnessZip = '" + I.WitnessZip + "' " +
                        ",WitnessPhone = '" + I.WitnessPhone + "' " +
                        ",Passenger = '" + I.Passenger + "' " +
                        "WHERE WitnessID = " + I.WitnessID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ End Incident Witness ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //+++++++++++++++++++++++++++++++++++++++++++++++ Start Incident Other Involved +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet]
        [Route("api/InsuranceIncidents/GetIncidentOtherInvolvedByManagerInvestigationID/{Id}")]
        public List<IncidentOtherInvolved> GetIncidentOtherInvolvedByManagerInvestigationID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select ManagerInvestigationID from InsurancePCA.dbo.ManagerInvestigation where IncidentID = " + Id;

                string thisManagerInvestigationID = thisADO.returnSingleValueForInternalAPIUse(strSQL, false).ToString();

                strSQL = "SELECT IncidentOtherInvolvedID " +
                        ",ManagerInvestigationID " +
                        ",OtherInvolvedName " +
                        ",OtherInvolvedPhone " +
                        ",OtherInvolvedRole " +
                        ",OtherInvolvedDamageInjury " +
                        "FROM InsurancePCA.dbo.IncidentOtherInvolved " +
                        "Where ManagerInvestigationID = " + thisManagerInvestigationID;

                List<IncidentOtherInvolved> list = new List<IncidentOtherInvolved>();

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
        [Route("api/InsuranceIncidents/PostIncidentOtherInvolved")]
        public string PostIncidentOtherInvolved(IncidentOtherInvolved I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.IncidentOtherInvolved " +
                        "(ManagerInvestigationID " +
                        ",OtherInvolvedName " +
                        ",OtherInvolvedPhone " +
                        ",OtherInvolvedRole " +
                        ",OtherInvolvedDamageInjury) " +
                        "VALUES " +
                        "(" + I.ManagerInvestigationID + " " +
                        ",'" + I.OtherInvolvedName + "' " +
                        ",'" + I.OtherInvolvedPhone + "' " +
                        ",'" + I.OtherInvolvedRole + "' " +
                        ",'" + I.OtherInvolvedDamageInjury + "')";

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [HttpPost]
        [Route("api/InsuranceIncidents/PutIncidentOtherInvolved")]
        public string PutIncidentOtherInvolved(IncidentOtherInvolved I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.IncidentOtherInvolved " +
                        "SET OtherInvolvedName = '" + I.OtherInvolvedName + "' " +
                        ",OtherInvolvedPhone = '" + I.OtherInvolvedPhone + "' " +
                        ",OtherInvolvedRole = '" + I.OtherInvolvedRole + "' " +
                        ",OtherInvolvedDamageInjury = '" + I.OtherInvolvedDamageInjury + "' " +
                        "WHERE IncidentOtherInvolvedID = " + I.IncidentOtherInvolvedID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ End Incident Other Involved ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //+++++++++++++++++++++++++++++++++++++++++++++++ Start Incident Manager Investigation +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet]
        [Route("api/InsuranceIncidents/GetManagerInvestigationByIncidentID/{Id}")]
        public List<ManagerInvestigation> GetManagerInvestigationByID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT ManagerInvestigationID " +
                        ",IncidentID " +
                        ",InvestigationDate " +
                        ",InvestigationIncidentDesc " +
                        ",InvestigationCustomerInteraction " +
                        ",ManagerRecomendationID " +
                        ",PCAVehicleAmountDamage " +
                        ",CustomerVehicleAmountDamage " +
                        ",PCAPropertyDamage " +
                        ",ManagerSignature " +
                        "FROM InsurancePCA.dbo.ManagerInvestigation " +
                        "Where IncidentID = " + Id;

                List<ManagerInvestigation> list = new List<ManagerInvestigation>();

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
        [Route("api/InsuranceIncidents/PostManagerInvestigation")]
        public string PostManagerInvestigation(ManagerInvestigation I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.ManagerInvestigation " +
                        "(IncidentID " +
                        ",InvestigationIncidentDesc " +
                        ",InvestigationCustomerInteraction " +
                        ",ManagerRecomendationID " +
                        ",PCAPropertyDamage " +
                        ",CustomerVehicleAmountDamage " +
                        ",InvestigationDate " +
                        ",ManagerSignature " +
                        ",PCAVehicleAmountDamage) " +
                        "VALUES " +
                        "(" + I.IncidentID + " " +
                        ",'" + I.InvestigationIncidentDesc + "' " +
                        ",'" + I.InvestigationCustomerInteraction + "' " +
                        ",'" + I.ManagerRecomendationID + "' " +
                        "," + I.PCAPropertyDamage + " " +
                        "," + I.CustomerVehicleAmountDamage + " " +
                        ",'" + I.InvestigationDate + "' " +
                        ",'" + I.ManagerSignature + "' " +
                        "," + I.PCAVehicleAmountDamage + ")";

                var thisManagerInvestigationID = thisADO.updateOrInsertWithId(strSQL, false).ToString();

                return thisManagerInvestigationID;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [HttpPost]
        [Route("api/InsuranceIncidents/PutManagerInvestigation")]
        public string PutManagerInvestigation(ManagerInvestigation I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.ManagerInvestigation " +
                        "SET InvestigationIncidentDesc = '" + I.InvestigationIncidentDesc + "' " +
                        ",InvestigationCustomerInteraction = '" + I.InvestigationCustomerInteraction + "' " +
                        ",ManagerRecomendationID = " + I.ManagerRecomendationID + " " +
                        ",PCAVehicleAmountDamage = " + I.PCAVehicleAmountDamage + " " +
                        ",PCAPropertyDamage = " + I.PCAPropertyDamage + " " +
                        ",InvestigationDate = '" + I.InvestigationDate + "' " +
                        ",CustomerVehicleAmountDamage = " + I.CustomerVehicleAmountDamage + " " +
                        ",ManagerSignature = '" + I.ManagerSignature + "' " +
                        "WHERE ManagerInvestigationID = " + I.ManagerInvestigationID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ End Incident Manager Investigation ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //+++++++++++++++++++++++++++++++++++++++++++++++ Start Employee Statement +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet]
        [Route("api/InsuranceIncidents/GetEmployeeStatementByClaimID/{Id}")]
        public List<EmployeeStatement> GetEmployeeStatementByClaimID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT EmployeeStatementID " +
                        ",Position " +
                        ",EmpClaimID " +
                        ",CustClaimID " +
                        ",IncidentDesc " +
                        ",InjuryDesc " +
                        ",EmpSignature " +
                        ",StatementDate " +
                        "FROM InsurancePCA.dbo.EmployeeStatement " +
                        "Where EmpClaimID = " + Id;

                List<EmployeeStatement> list = new List<EmployeeStatement>();

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
        [Route("api/InsuranceIncidents/PostEmployeeStatement")]
        public string PostEmployeeStatement(EmployeeStatement I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.EmployeeStatement " +
                        "(Position " +
                        ",EmpClaimID " +
                        ",CustClaimID " +
                        ",IncidentDesc " +
                        ",InjuryDesc " +
                        ",EmpSignature " +
                        ",StatementDate) " +
                        "VALUES " +
                        "('" + I.Position + "' " +
                        "," + I.EmpClaimID + " " +
                        "," + I.CustClaimID + " " +
                        ",'" + I.IncidentDesc + "' " +
                        ",'" + I.InjuryDesc + "' " +
                        ",'" + I.EmpSignature + "' " +
                        ",'" + I.StatementDate + "')";

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [HttpPost]
        [Route("api/InsuranceIncidents/PutEmployeeStatement")]
        public string PutEmployeeStatement(EmployeeStatement I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.EmployeeStatement " +
                        "SET Position = '" + I.Position + "' " +
                        ",EmpClaimID = " + I.EmpClaimID + " " +
                        ",CustClaimID = " + I.CustClaimID + " " +
                        ",IncidentDesc = '" + I.IncidentDesc + "' " +
                        ",InjuryDesc = '" + I.InjuryDesc + "' " +
                        ",EmpSignature = '" + I.EmpSignature + "' " +
                        ",StatementDate = '" + I.StatementDate + "' " +
                        "WHERE EmpClaimID = " + I.EmpClaimID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ End EmployeeStatement ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //+++++++++++++++++++++++++++++++++++++++++++++++ Start Third Party Statement +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet]
        [Route("api/InsuranceIncidents/GetThirdPartyClaimVehiclesByClaim/{Id}")]
        public List<ThirdPartyVehicleClaim> GetThirdPartyClaimVehiclesByClaim(string Id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select itpv.CustomerName, itpv.CustomerStreetAddress, itpv.CustomerCity, custState.StateAbbreviation as CustomerState, itpv.CustomerEmailAddress, " +
                            "itpv.CustomerZip, itpv.VehicleYear, itpv.CustomerPhoneMobile,itpv.VehicleMake, itpv.CustomerPhoneHome, itpv.VehicleModel, itpv.CustomerDriverLicenseNumber, " +
                            "itpv.VehicleColor, itpv.InsuranceCompany, itpv.VehicleVIN, itpv.InsCompAddress, itpv.VehicleLicensePlate, itpv.InsCompPhone, TagState.StateAbbreviation as VehicleLicensePlateState, " +
                            "itpv.InsCompEmailAddress, itpv.InsCompAgentName, itpv.Injuries, itpv.InsCompPolicyNumber, c.ClaimID " +
                            "from InsurancePCA.dbo.IncidentThirdPartyVehicle itpv " +
                            "Inner Join InsurancePCA.dbo.Claim c on itpv.ClaimID = c.ClaimID " +
                            "Left Outer Join InsurancePCA.dbo.State custState on itpv.CustomerStateID = custState.StateId " +
                            "Left Outer Join InsurancePCA.dbo.State TagState on itpv.VehicleLicensePlateStateID = TagState.StateId " +
                            "Where c.ClaimID = " + Id;

                List<ThirdPartyVehicleClaim> list = new List<ThirdPartyVehicleClaim>();

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
        [Route("api/InsuranceIncidents/GetThirdPartyStatementByClaimID/{Id}")]
        public List<ThirdPartyStatement> GetThirdPartyStatementByClaimID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT ThirdPartyStatementID " +
                        ",CustClaimID " +
                        ",StayDuration " +
                        ",LotRowSpace " +
                        ",IncidentDesc " +
                        ",ThirdPartySignature " +
                        ",SignatureDate " +
                        "FROM InsurancePCA.dbo.ThirdPartyStatement " +
                        "Where CustClaimID = " + Id;

                List<ThirdPartyStatement> list = new List<ThirdPartyStatement>();

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
        [Route("api/InsuranceIncidents/PostThirdPartyStatement")]
        public string PostThirdPartyStatement(ThirdPartyStatement I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.ThirdPartyStatement " +
                        "(CustClaimID " +
                        ",StayDuration " +
                        ",LotRowSpace " +
                        ",IncidentDesc " +
                        ",ThirdPartySignature " +
                        ",SignatureDate) " +
                        "VALUES " +
                        "(" + I.CustClaimID + " " +
                        "," + I.StayDuration + " " +
                        ",'" + I.LotRowSpace + "' " +
                        ",'" + I.IncidentDesc + "' " +
                        ",'" + I.ThirdPartySignature + "' " +
                        ",'" + I.SignatureDate + "')";

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [HttpPost]
        [Route("api/InsuranceIncidents/PutThirdPartyStatement")]
        public string PutThirdPartyStatement(ThirdPartyStatement I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.ThirdPartyStatement " +
                        "SET CustClaimID = " + I.CustClaimID + " " +
                        ",StayDuration = " + I.StayDuration + " " +
                        ",LotRowSpace = '" + I.LotRowSpace + "' " +
                        ",IncidentDesc = '" + I.IncidentDesc + "' " +
                        ",ThirdPartySignature = '" + I.ThirdPartySignature + "' " +
                        ",SignatureDate = '" + I.SignatureDate + "' " +
                        "WHERE CustClaimID = " + I.CustClaimID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ End Third Party Statement ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //+++++++++++++++++++++++++++++++++++++++++++++++ Start Witness Statement +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        
        [HttpGet]
        [Route("api/InsuranceIncidents/GetWitnessByWitnessID/{Id}")]
        public List<InsuranceIncidentWitness> GetWitnessByWitnessID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT WitnessID " +
                        ",WitnessName " +
                        ",WitnessAddress " +
                        ",WitnessStateID " +
                        ",WitnessCity " +
                        ",WitnessZip " +
                        ",WitnessPhone " +
                        ",Passenger " +
                        "FROM InsurancePCA.dbo.IncidentWitness " +
                        "Where WitnessID = " + Id;

                List<InsuranceIncidentWitness> list = new List<InsuranceIncidentWitness>();

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
        [Route("api/InsuranceIncidents/GetWitnessStatementByWitnessID/{Id}")]
        public List<WitnessStatement> GetWitnessStatementByWitnessID(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "SELECT WitnessID " +
                        ",IncidentDesc " +
                        ",WitnessSignature " +
                        ",SignatureDate " +
                        "FROM InsurancePCA.dbo.WitnessStatement " +
                        "Where WitnessID = " + Id;

                List<WitnessStatement> list = new List<WitnessStatement>();

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
        [Route("api/InsuranceIncidents/PostWitnessStatement")]
        public string PostWitnessStatement(WitnessStatement I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.WitnessStatement " +
                        "(WitnessID " +
                        ",IncidentDesc " +
                        ",WitnessSignature " +
                        ",SignatureDate) " +
                        "VALUES " +
                        "(" + I.WitnessID + " " +
                        ",'" + I.IncidentDesc + "' " +
                        ",'" + I.WitnessSignature + "' " +
                        ",'" + I.SignatureDate + "')";

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [HttpPost]
        [Route("api/InsuranceIncidents/PutWitnessStatement")]
        public string PutWitnessStatement(WitnessStatement I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.WitnessStatement " +
                        "SET WitnessID = " + I.WitnessID + " " +
                        ",IncidentDesc = '" + I.IncidentDesc + "' " +
                        ",WitnessSignature = '" + I.WitnessSignature + "' " +
                        ",SignatureDate = '" + I.SignatureDate + "' " +
                        "WHERE WitnessID = " + I.WitnessID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ End Witness Statement ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



        [HttpPost]
        [Route("api/InsuranceIncidents/PostInitialIncidentClaim")]
        public string PostInitialIncidentClaim(InsuranceClaim I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;
            string ClaimNumber;
            
            try
            {
                ClaimNumber = getNextClaimNumber(I.IncidentID.ToString());
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            if (ClaimNumber == null)
            {
                return "Error getting claim number";
            }

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.Claim (ClaimNumber ,IncidentID ,ClaimantName , " +
                        "ClaimStatusID ,ClaimStatusDate) " +
                        "VALUES " +
                        "('" + ClaimNumber + "', " + I.IncidentID + ", '" + I.ClaimantName + "', " + I.ClaimStatusID + ", '" + I.ClaimStatusDate + "')";

                string ClaimID = thisADO.updateOrInsertWithId(strSQL, false).ToString();

                return ClaimID;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string getNextClaimNumber(string incidentId)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select Right('000' + Cast(Max(ClaimNumber + 1) as nvarchar), 2) as newClaimNumber " +
                        "from InsurancePCA.dbo.Claim c " +
                        "where c.incidentId = " + incidentId;

                string ClaimNumber = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                if (ClaimNumber == "")
                {
                    ClaimNumber = "01";
                }

                return ClaimNumber;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string getIncidentID(string incidentNumber)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select IncidentID " +
                        "from InsurancePCA.dbo.Incident i " +
                        "where i.IncidentNumber = " + incidentNumber.ToString();

                string IncidentID = thisADO.returnSingleValueForInternalAPIUse(strSQL, false);

                return IncidentID;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceIncidents/PostThirdPartyVehicle")]
        public string PostThirdPartyVehicle(InsuranceIncidentThirdPartyVehicle I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "INSERT INTO InsurancePCA.dbo.IncidentThirdPartyVehicle (ClaimID ,CustomerName ,CustomerEmailAddress , " +
                                                                   "CustomerStreetAddress ,CustomerCity ,CustomerStateID ,CustomerZip , " +
                                                                   "CustomerPhoneMobile ,CustomerPhoneHome ,CustomerDriverLicenseNumber , " +
                                                                   "InsuranceCompany ,InsCompAddress ,InsCompPhone ,InsCompAgentName , " +
                                                                   "InsCompEmailAddress ,InsCompPolicyNumber ,VehicleYear ,VehicleMake , " +
                                                                   "VehicleModel ,VehicleColor ,VehicleVIN ,VehicleLicensePlate , " +
                                                                   "VehicleLicensePlateStateID ,Injuries) " +
                            "VALUES " +
                                     "(" + I.ClaimID + ", '" + I.CustomerName + "', '" + I.CustomerEmailAddress + "', '" + I.CustomerStreetAddress + "', '" + I.CustomerCity + "', " +
                                     I.CustomerStateID + ", '" + I.CustomerZip + "', '" + I.CustomerPhoneMobile + "', '" + I.CustomerPhoneHome + "', '" + I.CustomerDriverLicenseNumber + "', " +
                                     "'" + I.InsuranceCompany + "', '" + I.InsCompAddress + "', '" + I.InsCompPhone + "', '" + I.InsCompAgentName + "', '" + I.InsCompEmailAddress + "', '" + I.InsCompPolicyNumber + "', " +
                                     "'" + I.VehicleYear + "', '" + I.VehicleMake + "', '" + I.VehicleModel + "', '" + I.VehicleColor + "', '" + I.VehicleVIN + "', '" + I.VehicleLicensePlate + "', " + I.VehicleLicensePlateStateID + ", '" + I.Injuries + "')";

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        [Route("api/InsuranceIncidents/PutThirdPartyVehicle")]
        public string PutThirdPartyVehicle(InsuranceIncidentThirdPartyVehicle I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.IncidentThirdPartyVehicle " +
                        "SET CustomerName = '" + I.CustomerName + "' " +
                        ",CustomerEmailAddress = '" + I.CustomerEmailAddress + "' " +
                        ",CustomerStreetAddress = '" + I.CustomerStreetAddress + "' " +
                        ",CustomerCity = '" + I.CustomerCity + "' " +
                        ",CustomerStateID = " + I.CustomerStateID + " " +
                        ",CustomerZip = '" + I.CustomerZip + "' " +
                        ",CustomerPhoneMobile = '" + I.CustomerPhoneMobile + "' " +
                        ",CustomerPhoneHome = '" + I.CustomerPhoneHome + "' " +
                        ",CustomerDriverLicenseNumber = '" + I.CustomerDriverLicenseNumber + "' " +
                        ",InsuranceCompany = '" + I.InsuranceCompany + "' " +
                        ",InsCompAddress = '" + I.InsCompAddress + "' " +
                        ",InsCompPhone = '" + I.InsCompPhone + "' " +
                        ",InsCompAgentName = '" + I.InsCompAgentName + "' " +
                        ",InsCompEmailAddress = '" + I.InsCompEmailAddress + "' " +
                        ",InsCompPolicyNumber = '" + I.InsCompPolicyNumber + "' " +
                        ",VehicleYear = '" + I.VehicleYear + "' " +
                        ",VehicleMake = '" + I.VehicleMake + "' " +
                        ",VehicleModel = '" + I.VehicleModel + "' " +
                        ",VehicleColor = '" + I.VehicleColor + "' " +
                        ",VehicleVIN = '" + I.VehicleVIN + "' " +
                        ",VehicleLicensePlate = '" + I.VehicleLicensePlate + "' " +
                        ",VehicleLicensePlateStateID = '" + I.VehicleLicensePlateStateID + "' " +
                        ",Injuries = " + I.Injuries + " " +
                        "WHERE ClaimID = " + I.ClaimID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        [Route("api/InsuranceIncidents/GetThirdPartyClaimVehiclesByIncident/{Id}")]
        public List<ThirdPartyVehicleClaim> GetThirdPartyClaimVehiclesByIncident(string Id)
        {
            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();

                strSQL = "Select itpv.CustomerName, itpv.CustomerStreetAddress, itpv.CustomerCity, custState.StateAbbreviation as CustomerState, itpv.CustomerEmailAddress, " +
                            "itpv.CustomerZip, itpv.VehicleYear, itpv.CustomerPhoneMobile,itpv.VehicleMake, itpv.CustomerPhoneHome, itpv.VehicleModel, itpv.CustomerDriverLicenseNumber, " +
                            "itpv.VehicleColor, itpv.InsuranceCompany, itpv.VehicleVIN, itpv.InsCompAddress, itpv.VehicleLicensePlate, itpv.InsCompPhone, TagState.StateAbbreviation as VehicleLicensePlateState, " +
                            "itpv.InsCompEmailAddress, itpv.InsCompAgentName, itpv.Injuries, itpv.InsCompPolicyNumber, c.ClaimID " +
                            "from InsurancePCA.dbo.IncidentThirdPartyVehicle itpv " +
                            "Inner Join InsurancePCA.dbo.Claim c on itpv.ClaimID = c.ClaimID " +
                            "Left Outer Join InsurancePCA.dbo.State custState on itpv.CustomerStateID = custState.StateId " +
                            "Left Outer Join InsurancePCA.dbo.State TagState on itpv.VehicleLicensePlateStateID = TagState.StateId " +
                            "Where c.IncidentID = " + Id;

                List<ThirdPartyVehicleClaim> list = new List<ThirdPartyVehicleClaim>();

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
        [Route("api/InsuranceIncidents/GetPCAClaimVehiclesByIncident/{Id}")]
        public List<PCAVehicleClaim> GetPCAClaimVehiclesByIncident(string Id)
        {

            try
            {
                string strSQL = "";
                clsADO thisADO = new clsADO();


                strSQL = "Select ipa.DriverName, ipa.DriverLicenseNumber, v.VehicleNumber,v.Year, ipa.TagNumber, s.StateAbbreviation, vma.MakeName, v.VINNumber, vm.ModelName, ipa.Injuries, c.ClaimNumber, v.VehicleID, ipa.TagStateID, c.ClaimID, ipa.DrugTest, ipa.DateOfHire " +
                            "from InsurancePCA.dbo.IncidentPCAVehicle ipa " +
                            "Left Outer Join InsurancePCA.dbo.Claim c on ipa.ClaimID = c.ClaimID " +
                            "Left Outer Join Vehicles.dbo.Vehicles v on ipa.VehicleID = v.VehicleID " +
                            "Left Outer Join Vehicles.dbo.VehicleModels vm on v.ModelId = vm.ModelId " +
                            "Left Outer Join Vehicles.dbo.VehicleMakes vma on vm.MakeId = vma.MakeId " +
                            "Left Outer Join InsurancePCA.dbo.State s on ipa.TagStateID = s.StateId " +
                            "Where c.IncidentID = " + Id +  " " +
                            "Order by c.ClaimID";


                List<PCAVehicleClaim> list = new List<PCAVehicleClaim>();


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
        [Route("api/InsuranceIncidents/getIncidentCheckListByID/{Id}")]
        public List<IncidentCheckList> getIncidentCheckListByID(string Id)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "SELECT IncidentCheckListID ,IncidentID ,EmployeeStatementManager ,EmployeeStatementRep ,CustomerStatementManager ,CustomerStatementRep ," +
                               "WitnessStatementManger ,WitnessStatementRep ,ManagerStatementManager ,ManagerStatementRep ,PicturesManager ,PicturesRep ," +
                               "OrigDocsManager ,OrigDocsRep ,BusEstManager ,BusEstRep ,BusInvManager ,BusInvRep ,PoliceReportManager ,PoliceReportRep ," +
                               "CustEstManager ,CustEstRep ,CustInvManager ,CustInvRep ,SlipFallWeatherManager ,SlipFallWeatherRep ,DriverMVRManager ," +
                               "DriverMVRRep ,DrugTestManager ,DrugTestRep ,PayrollDeductManager ,PayrollDeductRep ,OtherPersonInsuranceManager ," +
                               "OtherPersonInsuranceRep ,Comments " +
                        "FROM InsurancePCA.dbo.IncidentCheckList " +
                        "where incidentId = " + Id;

                List<IncidentCheckList> list = new List<IncidentCheckList>();

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
        [Route("api/InsuranceIncidents/PUTIncidentCheckList")]
        public string PostIncidentCheckList(IncidentCheckList I)
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "UPDATE InsurancePCA.dbo.IncidentCheckList " +
                        "SET EmployeeStatementManager = " + I.EmployeeStatementManager + " " +
                        ",EmployeeStatementRep = " + I.EmployeeStatementRep + " " +
                        ",CustomerStatementManager = " + I.CustomerStatementManager + " " +
                        ",CustomerStatementRep = " + I.CustomerStatementRep + " " +
                        ",WitnessStatementManger = " + I.WitnessStatementManger + " " +
                        ",WitnessStatementRep = " + I.WitnessStatementRep + " " +
                        ",ManagerStatementManager = " + I.ManagerStatementManager + " " +
                        ",ManagerStatementRep = " + I.ManagerStatementRep + " " +
                        ",PicturesManager = " + I.PicturesManager + " " +
                        ",PicturesRep = " + I.PicturesRep + " " +
                        ",OrigDocsManager = " + I.OrigDocsManager + " " +
                        ",OrigDocsRep = " + I.OrigDocsRep + " " +
                        ",BusEstManager = " + I.BusEstManager + " " +
                        ",BusEstRep = " + I.BusEstRep + " " +
                        ",BusInvManager = " + I.BusInvManager + " " +
                        ",BusInvRep = " + I.BusInvRep + " " +
                        ",PoliceReportManager = " + I.PoliceReportManager + " " +
                        ",PoliceReportRep = " + I.PoliceReportRep + " " +
                        ",CustEstManager = " + I.CustEstManager + " " +
                        ",CustEstRep = " + I.CustEstRep + " " +
                        ",CustInvManager = " + I.CustInvManager + " " +
                        ",CustInvRep = " + I.CustInvRep + " " +
                        ",SlipFallWeatherManager = " + I.SlipFallWeatherManager + " " +
                        ",SlipFallWeatherRep = " + I.SlipFallWeatherRep + " " +
                        ",DriverMVRManager = " + I.DriverMVRManager + " " +
                        ",DriverMVRRep = " + I.DriverMVRRep + " " +
                        ",DrugTestManager = " + I.DrugTestManager + " " +
                        ",DrugTestRep = " + I.DrugTestRep + " " +
                        ",PayrollDeductManager = " + I.PayrollDeductManager + " " +
                        ",PayrollDeductRep = " + I.PayrollDeductRep + " " +
                        ",OtherPersonInsuranceManager = " + I.OtherPersonInsuranceManager + " " +
                        ",OtherPersonInsuranceRep = " + I.OtherPersonInsuranceRep + " " +
                        ",Comments = '" + I.Comments + "' " +
                        "WHERE IncidentID = " + I.IncidentID;

                thisADO.updateOrInsert(strSQL, false);

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        
        [HttpGet]
        [Route("api/InsuranceIncidents/getManagerRecomendation/")]
        public List<ManagerRecomendation> getManagerRecomendation()
        {
            clsADO thisADO = new clsADO();
            string strSQL = null;

            try
            {
                strSQL = "Select ManagerRecomendationID, ManagerRecomendationDesc from InsurancePCA.dbo.ManagerRecomendation";

                List<ManagerRecomendation> list = new List<ManagerRecomendation>();

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
