using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Referral
    {

        #region Constructors
        public Referral()
        {
        }
        #endregion
        #region Private Fields
        private int _ReferralId;
        private Int64 _MemberId;
        private string _ReferralTypeName;
        private string _SentToEmail;
        private DateTime _RefferedDate;
        private DateTime _ReferralCompleteDate;
        private DateTime _SignedDate;
        private int _ReferralPointsAwarded;
        #endregion
        #region Public Properties
        public int ReferralId
        {
            get { return _ReferralId; }
            set { _ReferralId = value; }
        }
        public Int64 MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        public string ReferralTypeName
        {
            get { return _ReferralTypeName; }
            set { _ReferralTypeName = value; }
        }
        public string SentToEmail
        {
            get { return _SentToEmail; }
            set { _SentToEmail = value; }
        }
        public DateTime RefferedDate
        {
            get { return _RefferedDate; }
            set { _RefferedDate = value; }
        }
        public DateTime ReferralCompleteDate
        {
            get { return _ReferralCompleteDate; }
            set { _ReferralCompleteDate = value; }
        }
        public DateTime SignedDate
        {
            get { return _SignedDate; }
            set { _SignedDate = value; }
        }
        public int ReferralPointsAwarded
        {
            get { return _ReferralPointsAwarded; }
            set { _ReferralPointsAwarded = value; }
        }
        #endregion
    }
}