using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Vehicle
    {

        #region Constructors
        public Vehicle()
        {
        }

        #endregion
        #region Private Fields
        private int _VehicleId;
        private string _VehicleNumber;
        private string _VINNumber;
        private int _StatusId;
        private DateTime _ActiveDate;
        private DateTime _InactiveDate;
        private int _Year;
        private int _ModelId;
        private int _FuelTypeId;
        private string _GrossWeight;
        private string _PassengerRating;
        private bool _HandicapAccessible;
        private int _BilledLocationId;
        private int _CurrentLocationId;
        private bool _NeedsMaintenanceTracking;
        private bool _NeedsVehicleDailyTracking;
        private int _DriverId;
        private bool _ShowInList;
        private string _Notes;
        private object _CreatedByUserId;
        private DateTime _CreatedDateTime;
        private int _Mileage;
        private int _Hours;
        private string _MakeName;
        private string _ModelName;
        private DateTime _MileageDate;
        private string _RegistrationNumber;
        private int _StateRegisteredId;
        #endregion
        #region Public Properties
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
        public string VINNumber
        {
            get { return _VINNumber; }
            set { _VINNumber = value; }
        }
        public int StatusId
        {
            get { return _StatusId; }
            set { _StatusId = value; }
        }
        public DateTime ActiveDate
        {
            get { return _ActiveDate; }
            set { _ActiveDate = value; }
        }
        public DateTime InactiveDate
        {
            get { return _InactiveDate; }
            set { _InactiveDate = value; }
        }
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        public int ModelId
        {
            get { return _ModelId; }
            set { _ModelId = value; }
        }
        public int FuelTypeId
        {
            get { return _FuelTypeId; }
            set { _FuelTypeId = value; }
        }
        public string GrossWeight
        {
            get { return _GrossWeight; }
            set { _GrossWeight = value; }
        }
        public string PassengerRating
        {
            get { return _PassengerRating; }
            set { _PassengerRating = value; }
        }
        public bool HandicapAccessible
        {
            get { return _HandicapAccessible; }
            set { _HandicapAccessible = value; }
        }
        public int BilledLocationId
        {
            get { return _BilledLocationId; }
            set { _BilledLocationId = value; }
        }
        public int CurrentLocationId
        {
            get { return _CurrentLocationId; }
            set { _CurrentLocationId = value; }
        }
        public bool NeedsMaintenanceTracking
        {
            get { return _NeedsMaintenanceTracking; }
            set { _NeedsMaintenanceTracking = value; }
        }
        public bool NeedsVehicleDailyTracking
        {
            get { return _NeedsVehicleDailyTracking; }
            set { _NeedsVehicleDailyTracking = value; }
        }
        public int DriverId
        {
            get { return _DriverId; }
            set { _DriverId = value; }
        }
        public bool ShowInList
        {
            get { return _ShowInList; }
            set { _ShowInList = value; }
        }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        public object CreatedByUserId
        {
            get { return _CreatedByUserId; }
            set { _CreatedByUserId = value; }
        }
        public DateTime CreatedDateTime
        {
            get { return _CreatedDateTime; }
            set { _CreatedDateTime = value; }
        }
        public int Mileage
        {
            get { return _Mileage; }
            set { _Mileage = value; }
        }
        public string MakeName
        {
            get { return _MakeName; }
            set { _MakeName = value; }
        }
        public int Hours
        {
            get { return _Hours; }
            set { _Hours = value; }
        }
        public string ModelName
        {
            get { return _ModelName; }
            set { _ModelName = value; }
        }
        public DateTime MileageDate
        {
            get { return _MileageDate; }
            set { _MileageDate = value; }
        }
        public string RegistrationNumber
        {
            get { return _RegistrationNumber; }
            set { _RegistrationNumber = value; }
        }
        public int StateRegisteredId
        {
            get { return _StateRegisteredId; }
            set { _StateRegisteredId = value; }
        }
        #endregion
    }
}