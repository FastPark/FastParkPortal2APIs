using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class PendingClaimStatus
    {

        #region Constructors
        public PendingClaimStatus()
        {
        }
        #endregion
        #region Private Fields
        private int _PendingClaimStatusID;
        private string _PendingClaimStatusDesc;
        #endregion
        #region Public Properties
        public int PendingClaimStatusID
        {
            get { return _PendingClaimStatusID; }
            set { _PendingClaimStatusID = value; }
        }
        public string PendingClaimStatusDesc
        {
            get { return _PendingClaimStatusDesc; }
            set { _PendingClaimStatusDesc = value; }
        }
        #endregion
    }
}