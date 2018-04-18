using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsVehicles
    {

        #region Constructors
        public InsVehicles()
        {
        }
        #endregion
        #region Private Fields
        private int _VehicleId;
        private string _StatusDescription;
        private string _VehicleNumber;
        private int _Year;
        private string _MakeName;
        private string _ModelName;
        private string _VINNumber;
        private string _Garaged;
        private object _OriginalCost;
        private string _Class;
        private string _Coverage;
        private int _CoverageCode;
        private string _DriverName;
        private DateTime _ChangeDate;	
	    private string _ChangeNotes;	
	    private DateTime _AddDate;	
	    private DateTime _DeleteDate;	
	    private string _Insurance;
        private int _InsuranceCode;
        private object _CoverageAdded;
        private object _CoverageRemoved;
        private string _State;

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
        public string StatusDescription
        {
            get { return _StatusDescription; }
            set { _StatusDescription = value; }
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
        public string ModelName
        {
            get { return _ModelName; }
            set { _ModelName = value; }
        }
        public string VINNumber
        {
            get { return _VINNumber; }
            set { _VINNumber = value; }
        }
        public string Garaged
        {
            get { return _Garaged; }
            set { _Garaged = value; }
        }
        public object OriginalCost
        {
            get { return _OriginalCost; }
            set { _OriginalCost = value; }
        }
        public string Class
        {
            get { return _Class; }
            set { _Class = value; }
        }
        public string Coverage
        {
            get { return _Coverage; }
            set { _Coverage = value; }
        }
        public int CoverageCode
        {
            get { return _CoverageCode; }
            set { _CoverageCode = value; }
        }
        public string DriverName
        {
            get { return _DriverName; }
            set { _DriverName = value; }
        }
        public DateTime ChangeDate
	    {
		    get { return _ChangeDate; }
            set { _ChangeDate = value; }
	    }
	    public string ChangeNotes
	    {
		    get { return _ChangeNotes; }
		    set { _ChangeNotes = value; }
	    }
	    public DateTime AddDate
	    {
		    get { return _AddDate; }
		    set { _AddDate = value; }
	    }
	    public DateTime DeleteDate
	    {
		    get { return _DeleteDate; }
		    set { _DeleteDate = value; }
	    }
	    public string Insurance
        {
            get { return _Insurance; }
            set { _Insurance = value; }
        }
        public int InsuranceCode
        {
            get { return _InsuranceCode; }
            set { _InsuranceCode = value; }
        }
        public object CoverageAdded
        {
            get { return _CoverageAdded; }
            set { _CoverageAdded = value; }
        }
        public object CoverageRemoved
        {
            get { return _CoverageRemoved; }
            set { _CoverageRemoved = value; }
        }
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        #endregion
    }
}