using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class VehiclePartSupplier
    {

        #region Constructors
        public VehiclePartSupplier()
        {
        }
        #endregion
        #region Private Fields
        private int _PartSupplierId;
        private string _PartSupplierName;
        private object _EnteredByUserId;
        private DateTime _DateTimeEntered;
        private int _SortBy;
        #endregion
        #region Public Properties
        public int PartSupplierId
        {
            get { return _PartSupplierId; }
            set { _PartSupplierId = value; }
        }
        public string PartSupplierName
        {
            get { return _PartSupplierName; }
            set { _PartSupplierName = value; }
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
        public int SortBy
        {
            get { return _SortBy; }
            set { _SortBy = value; }
        }
        #endregion
    }
}