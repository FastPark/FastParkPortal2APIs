using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceIncident
    {

        #region Constructors
        public InsuranceIncident()
        {
        }
        #endregion
        #region Private Fields
        private int _IncidentID;
        private string _IncidentNumber;
        private object _PCAReceiveDate;
        private int _LocationId;
        private int _LotID;
        private string _IncidentStreetAddress;
        private int _IncidentCityID;
        private string _IncidentCity;
        private int _IncidentStateID;
        private string _IncidentZip;
        private string _IncidentPhone;
        private string _IncidentLotRowSpace;
        private int _OperationTypeID;
        private DateTime _IncidentDate;
        private string _IncidentTime;
        private string _StayDuration;
        private int _IncidentInjuries;
        private string _PoliceReportNumber;
        private DateTime _PoliceReportDate;
        private string _OfficerName;
        private int _NumberOfVehilesInvolved;
        private int _PhysicalDamage;
        private string _PhysicalDamageDesc;
        private string _IncidentCreatedBy;
        private string _LotName;
        private string _LocationName;
        private string _LocState;
        private string _StateAbbreviation;
        private string _OperationTypeName;
        private int _IncidentStatusID;
        private string _IncidentStatus;
        private string _ClaimNumber;
        private string _ClaimStatusDesc;
        private string _ClaimantName;
        private string _PCAInsuranceClaimNumber;
        private string _WCClaimNumber;
        private string _IncidentCustomerSignature;
        private string _IncidentEmployeeSignature;
        private string _IncidentManagerSignature;
        private int _WCInvestigationID;
        private int _ClaimID;
        private int _Deleted;
        private string _FacilityManagerName;
        private string _Closed;
        private int _ClaimStatusID;
        private string _ViewSettings;

        #endregion
        #region Public Properties
        public int IncidentID
        {
            get { return _IncidentID; }
            set { _IncidentID = value; }
        }
        public string IncidentNumber
        {
            get { return _IncidentNumber; }
            set { _IncidentNumber = value; }
        }
        public object PCAReceiveDate
        {
            get { return _PCAReceiveDate; }
            set { _PCAReceiveDate = value; }
        }
        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }
        public int LotID
        {
            get { return _LotID; }
            set { _LotID = value; }
        }
        public string IncidentStreetAddress
        {
            get { return _IncidentStreetAddress; }
            set { _IncidentStreetAddress = value; }
        }
        public int IncidentCityID
        {
            get { return _IncidentCityID; }
            set { _IncidentCityID = value; }
        }
        public string IncidentCity
        {
            get { return _IncidentCity; }
            set { _IncidentCity = value; }
        }
        public int IncidentStateID
        {
            get { return _IncidentStateID; }
            set { _IncidentStateID = value; }
        }
        public string IncidentZip
        {
            get { return _IncidentZip; }
            set { _IncidentZip = value; }
        }
        public string IncidentPhone
        {
            get { return _IncidentPhone; }
            set { _IncidentPhone = value; }
        }
        public string IncidentLotRowSpace
        {
            get { return _IncidentLotRowSpace; }
            set { _IncidentLotRowSpace = value; }
        }
        public int OperationTypeID
        {
            get { return _OperationTypeID; }
            set { _OperationTypeID = value; }
        }
        public DateTime IncidentDate
        {
            get { return _IncidentDate; }
            set { _IncidentDate = value; }
        }
        public string IncidentTime
        {
            get { return _IncidentTime; }
            set { _IncidentTime = value; }
        }
        public string StayDuration
        {
            get { return _StayDuration; }
            set { _StayDuration = value; }
        }
        public int IncidentInjuries
        {
            get { return _IncidentInjuries; }
            set { _IncidentInjuries = value; }
        }
        public string PoliceReportNumber
        {
            get { return _PoliceReportNumber; }
            set { _PoliceReportNumber = value; }
        }
        public DateTime PoliceReportDate
        {
            get { return _PoliceReportDate; }
            set { _PoliceReportDate = value; }
        }
        public string OfficerName
        {
            get { return _OfficerName; }
            set { _OfficerName = value; }
        }
        public int NumberOfVehilesInvolved
        {
            get { return _NumberOfVehilesInvolved; }
            set { _NumberOfVehilesInvolved = value; }
        }
        public int PhysicalDamage
        {
            get { return _PhysicalDamage; }
            set { _PhysicalDamage = value; }
        }
        public string PhysicalDamageDesc
        {
            get { return _PhysicalDamageDesc; }
            set { _PhysicalDamageDesc = value; }
        }
        public string IncidentCreatedBy
        {
            get { return _IncidentCreatedBy; }
            set { _IncidentCreatedBy = value; }
        }
        public string LotName
        {
            get { return _LotName; }
            set { _LotName = value; }
        }
        public string LocationName
        {
            get { return _LocationName; }
            set { _LocationName = value; }
        }
        public string LocState
        {
            get { return _LocState; }
            set { _LocState = value; }
        }
        public string StateAbbreviation
        {
            get { return _StateAbbreviation; }
            set { _StateAbbreviation = value; }
        }
        public string OperationTypeName
        {
            get { return _OperationTypeName; }
            set { _OperationTypeName = value; }
        }
        public int IncidentStatusID
        {
            get { return _IncidentStatusID; }
            set { _IncidentStatusID = value; }
        }
        public string IncidentStatus
        {
            get { return _IncidentStatus; }
            set { _IncidentStatus = value; }
        }
        public string ClaimNumber
        {
            get { return _ClaimNumber; }
            set { _ClaimNumber = value; }
        }
        public string ClaimStatusDesc
        {
            get { return _ClaimStatusDesc; }
            set { _ClaimStatusDesc = value; }
        }
        public string ClaimantName
        {
            get { return _ClaimantName; }
            set { _ClaimantName = value; }
        }
        public string PCAInsuranceClaimNumber
        {
            get { return _PCAInsuranceClaimNumber; }
            set { _PCAInsuranceClaimNumber = value; }
        }
        public string WCClaimNumber
        {
            get { return _WCClaimNumber; }
            set { _WCClaimNumber = value; }
        }
        public string IncidentCustomerSignature
        {
            get { return _IncidentCustomerSignature; }
            set { _IncidentCustomerSignature = value; }
        }
        public string IncidentEmployeeSignature
        {
            get { return _IncidentEmployeeSignature; }
            set { _IncidentEmployeeSignature = value; }
        }
        public string IncidentManagerSignature
        {
            get { return _IncidentManagerSignature; }
            set { _IncidentManagerSignature = value; }
        }

        public int WCInvestigationID
        {
            get { return _WCInvestigationID; }
            set { _WCInvestigationID = value; }
        }
        public int ClaimID
        {
            get { return _ClaimID; }
            set { _ClaimID = value; }
        }
        public int Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; }
        }
        public string FacilityManagerName
        {
            get { return _FacilityManagerName; }
            set { _FacilityManagerName = value; }
        }
        public string Closed
        {
            get { return _Closed; }
            set { _Closed = value; }
        }

        public int ClaimStatusID
        {
            get { return _ClaimStatusID; }
            set { _ClaimStatusID = value; }
        }
        public string ViewSettings
        {
            get { return _ViewSettings; }
            set { _ViewSettings = value; }
        }
        #endregion
    }
}