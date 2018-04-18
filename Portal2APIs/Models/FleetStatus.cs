using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class FleetStatus
    {

        #region Constructors
        public FleetStatus()
        {
        }
        #endregion
        #region Private Fields
        private int _FleetStatusID;
        private int _VehicleId;
        private string _VehicleNumber;
        private string _FrontACStatus;
        private string _RearACStatus;
        private object _LastExWash;
        private object _LastInExWash;
        private string _Status;
        private object _OOSDate;
        private object _EstReturn;
        private string _Notes;
        #endregion
        #region Public Properties
        public int FleetStatusID
        {
            get { return _FleetStatusID; }
            set { _FleetStatusID = value; }
        }
        public int VehicleId
        {
            get { return _VehicleId; }
            set { _VehicleId = value; }
        }
        public string VehicleNumber
        {
            get { return _VehicleNumber; }
            set { _VehicleNumber = value; }
        }
        public string FrontACStatus
        {
            get { return _FrontACStatus; }
            set { _FrontACStatus = value; }
        }
        public string RearACStatus
        {
            get { return _RearACStatus; }
            set { _RearACStatus = value; }
        }
        public object LastExWash
        {
            get { return _LastExWash; }
            set { _LastExWash = value; }
        }
        public object LastInExWash
        {
            get { return _LastInExWash; }
            set { _LastInExWash = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public object OOSDate
        {
            get { return _OOSDate; }
            set { _OOSDate = value; }
        }
        public object EstReturn
        {
            get { return _EstReturn; }
            set { _EstReturn = value; }
        }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        #endregion
    }
}