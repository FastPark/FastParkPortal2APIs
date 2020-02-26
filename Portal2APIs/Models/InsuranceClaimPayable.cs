using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceClaimPayable
    {

        #region Constructors
        public InsuranceClaimPayable()
        {
        }
        #endregion
        #region Private Fields
        private int _ClaimPayableID;
        private int _ClaimID;
        private string _ClaimPayablePayee;
        private string _ClaimPayableCheckNumber;
        private decimal _ClaimPayableCheckAmount;
        private object _ClaimPayableMailedDate;
        #endregion
        #region Public Properties
        public int ClaimPayableID
        {
            get { return _ClaimPayableID; }
            set { _ClaimPayableID = value; }
        }
        public int ClaimID
        {
            get { return _ClaimID; }
            set { _ClaimID = value; }
        }
        public string ClaimPayablePayee
        {
            get { return _ClaimPayablePayee; }
            set { _ClaimPayablePayee = value; }
        }
        public string ClaimPayableCheckNumber
        {
            get { return _ClaimPayableCheckNumber; }
            set { _ClaimPayableCheckNumber = value; }
        }
        public decimal ClaimPayableCheckAmount
        {
            get { return _ClaimPayableCheckAmount; }
            set { _ClaimPayableCheckAmount = value; }
        }
        public object ClaimPayableMailedDate
        {
            get { return _ClaimPayableMailedDate; }
            set { _ClaimPayableMailedDate = value; }
        }
        #endregion
    }
}