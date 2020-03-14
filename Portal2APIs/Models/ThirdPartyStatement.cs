using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ThirdPartyStatement
    {

        #region Constructors
        public ThirdPartyStatement()
        {
        }
        #endregion
        #region Private Fields
        private int _ThirdPartyStatementID;
        private int _CustClaimID;
        private int _StayDuration;
        private string _LotRowSpace;
        private string _IncidentDesc;
        private string _ThirdPartySignature;
        private object _SignatureDate;
        #endregion
        #region Public Properties
        public int ThirdPartyStatementID
        {
            get { return _ThirdPartyStatementID; }
            set { _ThirdPartyStatementID = value; }
        }
        public int CustClaimID
        {
            get { return _CustClaimID; }
            set { _CustClaimID = value; }
        }
        public int StayDuration
        {
            get { return _StayDuration; }
            set { _StayDuration = value; }
        }
        public string LotRowSpace
        {
            get { return _LotRowSpace; }
            set { _LotRowSpace = value; }
        }
        public string IncidentDesc
        {
            get { return _IncidentDesc; }
            set { _IncidentDesc = value; }
        }
        public string ThirdPartySignature
        {
            get { return _ThirdPartySignature; }
            set { _ThirdPartySignature = value; }
        }
        public object SignatureDate
        {
            get { return _SignatureDate; }
            set { _SignatureDate = value; }
        }
        #endregion
    }
}