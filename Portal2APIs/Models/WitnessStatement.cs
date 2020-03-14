using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class WitnessStatement
    {

        #region Constructors
        public WitnessStatement()
        {
        }
        #endregion
        #region Private Fields
        private int _WitnessStatementID;
        private int _WitnessID;
        private string _IncidentDesc;
        private string _WitnessSignature;
        private object _SignatureDate;
        #endregion
        #region Public Properties
        public int WitnessStatementID
        {
            get { return _WitnessStatementID; }
            set { _WitnessStatementID = value; }
        }
        public int WitnessID
        {
            get { return _WitnessID; }
            set { _WitnessID = value; }
        }
        public string IncidentDesc
        {
            get { return _IncidentDesc; }
            set { _IncidentDesc = value; }
        }
        public string WitnessSignature
        {
            get { return _WitnessSignature; }
            set { _WitnessSignature = value; }
        }
        public object SignatureDate
        {
            get { return _SignatureDate; }
            set { _SignatureDate = value; }
        }
        #endregion
    }
}