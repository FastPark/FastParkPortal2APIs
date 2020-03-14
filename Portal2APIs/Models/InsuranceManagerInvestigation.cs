using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ManagerInvestigation
    {

        #region Constructors
        public ManagerInvestigation()
        {
        }
        #endregion
        #region Private Fields
        private int _ManagerInvestigationID;
        private int _IncidentID;
        private object _InvestigationDate;
        private string _InvestigationIncidentDesc;
        private string _InvestigationCustomerInteraction;
        private int _ManagerRecomendationID;
        private object _PCAVehicleAmountDamage;
        private object _CustomerVehicleAmountDamage;
        private object _PCAPropertyDamage;
        private string _ManagerSignature;

        #endregion
        #region Public Properties
        public int ManagerInvestigationID
        {
            get { return _ManagerInvestigationID; }
            set { _ManagerInvestigationID = value; }
        }
        public int IncidentID
        {
            get { return _IncidentID; }
            set { _IncidentID = value; }
        }
        public object InvestigationDate
        {
            get { return _InvestigationDate; }
            set { _InvestigationDate = value; }
        }
        public string InvestigationIncidentDesc
        {
            get { return _InvestigationIncidentDesc; }
            set { _InvestigationIncidentDesc = value; }
        }
        public string InvestigationCustomerInteraction
        {
            get { return _InvestigationCustomerInteraction; }
            set { _InvestigationCustomerInteraction = value; }
        }
        public int ManagerRecomendationID
        {
            get { return _ManagerRecomendationID; }
            set { _ManagerRecomendationID = value; }
        }
        public object PCAVehicleAmountDamage
        {
            get { return _PCAVehicleAmountDamage; }
            set { _PCAVehicleAmountDamage = value; }
        }
        public object CustomerVehicleAmountDamage
        {
            get { return _CustomerVehicleAmountDamage; }
            set { _CustomerVehicleAmountDamage = value; }
        }
        public object PCAPropertyDamage
        {
            get { return _PCAPropertyDamage; }
            set { _PCAPropertyDamage = value; }
        }
        public string ManagerSignature
        {
            get { return _ManagerSignature; }
            set { _ManagerSignature = value; }
        }
        #endregion
    }
}