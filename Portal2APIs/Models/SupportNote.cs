using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class SupportNote
    {

        #region Constructors
        public SupportNote()
        {
        }
        #endregion
        #region Private Fields
        private int _SupportNoteId;
        private string _SupportNoteDesc;
        private DateTime _SupportNoteDate;
        private string _SupportNoteSubmittedBy;
        #endregion
        #region Public Properties
        public int SupportNoteId
        {
            get { return _SupportNoteId; }
            set { _SupportNoteId = value; }
        }
        public string SupportNoteDesc
        {
            get { return _SupportNoteDesc; }
            set { _SupportNoteDesc = value; }
        }
        public DateTime SupportNoteDate
        {
            get { return _SupportNoteDate; }
            set { _SupportNoteDate = value; }
        }
        public string SupportNoteSubmittedBy
        {
            get { return _SupportNoteSubmittedBy; }
            set { _SupportNoteSubmittedBy = value; }
        }
        #endregion
    }
}