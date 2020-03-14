using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ThirdPartyVehicleClaim
    {

        #region Constructors
        public ThirdPartyVehicleClaim()
        {
        }
        #endregion
        #region Private Fields
        private int _IncidentThirdPartyVehicleID;
        private int _ClaimID;
        private string _CustomerFirstName;
        private string _CustomerLastName;
        private string _CustomerName;
        private string _CustomerEmailAddress;
        private string _CustomerStreetAddress;
        private string _CustomerCity;
        private int _CustomerStateID;
        private string _CustomerZip;
        private string _CustomerPhoneMobile;
        private string _CustomerPhoneHome;
        private string _CustomerDriverLicenseNumber;
        private string _CustomerState;
        private string _InsuranceCompany;
        private string _InsCompAddress;
        private string _InsCompPhone;
        private string _InsCompAgentName;
        private string _InsCompEmailAddress;
        private string _InsCompPolicyNumber;
        private string _VehicleYear;
        private string _VehicleMake;
        private string _VehicleModel;
        private string _VehicleColor;
        private string _VehicleVIN;
        private string _VehicleLicensePlate;
        private string _VehicleLicensePlateState;
        private int _VehicleLicensePlateStateID;
        private int _Injuries;
        #endregion
        #region Public Properties
        public int IncidentThirdPartyVehicleID
        {
            get { return _IncidentThirdPartyVehicleID; }
            set { _IncidentThirdPartyVehicleID = value; }
        }
        public int ClaimID
        {
            get { return _ClaimID; }
            set { _ClaimID = value; }
        }
        public string CustomerFirstName
        {
            get { return _CustomerFirstName; }
            set { _CustomerFirstName = value; }
        }
        public string CustomerLastName
        {
            get { return _CustomerLastName; }
            set { _CustomerLastName = value; }
        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        public string CustomerEmailAddress
        {
            get { return _CustomerEmailAddress; }
            set { _CustomerEmailAddress = value; }
        }
        public string CustomerStreetAddress
        {
            get { return _CustomerStreetAddress; }
            set { _CustomerStreetAddress = value; }
        }
        public string CustomerCity
        {
            get { return _CustomerCity; }
            set { _CustomerCity = value; }
        }
        public int CustomerStateID
        {
            get { return _CustomerStateID; }
            set { _CustomerStateID = value; }
        }
        public string CustomerZip
        {
            get { return _CustomerZip; }
            set { _CustomerZip = value; }
        }
        public string CustomerState
        {
            get { return _CustomerState; }
            set { _CustomerState = value; }
        }
        public string CustomerPhoneMobile
        {
            get { return _CustomerPhoneMobile; }
            set { _CustomerPhoneMobile = value; }
        }
        public string CustomerPhoneHome
        {
            get { return _CustomerPhoneHome; }
            set { _CustomerPhoneHome = value; }
        }
        public string CustomerDriverLicenseNumber
        {
            get { return _CustomerDriverLicenseNumber; }
            set { _CustomerDriverLicenseNumber = value; }
        }
        public string InsuranceCompany
        {
            get { return _InsuranceCompany; }
            set { _InsuranceCompany = value; }
        }
        public string InsCompAddress
        {
            get { return _InsCompAddress; }
            set { _InsCompAddress = value; }
        }
        public string InsCompPhone
        {
            get { return _InsCompPhone; }
            set { _InsCompPhone = value; }
        }
        public string InsCompAgentName
        {
            get { return _InsCompAgentName; }
            set { _InsCompAgentName = value; }
        }
        public string InsCompEmailAddress
        {
            get { return _InsCompEmailAddress; }
            set { _InsCompEmailAddress = value; }
        }
        public string InsCompPolicyNumber
        {
            get { return _InsCompPolicyNumber; }
            set { _InsCompPolicyNumber = value; }
        }
        public string VehicleYear
        {
            get { return _VehicleYear; }
            set { _VehicleYear = value; }
        }
        public string VehicleMake
        {
            get { return _VehicleMake; }
            set { _VehicleMake = value; }
        }
        public string VehicleModel
        {
            get { return _VehicleModel; }
            set { _VehicleModel = value; }
        }
        public string VehicleColor
        {
            get { return _VehicleColor; }
            set { _VehicleColor = value; }
        }
        public string VehicleVIN
        {
            get { return _VehicleVIN; }
            set { _VehicleVIN = value; }
        }
        public string VehicleLicensePlate
        {
            get { return _VehicleLicensePlate; }
            set { _VehicleLicensePlate = value; }
        }
        public string VehicleLicensePlateState
        {
            get { return _VehicleLicensePlateState; }
            set { _VehicleLicensePlateState = value; }
        }
        public int VehicleLicensePlateStateID
        {
            get { return _VehicleLicensePlateStateID; }
            set { _VehicleLicensePlateStateID = value; }
        }
        public int Injuries
        {
            get { return _Injuries; }
            set { _Injuries = value; }
        }
        #endregion
    }
}