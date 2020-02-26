using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceClaimReceivable
    {

        #region Constructors
        public InsuranceClaimReceivable()
        {
        }
        #endregion
        #region Private Fields
        private int _ClaimReceivableID;
        private int _ClaimID;
        private string _ClaimReceivablePayor;
        private string _ClaimReceivableCheckNumber;
        private object _ClaimReceivableCheckAmount;
        #endregion
        #region Public Properties
        public int ClaimReceivableID
        {
            get { return _ClaimReceivableID; }
            set { _ClaimReceivableID = value; }
        }
        public int ClaimID
        {
            get { return _ClaimID; }
            set { _ClaimID = value; }
        }
        public string ClaimReceivablePayor
        {
            get { return _ClaimReceivablePayor; }
            set { _ClaimReceivablePayor = value; }
        }
        public string ClaimReceivableCheckNumber
        {
            get { return _ClaimReceivableCheckNumber; }
            set { _ClaimReceivableCheckNumber = value; }
        }
        public object ClaimReceivableCheckAmount
        {
            get { return _ClaimReceivableCheckAmount; }
            set { _ClaimReceivableCheckAmount = value; }
        }
        #endregion
    }
}