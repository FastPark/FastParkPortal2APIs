using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MarketingCodeObject
    {

        #region Constructors
        public MarketingCodeObject()
        {
        }
        #endregion
        #region Private Fields
        private int _MarketingCodeId;
        private string _MarketingCode;
        private DateTime _StartDate;
        private Int32 _Active;
        private string _RepID;
        private string _BIUserID;
        private string _Notes;
        private string _ShortNotes;
        private DateTime _CreateDatetime;
        private Int64 _CreateUserId;
        private DateTime _UpdateDatetime;
        private Int64 _UpdateUserId;
        private Int32 _IsDeleted;
        private string _CreateExternalUserData;
        private string _UpdateExternalUserData;
        #endregion
        #region Public Properties
        public int MarketingCodeId
        {
            get { return _MarketingCodeId; }
            set { _MarketingCodeId = value; }
        }
        public string MarketingCode
        {
            get { return _MarketingCode; }
            set { _MarketingCode = value; }
        }
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        public Int32 Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public string RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }
        public string BIUserID
        {
            get { return _BIUserID; }
            set { _BIUserID = value; }
        }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        public string ShortNotes
        {
            get { return _ShortNotes; }
            set { _ShortNotes = value; }
        }
        public DateTime CreateDatetime
        {
            get { return _CreateDatetime; }
            set { _CreateDatetime = value; }
        }
        public Int64 CreateUserId
        {
            get { return _CreateUserId; }
            set { _CreateUserId = value; }
        }
        public DateTime UpdateDatetime
        {
            get { return _UpdateDatetime; }
            set { _UpdateDatetime = value; }
        }
        public Int64 UpdateUserId
        {
            get { return _UpdateUserId; }
            set { _UpdateUserId = value; }
        }
        public Int32 IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }
        public string CreateExternalUserData
        {
            get { return _CreateExternalUserData; }
            set { _CreateExternalUserData = value; }
        }
        public string UpdateExternalUserData
        {
            get { return _UpdateExternalUserData; }
            set { _UpdateExternalUserData = value; }
        }
        #endregion
    }
}