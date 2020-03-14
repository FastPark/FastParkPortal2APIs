using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceWCClaimNote
    {

        #region Constructors
        public InsuranceWCClaimNote()
        {
        }
        #endregion
        #region Private Fields
        private int _WCClaimNoteID;
        private int _WCClaimID;
        private string _WCClaimNoteContent;
        private DateTime _WCClaimNoteDate;
        private string _WCClaimEnteredBy;
        #endregion
        #region Public Properties
        public int WCClaimNoteID
        {
            get { return _WCClaimNoteID; }
            set { _WCClaimNoteID = value; }
        }
        public int WCClaimID
        {
            get { return _WCClaimID; }
            set { _WCClaimID = value; }
        }
        public string WCClaimNoteContent
        {
            get { return _WCClaimNoteContent; }
            set { _WCClaimNoteContent = value; }
        }
        public DateTime WCClaimNoteDate
        {
            get { return _WCClaimNoteDate; }
            set { _WCClaimNoteDate = value; }
        }
        public string WCClaimEnteredBy
        {
            get { return _WCClaimEnteredBy; }
            set { _WCClaimEnteredBy = value; }
        }
        #endregion
    }
}