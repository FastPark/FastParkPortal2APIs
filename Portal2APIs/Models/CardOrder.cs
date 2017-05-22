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
        
        #endregion
    }
}