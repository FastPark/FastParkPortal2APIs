using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class RateAmountObject
    {

        #region Constructors
        public RateAmountObject()
        {
        }
        #endregion
        #region Private Fields
        private int _RateAmountId;
        private int _RateCode;
        private int _RateAmount;
        private DateTime _EffectiveDatetime;
        private int _LocationId;
        private object _AdvertisedRate;
        private object _HourlyRate;
        private int _DailyRateThreshold;
        private DateTime _CreateDatetime;
        private int _CreateUserId;
        private DateTime _UpdateDatetime;
        private int _UpdateUserId;
        private bool _IsDeleted;
        private string _CreateExternalUserData;
        private string _UpdateExternalUserData;
        #endregion
        #region Public Properties
        public int RateAmountId
        {
            get { return _RateAmountId; }
            set { _RateAmountId = value; }
        }
        public int RateCode
        {
            get { return _RateCode; }
            set { _RateCode = value; }
        }
        public int RateAmount
        {
            get { return _RateAmount; }
            set { _RateAmount = value; }
        }
        public DateTime EffectiveDatetime
        {
            get { return _EffectiveDatetime; }
            set { _EffectiveDatetime = value; }
        }
        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }
        public object AdvertisedRate
        {
            get { return _AdvertisedRate; }
            set { _AdvertisedRate = value; }
        }
        public object HourlyRate
        {
            get { return _HourlyRate; }
            set { _HourlyRate = value; }
        }
        public int DailyRateThreshold
        {
            get { return _DailyRateThreshold; }
            set { _DailyRateThreshold = value; }
        }
        public DateTime CreateDatetime
        {
            get { return _CreateDatetime; }
            set { _CreateDatetime = value; }
        }
        public int CreateUserId
        {
            get { return _CreateUserId; }
            set { _CreateUserId = value; }
        }
        public DateTime UpdateDatetime
        {
            get { return _UpdateDatetime; }
            set { _UpdateDatetime = value; }
        }
        public int UpdateUserId
        {
            get { return _UpdateUserId; }
            set { _UpdateUserId = value; }
        }
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }
        public string CreateExternalUserData
        {
            get { return _CreateExternalUserData; }
            set { _CreateExternalUserData = value; }
        }
        public string UpdateExternalUserData
        {
            get { return _UpdateExternalUserData; }
            set { _UpdateExternalUserData = value; }
        }
        #endregion
    }
}