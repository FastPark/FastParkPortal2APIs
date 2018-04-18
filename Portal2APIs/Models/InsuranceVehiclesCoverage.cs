using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceVehiclesCoverage
    {
        #region Constructors
        public InsuranceVehiclesCoverage()
        {
        }
        #endregion
        #region Private Fields
        private int _VehicleCoverageId;
        private string _VehicleCoveragename;
        #endregion

        #region Public Properties

        public int VehicleCoverageId
        {
            get { return _VehicleCoverageId; }
            set { _VehicleCoverageId = value; }
        }
        public string VehicleCoveragename
        {
            get { return _VehicleCoveragename; }
            set { _VehicleCoveragename = value; }
        }
        #endregion
    }
}