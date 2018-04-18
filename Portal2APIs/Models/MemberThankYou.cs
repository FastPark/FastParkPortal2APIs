using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MemberThankYou
    {

        #region Constructors
        public MemberThankYou()
        {
        }
        #endregion
        #region Private Fields
        private int _MemberThankYouId;
        private int _MemberThankYouMemberId;
        private string _MemberThankYouUserId;
        private DateTime _MemberThankYouDate;
        #endregion
        #region Public Properties
        public int MemberThankYouId
        {
            get { return _MemberThankYouId; }
            set { _MemberThankYouId = value; }
        }
        public int MemberThankYouMemberId
        {
            get { return _MemberThankYouMemberId; }
            set { _MemberThankYouMemberId = value; }
        }
        public string MemberThankYouUserId
        {
            get { return _MemberThankYouUserId; }
            set { _MemberThankYouUserId = value; }
        }
        public DateTime MemberThankYouDate
        {
            get { return _MemberThankYouDate; }
            set { _MemberThankYouDate = value; }
        }
        #endregion
    }
}