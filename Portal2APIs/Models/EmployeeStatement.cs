using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class EmployeeStatement
    {

        #region Constructors
        public EmployeeStatement()
        {
        }
        #endregion
        #region Private Fields
        private int _EmployeeStatementID;
        private string _Position;
        private int _EmpClaimID;
        private int _CustClaimID;
        private string _IncidentDesc;
        private string _InjuryDesc;
        private string _EmpSignature;
        private object _StatementDate;
        #endregion
        #region Public Properties
        public int EmployeeStatementID
        {
            get { return _EmployeeStatementID; }
            set { _EmployeeStatementID = value; }
        }
        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
        public int EmpClaimID
        {
            get { return _EmpClaimID; }
            set { _EmpClaimID = value; }
        }
        public int CustClaimID
        {
            get { return _CustClaimID; }
            set { _CustClaimID = value; }
        }
        public string IncidentDesc
        {
            get { return _IncidentDesc; }
            set { _IncidentDesc = value; }
        }
        public string InjuryDesc
        {
            get { return _InjuryDesc; }
            set { _InjuryDesc = value; }
        }
        public string EmpSignature
        {
            get { return _EmpSignature; }
            set { _EmpSignature = value; }
        }
        public object StatementDate
        {
            get { return _StatementDate; }
            set { _StatementDate = value; }
        }
        #endregion
    }
}