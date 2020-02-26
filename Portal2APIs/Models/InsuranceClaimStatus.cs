using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceClaimStatus
    {

        #region Constructors
        public InsuranceClaimStatus()
        {
        }
        #endregion
        #region Private Fields
        private int _ClaimStatusID;
        private string _ClaimStatusDesc;
        #endregion
        #region Public Properties
        public int ClaimStatusID
        {
            get { return _ClaimStatusID; }
            set { _ClaimStatusID = value; }
        }
        public string ClaimStatusDesc
        {
            get { return _ClaimStatusDesc; }
            set { _ClaimStatusDesc = value; }
        }
        #endregion
    }
}