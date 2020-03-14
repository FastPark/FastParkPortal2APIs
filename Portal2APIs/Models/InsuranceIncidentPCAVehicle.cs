using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceIncidentPCAVehicle
    {

        #region Constructors
        public InsuranceIncidentPCAVehicle()
        {
        }
        #endregion
        #region Private Fields
        private int _IncidentPCAVehicleID;
        private int _ClaimID;
        private int _VehicleID;
        private string _DriverName;
        private string _DriverLicenseNumber;
        private int _Injuries;
        private string _TagNumber;
        private int _TagStateID;
        private string _PoliceReportNumber;
        private object _PCAReceivedClaimDate;
        
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
        public int VehicleID
        {
            get { return _VehicleID; }
            set { _VehicleID = value; }
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
        public string TagNumber
        {
            get { return _TagNumber; }
            set { _TagNumber = value; }
        }
        public int TagStateID
        {
            get { return _TagStateID; }
            set { _TagStateID = value; }
        }
        public object PCAReceivedClaimDate
        {
            get { return _PCAReceivedClaimDate; }
            set { _PCAReceivedClaimDate = value; }
        }
        public string PoliceReportNumber
        {
            get { return _PoliceReportNumber; }
            set { _PoliceReportNumber = value; }
        }
        
        #endregion
    }
}