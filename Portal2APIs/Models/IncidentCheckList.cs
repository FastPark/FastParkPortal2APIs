using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class IncidentCheckList
    {
        #region Constructors
        public IncidentCheckList()
        {
        }
        #endregion
        #region Private Fields
        private int _IncidentCheckListID;
        private string _IncidentID;
        private int _EmployeeStatementManager;
        private int _EmployeeStatementRep;
        private int _CustomerStatementManager;
        private int _CustomerStatementRep;
        private int _WitnessStatementManger;
        private int _WitnessStatementRep;
        private int _ManagerStatementManager;
        private int _ManagerStatementRep;
        private int _PicturesManager;
        private int _PicturesRep;
        private int _OrigDocsManager;
        private int _OrigDocsRep;
        private int _BusEstManager;
        private int _BusEstRep;
        private int _BusInvManager;
        private int _BusInvRep;
        private int _PoliceReportManager;
        private int _PoliceReportRep;
        private int _CustEstManager;
        private int _CustEstRep;
        private int _CustInvManager;
        private int _CustInvRep;
        private int _SlipFallWeatherManager;
        private int _SlipFallWeatherRep;
        private int _DriverMVRManager;
        private int _DriverMVRRep;
        private int _DrugTestManager;
        private int _DrugTestRep;
        private int _PayrollDeductManager;
        private int _PayrollDeductRep;
        private int _OtherPersonInsuranceManager;
        private int _OtherPersonInsuranceRep;
        private string _Comments;
        #endregion
        #region Public Properties
        public int IncidentCheckListID
        {
            get { return _IncidentCheckListID; }
            set { _IncidentCheckListID = value; }
        }
        public string IncidentID
        {
            get { return _IncidentID; }
            set { _IncidentID = value; }
        }
        public int EmployeeStatementManager
        {
            get { return _EmployeeStatementManager; }
            set { _EmployeeStatementManager = value; }
        }
        public int EmployeeStatementRep
        {
            get { return _EmployeeStatementRep; }
            set { _EmployeeStatementRep = value; }
        }
        public int CustomerStatementManager
        {
            get { return _CustomerStatementManager; }
            set { _CustomerStatementManager = value; }
        }
        public int CustomerStatementRep
        {
            get { return _CustomerStatementRep; }
            set { _CustomerStatementRep = value; }
        }
        public int WitnessStatementManger
        {
            get { return _WitnessStatementManger; }
            set { _WitnessStatementManger = value; }
        }
        public int WitnessStatementRep
        {
            get { return _WitnessStatementRep; }
            set { _WitnessStatementRep = value; }
        }
        public int ManagerStatementManager
        {
            get { return _ManagerStatementManager; }
            set { _ManagerStatementManager = value; }
        }
        public int ManagerStatementRep
        {
            get { return _ManagerStatementRep; }
            set { _ManagerStatementRep = value; }
        }
        public int PicturesManager
        {
            get { return _PicturesManager; }
            set { _PicturesManager = value; }
        }
        public int PicturesRep
        {
            get { return _PicturesRep; }
            set { _PicturesRep = value; }
        }
        public int OrigDocsManager
        {
            get { return _OrigDocsManager; }
            set { _OrigDocsManager = value; }
        }
        public int OrigDocsRep
        {
            get { return _OrigDocsRep; }
            set { _OrigDocsRep = value; }
        }
        public int BusEstManager
        {
            get { return _BusEstManager; }
            set { _BusEstManager = value; }
        }
        public int BusEstRep
        {
            get { return _BusEstRep; }
            set { _BusEstRep = value; }
        }
        public int BusInvManager
        {
            get { return _BusInvManager; }
            set { _BusInvManager = value; }
        }
        public int BusInvRep
        {
            get { return _BusInvRep; }
            set { _BusInvRep = value; }
        }
        public int PoliceReportManager
        {
            get { return _PoliceReportManager; }
            set { _PoliceReportManager = value; }
        }
        public int PoliceReportRep
        {
            get { return _PoliceReportRep; }
            set { _PoliceReportRep = value; }
        }
        public int CustEstManager
        {
            get { return _CustEstManager; }
            set { _CustEstManager = value; }
        }
        public int CustEstRep
        {
            get { return _CustEstRep; }
            set { _CustEstRep = value; }
        }
        public int CustInvManager
        {
            get { return _CustInvManager; }
            set { _CustInvManager = value; }
        }
        public int CustInvRep
        {
            get { return _CustInvRep; }
            set { _CustInvRep = value; }
        }
        public int SlipFallWeatherManager
        {
            get { return _SlipFallWeatherManager; }
            set { _SlipFallWeatherManager = value; }
        }
        public int SlipFallWeatherRep
        {
            get { return _SlipFallWeatherRep; }
            set { _SlipFallWeatherRep = value; }
        }
        public int DriverMVRManager
        {
            get { return _DriverMVRManager; }
            set { _DriverMVRManager = value; }
        }
        public int DriverMVRRep
        {
            get { return _DriverMVRRep; }
            set { _DriverMVRRep = value; }
        }
        public int DrugTestManager
        {
            get { return _DrugTestManager; }
            set { _DrugTestManager = value; }
        }
        public int DrugTestRep
        {
            get { return _DrugTestRep; }
            set { _DrugTestRep = value; }
        }
        public int PayrollDeductManager
        {
            get { return _PayrollDeductManager; }
            set { _PayrollDeductManager = value; }
        }
        public int PayrollDeductRep
        {
            get { return _PayrollDeductRep; }
            set { _PayrollDeductRep = value; }
        }
        public int OtherPersonInsuranceManager
        {
            get { return _OtherPersonInsuranceManager; }
            set { _OtherPersonInsuranceManager = value; }
        }
        public int OtherPersonInsuranceRep
        {
            get { return _OtherPersonInsuranceRep; }
            set { _OtherPersonInsuranceRep = value; }
        }
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        #endregion
    }
}