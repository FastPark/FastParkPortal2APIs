using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardShip
    {

        #region Constructors
        public CardShip()
        {
        }
        #endregion
        #region Private Fields
        private int _CardShipID;
        private int _CardShipFrom;
        private int _CardShipTo;
        private DateTime _CardShipDate;
        private string _CardShipShippedBy;
        private string _CardShipReceivedBy;
        private DateTime _CardShipReceiveDate;
        private int _CardShipStatusId;
        private Int64 _CardShipStartNumber;
        private Int64 _CardShipEndNumber;
        private string _CardShipToName;
        private string _CardShipFromName;
        private string _CardShipStatus;
        private Int64 _maxShipped;
        #endregion
        #region Public Properties
        public int CardShipID
        {
            get { return _CardShipID; }
            set { _CardShipID = value; }
        }
        public int CardShipFrom
        {
            get { return _CardShipFrom; }
            set { _CardShipFrom = value; }
        }
        public int CardShipTo
        {
            get { return _CardShipTo; }
            set { _CardShipTo = value; }
        }
        public DateTime CardShipDate
        {
            get { return _CardShipDate; }
            set { _CardShipDate = value; }
        }
        public string CardShipShippedBy
        {
            get { return _CardShipShippedBy; }
            set { _CardShipShippedBy = value; }
        }
        public string CardShipReceivedBy
        {
            get { return _CardShipReceivedBy; }
            set { _CardShipReceivedBy = value; }
        }
        public DateTime CardShipReceiveDate
        {
            get { return _CardShipReceiveDate; }
            set { _CardShipReceiveDate = value; }
        }
        public int CardShipStatusId
        {
            get { return _CardShipStatusId; }
            set { _CardShipStatusId = value; }
        }
        public Int64 CardShipStartNumber
        {
            get { return _CardShipStartNumber; }
            set { _CardShipStartNumber = value; }
        }
        public Int64 CardShipEndNumber
        {
            get { return _CardShipEndNumber; }
            set { _CardShipEndNumber = value; }
        }
        public string CardShipToName
        {
            get { return _CardShipToName; }
            set { _CardShipToName = value; }
        }
        public string CardShipFromName
        {
            get { return _CardShipFromName; }
            set { _CardShipFromName = value; }
        }
        public string CardShipStatus
        {
            get { return _CardShipStatus; }
            set { _CardShipStatus = value; }
        }
        public Int64 maxShipped
        {
            get { return _maxShipped; }
            set { _maxShipped = value; }
        }
        #endregion
    }
}