using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class VehicleMaintenancePackages
    {

        #region Constructors
        #endregion
        #region Private Fields
        private int _PackageId;
        private string _PackageName;
        private string _PackageDescription;
        private int _AirportId;
        private int _ModelId;
        private string _Notes;
        private object _EnteredBy;
        private DateTime _DateCreated;
        private int _FuelTypeId;
        #endregion
        #region Public Properties
        public int PackageId
        {
            get { return _PackageId; }
            set { _PackageId = value; }
        }
        public string PackageName
        {
            get { return _PackageName; }
            set { _PackageName = value; }
        }
        public string PackageDescription
        {
            get { return _PackageDescription; }
            set { _PackageDescription = value; }
        }
        public int AirportId
        {
            get { return _AirportId; }
            set { _AirportId = value; }
        }
        public int ModelId
        {
            get { return _ModelId; }
            set { _ModelId = value; }
        }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        public object EnteredBy
        {
            get { return _EnteredBy; }
            set { _EnteredBy = value; }
        }
        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }
        public int FuelTypeId
        {
            get { return _FuelTypeId; }
            set { _FuelTypeId = value; }
        }
        #endregion
    }
}