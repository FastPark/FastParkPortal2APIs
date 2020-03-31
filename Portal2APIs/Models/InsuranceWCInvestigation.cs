using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class WCInvestigation
    {

        #region Constructors
        public WCInvestigation()
        {
        }
        #endregion
        #region Private Fields
        private int _WCInvestigationID;
        private int _ClaimID;
        private string _EmployeeFirstName;
        private string _EmployeeLastName;
        private string _EmployeeAddress;
        private string _EmployeeCity;
        private int _EmployeeStateID;
        private string _EmployeeSS;
        private string _EmployeeHomePhone;
        private int _EmployeeSex;
        private int _EmployeeMaritalStatus;
        private object _EmployeeDOB;
        private int _EmployeeAge;
        private int _EmployeeNumberOfDependents;
        private int _RegularEmploymentLocationID;
        private int _RegularEmpoymentLotID;
        private object _EmployeeDateOfHire;
        private object _MissedWorkReturnDate;
        private int _RequiredToMissWork;
        private int _PaidForDayOfInjury;
        private object _EmployeeWageRate;
        private int _IncidentLocationWorkLength;
        private object _AveHoursWorkedPerDay;
        private int _AveDaysWorkedPerWeek;
        private int _NormalDaysOff;
        private int _InjuryLocationId;
        private DateTime _InjuryDateTime;
        private int _InjuryOnPremises;
        private string _InjuryLocation;
        private string _TimeShiftBegain;
        private object _EmployerNotifiedDate;
        private string _NotiefierName;
        private string _InjuryBodyPart;
        private string _InjuryNature;
        private string _InjuryCause;
        private string _ActioinBeforInjury;
        private int _AnyPriorHandicap;
        private string _HandicapDescription;
        private int _PropertyDamage;
        private string _PropertyDamageDescription;
        private int _SaftyEquipmentInvolved;
        private int _SaftyEquipmentUsed;
        private int _MedicalFacilityID;
        private string _FirstAidAdministered;
        private string _NameOfMedicalFacility;
        private string _NameOfTreatingPhysician;
        private string _PhoneOfTreatingPhysician;
        private int _DrugTest;
        private string _DrugTestFacility;
        private int _NoticesExplained;
        private string _CauseOfIllnessIncident;
        private int _CausePolicyInAffect;
        private string _PolicyInAffectDescription;
        private int _PolicyInAffectEmployeeAware;
        private string _PolicyInAffectHowNotified;
        private string _EmpoyeeComments;
        #endregion
        #region Public Properties
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
        public string EmployeeFirstName
        {
            get { return _EmployeeFirstName; }
            set { _EmployeeFirstName = value; }
        }
        public string EmployeeLastName
        {
            get { return _EmployeeLastName; }
            set { _EmployeeLastName = value; }
        }
        public string EmployeeAddress
        {
            get { return _EmployeeAddress; }
            set { _EmployeeAddress = value; }
        }
        public string EmployeeCity
        {
            get { return _EmployeeCity; }
            set { _EmployeeCity = value; }
        }
        public int EmployeeStateID
        {
            get { return _EmployeeStateID; }
            set { _EmployeeStateID = value; }
        }
        public string EmployeeSS
        {
            get { return _EmployeeSS; }
            set { _EmployeeSS = value; }
        }
        public string EmployeeHomePhone
        {
            get { return _EmployeeHomePhone; }
            set { _EmployeeHomePhone = value; }
        }
        public int EmployeeSex
        {
            get { return _EmployeeSex; }
            set { _EmployeeSex = value; }
        }
        public int EmployeeMaritalStatus
        {
            get { return _EmployeeMaritalStatus; }
            set { _EmployeeMaritalStatus = value; }
        }
        public object EmployeeDOB
        {
            get { return _EmployeeDOB; }
            set { _EmployeeDOB = value; }
        }
        public int EmployeeAge
        {
            get { return _EmployeeAge; }
            set { _EmployeeAge = value; }
        }
        public int EmployeeNumberOfDependents
        {
            get { return _EmployeeNumberOfDependents; }
            set { _EmployeeNumberOfDependents = value; }
        }
        public int RegularEmploymentLocationID
        {
            get { return _RegularEmploymentLocationID; }
            set { _RegularEmploymentLocationID = value; }
        }
        public int RegularEmpoymentLotID
        {
            get { return _RegularEmpoymentLotID; }
            set { _RegularEmpoymentLotID = value; }
        }
        public object EmployeeDateOfHire
        {
            get { return _EmployeeDateOfHire; }
            set { _EmployeeDateOfHire = value; }
        }
        public object MissedWorkReturnDate
        {
            get { return _MissedWorkReturnDate; }
            set { _MissedWorkReturnDate = value; }
        }
        public int RequiredToMissWork
        {
            get { return _RequiredToMissWork; }
            set { _RequiredToMissWork = value; }
        }
        public int PaidForDayOfInjury
        {
            get { return _PaidForDayOfInjury; }
            set { _PaidForDayOfInjury = value; }
        }
        public object EmployeeWageRate
        {
            get { return _EmployeeWageRate; }
            set { _EmployeeWageRate = value; }
        }
        public int IncidentLocationWorkLength
        {
            get { return _IncidentLocationWorkLength; }
            set { _IncidentLocationWorkLength = value; }
        }
        public object AveHoursWorkedPerDay
        {
            get { return _AveHoursWorkedPerDay; }
            set { _AveHoursWorkedPerDay = value; }
        }
        public int AveDaysWorkedPerWeek
        {
            get { return _AveDaysWorkedPerWeek; }
            set { _AveDaysWorkedPerWeek = value; }
        }
        public int NormalDaysOff
        {
            get { return _NormalDaysOff; }
            set { _NormalDaysOff = value; }
        }
        public int InjuryLocationId
        {
            get { return _InjuryLocationId; }
            set { _InjuryLocationId = value; }
        }
        public DateTime InjuryDateTime
        {
            get { return _InjuryDateTime; }
            set { _InjuryDateTime = value; }
        }
        public int InjuryOnPremises
        {
            get { return _InjuryOnPremises; }
            set { _InjuryOnPremises = value; }
        }
        public string InjuryLocation
        {
            get { return _InjuryLocation; }
            set { _InjuryLocation = value; }
        }
        public string TimeShiftBegain
        {
            get { return _TimeShiftBegain; }
            set { _TimeShiftBegain = value; }
        }
        public object EmployerNotifiedDate
        {
            get { return _EmployerNotifiedDate; }
            set { _EmployerNotifiedDate = value; }
        }
        public string NotiefierName
        {
            get { return _NotiefierName; }
            set { _NotiefierName = value; }
        }
        public string InjuryBodyPart
        {
            get { return _InjuryBodyPart; }
            set { _InjuryBodyPart = value; }
        }
        public string InjuryNature
        {
            get { return _InjuryNature; }
            set { _InjuryNature = value; }
        }
        public string InjuryCause
        {
            get { return _InjuryCause; }
            set { _InjuryCause = value; }
        }
        public string ActioinBeforInjury
        {
            get { return _ActioinBeforInjury; }
            set { _ActioinBeforInjury = value; }
        }
        public int AnyPriorHandicap
        {
            get { return _AnyPriorHandicap; }
            set { _AnyPriorHandicap = value; }
        }
        public string HandicapDescription
        {
            get { return _HandicapDescription; }
            set { _HandicapDescription = value; }
        }
        public int PropertyDamage
        {
            get { return _PropertyDamage; }
            set { _PropertyDamage = value; }
        }
        public string PropertyDamageDescription
        {
            get { return _PropertyDamageDescription; }
            set { _PropertyDamageDescription = value; }
        }
        public int SaftyEquipmentInvolved
        {
            get { return _SaftyEquipmentInvolved; }
            set { _SaftyEquipmentInvolved = value; }
        }
        public int SaftyEquipmentUsed
        {
            get { return _SaftyEquipmentUsed; }
            set { _SaftyEquipmentUsed = value; }
        }
        public int MedicalFacilityID
        {
            get { return _MedicalFacilityID; }
            set { _MedicalFacilityID = value; }
        }
        public string FirstAidAdministered
        {
            get { return _FirstAidAdministered; }
            set { _FirstAidAdministered = value; }
        }
        public string NameOfMedicalFacility
        {
            get { return _NameOfMedicalFacility; }
            set { _NameOfMedicalFacility = value; }
        }
        public string NameOfTreatingPhysician
        {
            get { return _NameOfTreatingPhysician; }
            set { _NameOfTreatingPhysician = value; }
        }
        public string PhoneOfTreatingPhysician
        {
            get { return _PhoneOfTreatingPhysician; }
            set { _PhoneOfTreatingPhysician = value; }
        }
        public int DrugTest
        {
            get { return _DrugTest; }
            set { _DrugTest = value; }
        }
        public string DrugTestFacility
        {
            get { return _DrugTestFacility; }
            set { _DrugTestFacility = value; }
        }
        public int NoticesExplained
        {
            get { return _NoticesExplained; }
            set { _NoticesExplained = value; }
        }
        public string CauseOfIllnessIncident
        {
            get { return _CauseOfIllnessIncident; }
            set { _CauseOfIllnessIncident = value; }
        }
        public int CausePolicyInAffect
        {
            get { return _CausePolicyInAffect; }
            set { _CausePolicyInAffect = value; }
        }
        public string PolicyInAffectDescription
        {
            get { return _PolicyInAffectDescription; }
            set { _PolicyInAffectDescription = value; }
        }
        public int PolicyInAffectEmployeeAware
        {
            get { return _PolicyInAffectEmployeeAware; }
            set { _PolicyInAffectEmployeeAware = value; }
        }
        public string PolicyInAffectHowNotified
        {
            get { return _PolicyInAffectHowNotified; }
            set { _PolicyInAffectHowNotified = value; }
        }
        public string EmpoyeeComments
        {
            get { return _EmpoyeeComments; }
            set { _EmpoyeeComments = value; }
        }
        #endregion
    }
}