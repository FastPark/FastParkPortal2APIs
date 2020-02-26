using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceClaimNote
    {
        #region Constructors
        public InsuranceClaimNote()
        {
        }
        #endregion
        #region Private Fields
        private int _ClaimNoteID;
        private int _ClaimID;
        private string _ClaimNoteContent;
        private string _ClaimNoteEnteredBy;
        private object _ClaimNoteDate;
        #endregion
        #region Public Properties
        public int ClaimNoteID
        {
            get { return _ClaimNoteID; }
            set { _ClaimNoteID = value; }
        }
        public int ClaimID
        {
            get { return _ClaimID; }
            set { _ClaimID = value; }
        }
        public string ClaimNoteContent
        {
            get { return _ClaimNoteContent; }
            set { _ClaimNoteContent = value; }
        }
        public string ClaimNoteEnteredBy
        {
            get { return _ClaimNoteEnteredBy; }
            set { _ClaimNoteEnteredBy = value; }
        }
        public object ClaimNoteDate
        {
            get { return _ClaimNoteDate; }
            set { _ClaimNoteDate = value; }
        }
        #endregion
    }
}