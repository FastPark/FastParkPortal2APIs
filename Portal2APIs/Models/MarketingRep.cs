using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class MarketingRep
    {
        #region Private Fields
        private Int32 _ID;
        private string _RepName;
        private string _LastName;
        private string _FirstName;
        private string _Location;
        private string _EmailAddress;
        private DateTime _HireDate;
        private DateTime _RehireDate;
        private DateTime _TerminationDate1;
        private DateTime _TerminationDate2;
        private string _BIUserID;
        private string _RepID;
        private string _TerritoryAbbreviation;
        private object _UserId;
        private bool _Manager;
        private string _RepMailerId;
        private int _DefaultLocationId;
        private string _StreetAddress;
        private string _City;
        private string _State;
        private string _Zip;
        private string _RepPhone;
        private string _Title;
        private string _RecordType;
        private bool _Rep;
        private string _Region;
        private object _CarDayMonthlyGoal;
        private object _CarDayYearlyGoal;
        private int _SignupMonthlyGoal;
        private int _SignupYearlyGoal;
        private string _RepPhotoURL;
        private int _LocationId;
        private int _IsPrimary;
        private bool _Admin;
        #endregion
        #region Public Properties
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string RepName
        {
            get { return _RepName; }
            set { _RepName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value; }
        }
        public DateTime HireDate
        {
            get { return _HireDate; }
            set { _HireDate = value; }
        }
        public DateTime RehireDate
        {
            get { return _RehireDate; }
            set { _RehireDate = value; }
        }
        public DateTime TerminationDate1
        {
            get { return _TerminationDate1; }
            set { _TerminationDate1 = value; }
        }
        public DateTime TerminationDate2
        {
            get { return _TerminationDate2; }
            set { _TerminationDate2 = value; }
        }
        public string BIUserID
        {
            get { return _BIUserID; }
            set { _BIUserID = value; }
        }
        public string RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }
        public string TerritoryAbbreviation
        {
            get { return _TerritoryAbbreviation; }
            set { _TerritoryAbbreviation = value; }
        }
        public object UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public bool Manager
        {
            get { return _Manager; }
            set { _Manager = value; }
        }
        public string RepMailerId
        {
            get { return _RepMailerId; }
            set { _RepMailerId = value; }
        }
        public int DefaultLocationId
        {
            get { return _DefaultLocationId; }
            set { _DefaultLocationId = value; }
        }
        public string StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }
        public string RepPhone
        {
            get { return _RepPhone; }
            set { _RepPhone = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string RecordType
        {
            get { return _RecordType; }
            set { _RecordType = value; }
        }
        public bool Rep
        {
            get { return _Rep; }
            set { _Rep = value; }
        }
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
        public object CarDayMonthlyGoal
        {
            get { return _CarDayMonthlyGoal; }
            set { _CarDayMonthlyGoal = value; }
        }
        public object CarDayYearlyGoal
        {
            get { return _CarDayYearlyGoal; }
            set { _CarDayYearlyGoal = value; }
        }
        public int SignupMonthlyGoal
        {
            get { return _SignupMonthlyGoal; }
            set { _SignupMonthlyGoal = value; }
        }
        public int SignupYearlyGoal
        {
            get { return _SignupYearlyGoal; }
            set { _SignupYearlyGoal = value; }
        }
        public string RepPhotoURL
        {
            get { return _RepPhotoURL; }
            set { _RepPhotoURL = value; }
        }
        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }
        public int IsPrimary
        {
            get { return _IsPrimary; }
            set { _IsPrimary = value; }
        }
        public bool Admin
        {
            get { return _Admin; }
            set { _Admin = value; }
        }
        #endregion
    }
}