using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceClaim
    {

        #region Constructors
        public InsuranceClaim()
        {
        }
        #endregion
        #region Private Fields
        private int _ClaimID;
        private string _ClaimNumber;
        private string _IncidentNumber;
        private int _IncidentID;
        private int _ClaimTypeID;
        private int _PolicyTypeID;
        private int _ClaimStatusID;
        private object _ClaimStatusDate;
        private object _IncidentReceivedDate;
        private object _RepFollowUpDate;
        private string _PCAInsuranceClaimNumber;
        private string _OtherInsuranceClaimNumber;
        private int _PCARepID;
        private decimal _PaidByInsurance;
        private decimal _PaidByThridPartyInsurance;
        private decimal _PCADeductible;
        private decimal _PCAOutOfPocket;
        private decimal _EmployeePaid;
        private decimal _MonthlyAllocation;
        private int _PendingStatusID;
        private string _VehicleNumber;
        private string _DriverName;
        private string _CustomerName;
        private object _IncidentDate;
        private int _LocationID;
        private string _PoliceReportNumber;
        private string _IncidentLocationName;
        private decimal _Reserve;
        private int _EmployeeEnvolvedClaimID;
        private int _ClaimantNameClaimID;
        private string _ClaimantName;

        #endregion
        #region Public Properties
        public int ClaimID
        {
            get { return _ClaimID; }
            set { _ClaimID = value; }
        }
        public string ClaimNumber
        {
            get { return _ClaimNumber; }
            set { _ClaimNumber = value; }
        }
        public string IncidentNumber
        {
            get { return _IncidentNumber; }
            set { _IncidentNumber = value; }
        }
        public int IncidentID
        {
            get { return _IncidentID; }
            set { _IncidentID = value; }
        }
        public int ClaimTypeID
        {
            get { return _ClaimTypeID; }
            set { _ClaimTypeID = value; }
        }
        public int PolicyTypeID
        {
            get { return _PolicyTypeID; }
            set { _PolicyTypeID = value; }
        }
        public string ClaimantName
        {
            get { return _ClaimantName; }
            set { _ClaimantName = value; }
        }
        public int ClaimStatusID
        {
            get { return _ClaimStatusID; }
            set { _ClaimStatusID = value; }
        }
        public object ClaimStatusDate
        {
            get { return _ClaimStatusDate; }
            set { _ClaimStatusDate = value; }
        }
        public object RepFollowUpDate
        {
            get { return _RepFollowUpDate; }
            set { _RepFollowUpDate = value; }
        }
        public string PCAInsuranceClaimNumber
        {
            get { return _PCAInsuranceClaimNumber; }
            set { _PCAInsuranceClaimNumber = value; }
        }
        public string OtherInsuranceClaimNumber
        {
            get { return _OtherInsuranceClaimNumber; }
            set { _OtherInsuranceClaimNumber = value; }
        }
        public int PCARepID
        {
            get { return _PCARepID; }
            set { _PCARepID = value; }
        }
        public decimal PaidByInsurance
        {
            get { return _PaidByInsurance; }
            set { _PaidByInsurance = value; }
        }
        public decimal PaidByThridPartyInsurance
        {
            get { return _PaidByThridPartyInsurance; }
            set { _PaidByThridPartyInsurance = value; }
        }
        public decimal PCADeductible
        {
            get { return _PCADeductible; }
            set { _PCADeductible = value; }
        }
        public decimal PCAOutOfPocket
        {
            get { return _PCAOutOfPocket; }
            set { _PCAOutOfPocket = value; }
        }
        public decimal EmployeePaid
        {
            get { return _EmployeePaid; }
            set { _EmployeePaid = value; }
        }
        public int PendingStatusID
        {
            get { return _PendingStatusID; }
            set { _PendingStatusID = value; }
        }
        public string VehicleNumber
        {
            get { return _VehicleNumber; }
            set { _VehicleNumber = value; }
        }
        public string DriverName
        {
            get { return _DriverName; }
            set { _DriverName = value; }
        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        public object IncidentDate
        {
            get { return _IncidentDate; }
            set { _IncidentDate = value; }
        }
        public int LocationID
        {
            get { return _LocationID; }
            set { _LocationID = value; }
        }
        public string PoliceReportNumber
        {
            get { return _PoliceReportNumber; }
            set { _PoliceReportNumber = value; }
        }
        public string IncidentLocationName
        {
            get { return _IncidentLocationName; }
            set { _IncidentLocationName = value; }
        }
        public decimal MonthlyAllocation
        {
            get { return _MonthlyAllocation; }
            set { _MonthlyAllocation = value; }
        }
        public decimal Reserve
        {
            get { return _Reserve; }
            set { _Reserve = value; }
        }
        public int EmployeeEnvolvedClaimID
        {
            get { return _EmployeeEnvolvedClaimID; }
            set { _EmployeeEnvolvedClaimID = value; }
        }
        public int ClaimantNameClaimID
        {
            get { return _ClaimantNameClaimID; }
            set { _ClaimantNameClaimID = value; }
        }
        public object IncidentReceivedDate
        {
            get { return _IncidentReceivedDate; }
            set { _IncidentReceivedDate = value; }
        }
        #endregion
    }
}