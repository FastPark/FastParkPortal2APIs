using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class PCAVehicleClaim
    {

        #region Constructors
        public PCAVehicleClaim()
        {
        }
        #endregion
        #region Private Fields
        private int _IncidentPCAVehicleID;
        private int _ClaimID;
        private string _VehicleNumber;
        private int _VehicleID;
        private string _DriverName;
        private string _DriverLicenseNumber;
        private int _Year;
        private string _MakeName;
        private string _VINNumber;
        private string _ModelName;
        private string _ClaimNumber;
        private string _TagNumber;
        private string _TagState;
        private int _TagStateID;
        private int _Injuries;
        private string _StateAbbreviation;
        #endregion
        #region Public Properties
        public int IncidentPCAVehicleID
        {
            get { return _IncidentPCAVehicleID; }
            set { _IncidentPCAVehicleID = value; }
        }
        public int ClaimID
        {
            get { return _ClaimID; }
            set { _ClaimID = value; }
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
        public string DriverLicenseNumber
        {
            get { return _DriverLicenseNumber; }
            set { _DriverLicenseNumber = value; }
        }
        public int Injuries
        {
            get { return _Injuries; }
            set { _Injuries = value; }
        }
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        public string MakeName
        {
            get { return _MakeName; }
            set { _MakeName = value; }
        }
        public string VINNumber
        {
            get { return _VINNumber; }
            set { _VINNumber = value; }
        }
        public string ModelName
        {
            get { return _ModelName;  }
            set { _ModelName = value; }
        }
        public string ClaimNumber
        {
            get { return _ClaimNumber; }
            set { _ClaimNumber = value; }
        }
        public string TagNumber
        {
            get { return _TagNumber; }
            set { _TagNumber = value; }
        }
        public string TagState
        {
            get { return _TagState; }
            set { _TagState = value; }
        }
        public string StateAbbreviation
        {
            get { return _StateAbbreviation; }
            set { _StateAbbreviation = value; }
        }
        public int VehicleID
        {
            get { return _VehicleID; }
            set { _VehicleID = value; }
        }
        public int TagStateID
        {
            get { return _TagStateID; }
            set { _TagStateID = value; }
        }
        #endregion
    }
}