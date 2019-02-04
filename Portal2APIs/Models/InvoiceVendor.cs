using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InvoiceVendor
    {

        #region Constructors
        public InvoiceVendor()
        {
        }
        #endregion
        #region Private Fields
        private int _VendorId;
        private string _VendorName;
        private int _LocationId;
        #endregion
        #region Public Properties
        public int VendorId
        {
            get { return _VendorId; }
            set { _VendorId = value; }
        }
        public string VendorName
        {
            get { return _VendorName; }
            set { _VendorName = value; }
        }
        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }
        #endregion
    }
}