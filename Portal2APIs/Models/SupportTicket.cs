using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class SupportTicket
    {

        #region Constructors
        public SupportTicket()
        {
        }
        #endregion
        #region Private Fields
        private int _SupportTicketId;
        private string _SupportTicketDesc;
        private DateTime _SupportTicketDate;
        private string _SupportTicketSubmittedBy;
        #endregion
        #region Public Properties
        public int SupportTicketId
        {
            get { return _SupportTicketId; }
            set { _SupportTicketId = value; }
        }
        public string SupportTicketDesc
        {
            get { return _SupportTicketDesc; }
            set { _SupportTicketDesc = value; }
        }
        public DateTime SupportTicketDate
        {
            get { return _SupportTicketDate; }
            set { _SupportTicketDate = value; }
        }
        public string SupportTicketSubmittedBy
        {
            get { return _SupportTicketSubmittedBy; }
            set { _SupportTicketSubmittedBy = value; }
        }
        #endregion
    }
}