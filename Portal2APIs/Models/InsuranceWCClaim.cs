using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceWCClaim
    {

        #region Constructors
        public InsuranceWCClaim()
        {
        }
        #endregion
        #region Private Fields
        private int _WCClaimID;
        private int _ClaimID;
        private string _WCClaimNumber;
        private int _WCInvestigationID;
        private object _WCIncidentDate;
        private object _ReportedToCarrierDate;
        private int _PolicyTypeID;
        private string _PCAInsuranceNumber;
        private int _WCClaimStatusID;
        private object _WCClaimStatusDate;
        private string _OSHALog;
        private int _DaysMissed;
        private int _NumberOfDaysMissed;
        private string _LiteRelease;
        private int _NumberOfLiteDutyDays;
        private object _FullReleaseDate;
        private object _ReturnedToWorkDate;
        private object _FollowUpApptDate;
        private int _ImpairmentRating;
        private int _Subro;
        private string _JobClass;
        private object _RepFollowUpDate;
        private int _ModifiedDutyRequired;
        private object _IndemnityCompPaid;
        private object _IndemnityCompReserve;
        private object _MedicalPaid;
        private object _MedicalReserve;
        private object _WCClaimExpensePaid;
        private object _WCExpenseReserve;
        private object _SubroAmount;
        private object _Settlement;
        private string _PoliceReportNumber;
        private object _PCAReceivedClaimDate;
        private int _PCARepID;
        private string _IncidentNumber;
        private string _ClaimantName;
        private int _LocationID;
        private int _Closed;
        private string _LocationName;
        #endregion
        #region Public Properties
        public int WCClaimID
        {
            get { return _WCClaimID; }
            set { _WCClaimID = value; }
        }
        public int ClaimID
        {
            get { return _ClaimID; }
            set { _ClaimID = value; }
        }
        public string WCClaimNumber
        {
            get { return _WCClaimNumber; }
            set { _WCClaimNumber = value; }
        }
        public int WCInvestigationID
        {
            get { return _WCInvestigationID; }
            set { _WCInvestigationID = value; }
        }
        public object WCIncidentDate
        {
            get { return _WCIncidentDate; }
            set { _WCIncidentDate = value; }
        }
        public object ReportedToCarrierDate
        {
            get { return _ReportedToCarrierDate; }
            set { _ReportedToCarrierDate = value; }
        }
        public int PolicyTypeID
        {
            get { return _PolicyTypeID; }
            set { _PolicyTypeID = value; }
        }
        public string PCAInsuranceNumber
        {
            get { return _PCAInsuranceNumber; }
            set { _PCAInsuranceNumber = value; }
        }
        public int WCClaimStatusID
        {
            get { return _WCClaimStatusID; }
            set { _WCClaimStatusID = value; }
        }
        public object WCClaimStatusDate
        {
            get { return _WCClaimStatusDate; }
            set { _WCClaimStatusDate = value; }
        }
        public string OSHALog
        {
            get { return _OSHALog; }
            set { _OSHALog = value; }
        }
        public int DaysMissed
        {
            get { return _DaysMissed; }
            set { _DaysMissed = value; }
        }
        public int NumberOfDaysMissed
        {
            get { return _NumberOfDaysMissed; }
            set { _NumberOfDaysMissed = value; }
        }
        public string LiteRelease
        {
            get { return _LiteRelease; }
            set { _LiteRelease = value; }
        }
        public int NumberOfLiteDutyDays
        {
            get { return _NumberOfLiteDutyDays; }
            set { _NumberOfLiteDutyDays = value; }
        }
        public object FullReleaseDate
        {
            get { return _FullReleaseDate; }
            set { _FullReleaseDate = value; }
        }
        public object ReturnedToWorkDate
        {
            get { return _ReturnedToWorkDate; }
            set { _ReturnedToWorkDate = value; }
        }
        public object FollowUpApptDate
        {
            get { return _FollowUpApptDate; }
            set { _FollowUpApptDate = value; }
        }
        public int ImpairmentRating
        {
            get { return _ImpairmentRating; }
            set { _ImpairmentRating = value; }
        }
        public int Subro
        {
            get { return _Subro; }
            set { _Subro = value; }
        }
        public string JobClass
        {
            get { return _JobClass; }
            set { _JobClass = value; }
        }
        public object RepFollowUpDate
        {
            get { return _RepFollowUpDate; }
            set { _RepFollowUpDate = value; }
        }
        public int ModifiedDutyRequired
        {
            get { return _ModifiedDutyRequired; }
            set { _ModifiedDutyRequired = value; }
        }
        public object IndemnityCompPaid
        {
            get { return _IndemnityCompPaid; }
            set { _IndemnityCompPaid = value; }
        }
        public object IndemnityCompReserve
        {
            get { return _IndemnityCompReserve; }
            set { _IndemnityCompReserve = value; }
        }
        public object MedicalPaid
        {
            get { return _MedicalPaid; }
            set { _MedicalPaid = value; }
        }
        public object MedicalReserve
        {
            get { return _MedicalReserve; }
            set { _MedicalReserve = value; }
        }
        public object WCClaimExpensePaid
        {
            get { return _WCClaimExpensePaid; }
            set { _WCClaimExpensePaid = value; }
        }
        public object WCExpenseReserve
        {
            get { return _WCExpenseReserve; }
            set { _WCExpenseReserve = value; }
        }
        public object SubroAmount
        {
            get { return _SubroAmount; }
            set { _SubroAmount = value; }
        }
        public object Settlement
        {
            get { return _Settlement; }
            set { _Settlement = value; }
        }
        public string PoliceReportNumber
        {
            get { return _PoliceReportNumber; }
            set { _PoliceReportNumber = value; }
        }
        public object PCAReceivedClaimDate
        {
            get { return _PCAReceivedClaimDate; }
            set { _PCAReceivedClaimDate = value; }
        }
        public int PCARepID
        {
            get { return _PCARepID; }
            set { _PCARepID = value; }
        }
        public string IncidentNumber
        {
            get { return _IncidentNumber; }
            set { _IncidentNumber = value; }
        }
        public string ClaimantName
        {
            get { return _ClaimantName; }
            set { _ClaimantName = value; }
        }
        public int LocationID
        {
            get { return _LocationID; }
            set { _LocationID = value; }
        }
        public int Closed
        {
            get { return _Closed; }
            set { _Closed = value; }
        }
        public string LocationName
        {
            get { return _LocationName; }
            set { _LocationName = value; }
        }
        #endregion
    }
}