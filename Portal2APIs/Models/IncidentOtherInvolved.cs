using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class IncidentOtherInvolved
    {

        #region Constructors
        public IncidentOtherInvolved()
        {
        }
        #endregion
        #region Private Fields
        private int _IncidentOtherInvolvedID;
        private int _ManagerInvestigationID;
        private string _OtherInvolvedName;
        private string _OtherInvolvedPhone;
        private string _OtherInvolvedRole;
        private string _OtherInvolvedDamageInjury;
        #endregion
        #region Public Properties
        public int IncidentOtherInvolvedID
        {
            get { return _IncidentOtherInvolvedID; }
            set { _IncidentOtherInvolvedID = value; }
        }
        public int ManagerInvestigationID
        {
            get { return _ManagerInvestigationID; }
            set { _ManagerInvestigationID = value; }
        }
        public string OtherInvolvedName
        {
            get { return _OtherInvolvedName; }
            set { _OtherInvolvedName = value; }
        }
        public string OtherInvolvedPhone
        {
            get { return _OtherInvolvedPhone; }
            set { _OtherInvolvedPhone = value; }
        }
        public string OtherInvolvedRole
        {
            get { return _OtherInvolvedRole; }
            set { _OtherInvolvedRole = value; }
        }
        public string OtherInvolvedDamageInjury
        {
            get { return _OtherInvolvedDamageInjury; }
            set { _OtherInvolvedDamageInjury = value; }
        }
        #endregion
    }
}