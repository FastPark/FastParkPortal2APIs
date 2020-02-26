using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceLocation
    {

        #region Constructors
        public InsuranceLocation()
        {
        }
        #endregion
        #region Private Fields
        private int _LocationID;
        private string _LocationName;
        private string _LocationGLCode;
        private int _VehicleLocationId;
        private string _LocationAddress;
        private int _LocationCityID;
        private string _LocationZip;
        private string _LocationPhone;
        private int _LocationStateID;
        private string _LocationFax;
        private int _FacilityManagerID;
        private string _FacilityManager;
        private string _City;
        private string _StateAbbreviation;
        #endregion
        #region Public Properties
        public int LocationID
        {
            get { return _LocationID; }
            set { _LocationID = value; }
        }
        public string LocationName
        {
            get { return _LocationName; }
            set { _LocationName = value; }
        }
        public string LocationGLCode
        {
            get { return _LocationGLCode; }
            set { _LocationGLCode = value; }
        }
        public int VehicleLocationId
        {
            get { return _VehicleLocationId; }
            set { _VehicleLocationId = value; }
        }
        public string LocationAddress
        {
            get { return _LocationAddress; }
            set { _LocationAddress = value; }
        }
        public int LocationCityID
        {
            get { return _LocationCityID; }
            set { _LocationCityID = value; }
        }
        public string LocationZip
        {
            get { return _LocationZip; }
            set { _LocationZip = value; }
        }
        public string LocationPhone
        {
            get { return _LocationPhone; }
            set { _LocationPhone = value; }
        }
        public int LocationStateID
        {
            get { return _LocationStateID; }
            set { _LocationStateID = value; }
        }
        public string LocationFax
        {
            get { return _LocationFax; }
            set { _LocationFax = value; }
        }
        public int FacilityManagerID
        {
            get { return _FacilityManagerID; }
            set { _FacilityManagerID = value; }
        }
        public string FacilityManager
        {
            get { return _FacilityManager; }
            set { _FacilityManager = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string StateAbbreviation
        {
            get { return _StateAbbreviation; }
            set { _StateAbbreviation = value; }
        }
        #endregion
    }
}