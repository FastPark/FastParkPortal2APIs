using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardDist
    {

        #region Constructors
        public CardDist()
        {
        }
        #endregion
        #region Private Fields
        private int _CardDistID;
        private int _CardDistLocationID;
        private int _CardDistRepLineID;
        private int _CardDistBooth;
        private string _CardDistBusName;
        private Int64 _CardDistStartNumber;
        private Int64 _CardDistEndNumber;
        private string _CardDistBy;
        private DateTime _CardDistDate;
        private string _CardDistRepName;
        #endregion
        #region Public Properties
        public int CardDistID
        {
            get { return _CardDistID; }
            set { _CardDistID = value; }
        }
        public int CardDistLocationID
        {
            get { return _CardDistLocationID; }
            set { _CardDistLocationID = value; }
        }
        public int CardDistRepLineID
        {
            get { return _CardDistRepLineID; }
            set { _CardDistRepLineID = value; }
        }
        public int CardDistBooth
        {
            get { return _CardDistBooth; }
            set { _CardDistBooth = value; }
        }
        public string CardDistBusName
        {
            get { return _CardDistBusName; }
            set { _CardDistBusName = value; }
        }
        public Int64 CardDistStartNumber
        {
            get { return _CardDistStartNumber; }
            set { _CardDistStartNumber = value; }
        }
        public Int64 CardDistEndNumber
        {
            get { return _CardDistEndNumber; }
            set { _CardDistEndNumber = value; }
        }
        public string CardDistBy
        {
            get { return _CardDistBy; }
            set { _CardDistBy = value; }
        }
        public DateTime CardDistDate
        {
            get { return _CardDistDate; }
            set { _CardDistDate = value; }
        }
        public string CardDistRepName
        {
            get { return _CardDistRepName; }
            set { _CardDistRepName = value; }
        }
        #endregion
    }
}