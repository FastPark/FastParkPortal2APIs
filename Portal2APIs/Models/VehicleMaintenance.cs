using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class VehicleMaintenance
    {

        #region Constructors
        public VehicleMaintenance()
        {
        }
        #endregion
        #region Private Fields
        private int _VehicleMaintenanceId;
        private int _VehicleId;
        private string _WorkOrder;
        private DateTime _MaintenanceDate;
        private string _MaintenanceDescription;
        private object _PartsCost;
        private object _PartsTax;
        private int _MechanicId;
        private object _LaborCost;
        private string _Notes;
        private object _EnteredByUserId;
        private DateTime _DateTimeEntered;
        private int _PackageId;
        private bool _Deleted;
        private object _DeletedByUserId;
        private DateTime _DateTimeDeleted;
        private int _WarranyWork;
        private int _LocationId;
        private string _EnteredBy;
        private VehicleMaintenancePart[] _VehicleMaintenanceParts;
        #endregion
        #region Public Properties
        public int VehicleMaintenanceId
        {
            get { return _VehicleMaintenanceId; }
            set { _VehicleMaintenanceId = value; }
        }
        public int VehicleId
        {
            get { return _VehicleId; }
            set { _VehicleId = value; }
        }
        public string WorkOrder
        {
            get { return _WorkOrder; }
            set { _WorkOrder = value; }
        }
        public DateTime MaintenanceDate
        {
            get { return _MaintenanceDate; }
            set { _MaintenanceDate = value; }
        }
        public string MaintenanceDescription
        {
            get { return _MaintenanceDescription; }
            set { _MaintenanceDescription = value; }
        }
        public object PartsCost
        {
            get { return _PartsCost; }
            set { _PartsCost = value; }
        }
        public object PartsTax
        {
            get { return _PartsTax; }
            set { _PartsTax = value; }
        }
        public int MechanicId
        {
            get { return _MechanicId; }
            set { _MechanicId = value; }
        }
        public object LaborCost
        {
            get { return _LaborCost; }
            set { _LaborCost = value; }
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
        public int PackageId
        {
            get { return _PackageId; }
            set { _PackageId = value; }
        }
        public bool Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; }
        }
        public object DeletedByUserId
        {
            get { return _DeletedByUserId; }
            set { _DeletedByUserId = value; }
        }
        public DateTime DateTimeDeleted
        {
            get { return _DateTimeDeleted; }
            set { _DateTimeDeleted = value; }
        }
        public int WarranyWork
        {
            get { return _WarranyWork; }
            set { _WarranyWork = value; }
        }
        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }
        public string EnteredBy
        {
            get { return _EnteredBy; }
            set { _EnteredBy = value; }
        }
        public VehicleMaintenancePart[] VehicleMaintenanceParts
        {
            get { return _VehicleMaintenanceParts; }
            set { _VehicleMaintenanceParts = value; }
        }
        #endregion
    }
}