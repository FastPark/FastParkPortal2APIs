using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class InsuranceIncidentWitness
    {

        #region Constructors
        public InsuranceIncidentWitness()
        {
        }
        #endregion
        #region Private Fields
        private int _WitnessID;
        private int _ManagerInvestigationID;
        private string _WitnessName;
        private string _WitnessAddress;
        private int _WitnessStateID;
        private string _WitnessCity;
        private string _WitnessZip;
        private string _WitnessPhone;
        private int _Passenger;
        #endregion
        #region Public Properties
        public int WitnessID
        {
            get { return _WitnessID; }
            set { _WitnessID = value; }
        }
        public int ManagerInvestigationID
        {
            get { return _ManagerInvestigationID; }
            set { _ManagerInvestigationID = value; }
        }
        public string WitnessName
        {
            get { return _WitnessName; }
            set { _WitnessName = value; }
        }
        public string WitnessAddress
        {
            get { return _WitnessAddress; }
            set { _WitnessAddress = value; }
        }
        public int WitnessStateID
        {
            get { return _WitnessStateID; }
            set { _WitnessStateID = value; }
        }
        public string WitnessCity
        {
            get { return _WitnessCity; }
            set { _WitnessCity = value; }
        }
        public string WitnessZip
        {
            get { return _WitnessZip; }
            set { _WitnessZip = value; }
        }
        public string WitnessPhone
        {
            get { return _WitnessPhone; }
            set { _WitnessPhone = value; }
        }
        public int Passenger
        {
            get { return _Passenger; }
            set { _Passenger = value; }
        }
        #endregion
    }
}