using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class VehicleTracking
    {

        #region Constructors
        public VehicleTracking()
        {
        }
        #endregion
        #region Private Fields
        private int _VehicleDailyTrackingId;
        private string _VehicleNumber;
        private int _VehicleId;
        private DateTime _TrackingDate;
        private object _StartingMileage;
        private object _EndingMileage;
        private object _StartingEngineHours;
        private object _EndingEngineHours;
        private object _FuelTotal;
        private object _FuelPrice;
        private string _Notes;
        private object _EnteredByUserId;
        private DateTime _DateTimeEntered;
        private object _DailyMileage;
        private object _DailyHours;
        private int _LocationId;
        #endregion
        #region Public Properties
        public int VehicleDailyTrackingId
        {
            get { return _VehicleDailyTrackingId; }
            set { _VehicleDailyTrackingId = value; }
        }
        public string VehicleNumber
        {
            get { return _VehicleNumber; }
            set { _VehicleNumber = value; }
        }
        public int VehicleId
        {
            get { return _VehicleId; }
            set { _VehicleId = value; }
        }
        public DateTime TrackingDate
        {
            get { return _TrackingDate; }
            set { _TrackingDate = value; }
        }
        public object StartingMileage
        {
            get { return _StartingMileage; }
            set { _StartingMileage = value; }
        }
        public object EndingMileage
        {
            get { return _EndingMileage; }
            set { _EndingMileage = value; }
        }
        public object StartingEngineHours
        {
            get { return _StartingEngineHours; }
            set { _StartingEngineHours = value; }
        }
        public object EndingEngineHours
        {
            get { return _EndingEngineHours; }
            set { _EndingEngineHours = value; }
        }
        public object FuelTotal
        {
            get { return _FuelTotal; }
            set { _FuelTotal = value; }
        }
        public object FuelPrice
        {
            get { return _FuelPrice; }
            set { _FuelPrice = value; }
        }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        public object EnteredByUserId
        {
            get { return _EnteredByUserId; }
            set { _EnteredByUserId = value; }
        }
        public DateTime DateTimeEntered
        {
            get { return _DateTimeEntered; }
            set { _DateTimeEntered = value; }
        }
        public object DailyMileage
        {
            get { return _DailyMileage; }
            set { _DailyMileage = value; }
        }
        public object DailyHours
        {
            get { return _DailyHours; }
            set { _DailyHours = value; }
        }
        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }
        #endregion
        
    }
}