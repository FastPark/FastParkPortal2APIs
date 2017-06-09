using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardOrder
    {
        #region Constructors
        public CardOrder()
        {
        }
        #endregion
        #region Private Fields
        private int _CardOrderId;
        private DateTime _CardOrderDate;
        private Int64 _CardOrderStartNumber;
        private Int64 _CardOrderEndNumber;
        private string _CardOrderBy;
        private int _CardOrderStatusID;
        private string _CardOrderStatus;
        private DateTime _CardOrderReceivedDate;
        private string _CardOrderReceivedBy;
        private int _orderedMax;
        private string _CardDesignDesc;
        private int _CardDesignId;
        private string _PreFix;
        private string _Suffix;
        private string _RegistrationCode;
        #endregion
        #region Public Properties
        public int CardOrderId
        {
            get { return _CardOrderId; }
            set { _CardOrderId = value; }
        }
        public DateTime CardOrderDate
        {
            get { return _CardOrderDate; }
            set { _CardOrderDate = value; }
        }
        public Int64 CardOrderStartNumber
        {
            get { return _CardOrderStartNumber; }
            set { _CardOrderStartNumber = value; }
        }
        public Int64 CardOrderEndNumber
        {
            get { return _CardOrderEndNumber; }
            set { _CardOrderEndNumber = value; }
        }
        public string CardOrderBy
        {
            get { return _CardOrderBy; }
            set { _CardOrderBy = value; }
        }
        public string CardOrderReceivedBy
        {
            get { return _CardOrderReceivedBy; }
            set { _CardOrderReceivedBy = value; }
        }
        public DateTime CardOrderReceivedDate
        {
            get { return _CardOrderReceivedDate; }
            set { _CardOrderReceivedDate = value; }
        }
        public int CardOrderStatusID
        {
            get { return _CardOrderStatusID; }
            set { _CardOrderStatusID = value; }
        }
        public string CardOrderStatus
        {
            get { return _CardOrderStatus; }
            set { _CardOrderStatus = value; }
        }
        public int orderedMax
        {
            get { return _orderedMax; }
            set { _orderedMax = value; }
        }
        public string CardDesignDesc
        {
            get { return _CardDesignDesc; }
            set { _CardDesignDesc = value; }
        }
        public int CardDesignId
        {
            get { return _CardDesignId; }
            set { _CardDesignId = value; }
        }
        public string PreFix
        {
            get { return _PreFix; }
            set { _PreFix = value; }
        }
        public string Suffix
        {
            get { return _Suffix; }
            set { _Suffix = value; }
        }
        public string RegistrationCode
        {
            get { return _RegistrationCode; }
            set { _RegistrationCode = value; }
        }
        #endregion
    }
}