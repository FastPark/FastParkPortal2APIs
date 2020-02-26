using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceClaimType
    {

        #region Constructors
        public InsuranceClaimType()
        {
        }
        #endregion
        #region Private Fields
        private int _ClaimTypeID;
        private string _ClaimTypeDesc;
        #endregion
        #region Public Properties
        public int ClaimTypeID
        {
            get { return _ClaimTypeID; }
            set { _ClaimTypeID = value; }
        }
        public string ClaimTypeDesc
        {
            get { return _ClaimTypeDesc; }
            set { _ClaimTypeDesc = value; }
        }
        #endregion
    }
}