using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
	public class PCASearchPermit
	{
		#region Constructors
		public PCASearchPermit()
		{
		}
		#endregion
		#region Private Fields
		private int _PermitId;
		private int _UserId;
		private int _LotId;
		private int _ParkingTypeId;
		private int _ParkingPeriodId;
		private int _UserVehicleId;
		private int _PermitType;
		private DateTime _EffectiveDatetime;
		private DateTime _ExpiresDatetime;
		private string _PermitNumber;
		private bool _IsRecurringPayment;
		private int _UserCreditCardId;
		private int _PermitStatusId;
		private string _SessionId;
		private int _CouponId;
		private string _ReasonForCancel;
		private DateTime _CreateDatetime;
		private int _CreateUserId;
		private DateTime _UpdateDatetime;
		private int _UpdateUserId;
		private bool _IsDeleted;
		private bool _IsActive;
		private string _CreateExternalUserData;
		private string _UpdateExternalUserData;
		private DateTime _LocalCreateDatetime;
		private DateTime _CancelRequested;
		private DateTime _Canceled;
		private string _AdminToken;
		private object _CancellationRefundAmount;
		private string _FirstName;
		private string _LastName;
		private string _LicensePlate;
		private string _CityName;
		private string _StateAbbreviation;
		private string _LotName;
		private int _CityId;
		private string _VendorServiceLocationId;
		private string _Source;
		#endregion
		#region Public Properties
		public int PermitId
		{
			get { return _PermitId; }
			set { _PermitId = value; }
		}
		public int UserId
		{
			get { return _UserId; }
			set { _UserId = value; }
		}
		public int LotId
		{
			get { return _LotId; }
			set { _LotId = value; }
		}
		public int ParkingTypeId
		{
			get { return _ParkingTypeId; }
			set { _ParkingTypeId = value; }
		}
		public int ParkingPeriodId
		{
			get { return _ParkingPeriodId; }
			set { _ParkingPeriodId = value; }
		}
		public int UserVehicleId
		{
			get { return _UserVehicleId; }
			set { _UserVehicleId = value; }
		}
		public int PermitType
		{
			get { return _PermitType; }
			set { _PermitType = value; }
		}
		public DateTime EffectiveDatetime
		{
			get { return _EffectiveDatetime; }
			set { _EffectiveDatetime = value; }
		}
		public DateTime ExpiresDatetime
		{
			get { return _ExpiresDatetime; }
			set { _ExpiresDatetime = value; }
		}
		public string PermitNumber
		{
			get { return _PermitNumber; }
			set { _PermitNumber = value; }
		}
		public bool IsRecurringPayment
		{
			get { return _IsRecurringPayment; }
			set { _IsRecurringPayment = value; }
		}
		public int UserCreditCardId
		{
			get { return _UserCreditCardId; }
			set { _UserCreditCardId = value; }
		}
		public int PermitStatusId
		{
			get { return _PermitStatusId; }
			set { _PermitStatusId = value; }
		}
		public string SessionId
		{
			get { return _SessionId; }
			set { _SessionId = value; }
		}
		public int CouponId
		{
			get { return _CouponId; }
			set { _CouponId = value; }
		}
		public string ReasonForCancel
		{
			get { return _ReasonForCancel; }
			set { _ReasonForCancel = value; }
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
		public bool IsActive
		{
			get { return _IsActive; }
			set { _IsActive = value; }
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
		public DateTime LocalCreateDatetime
		{
			get { return _LocalCreateDatetime; }
			set { _LocalCreateDatetime = value; }
		}
		public DateTime CancelRequested
		{
			get { return _CancelRequested; }
			set { _CancelRequested = value; }
		}
		public DateTime Canceled
		{
			get { return _Canceled; }
			set { _Canceled = value; }
		}
		public string AdminToken
		{
			get { return _AdminToken; }
			set { _AdminToken = value; }
		}
		public object CancellationRefundAmount
		{
			get { return _CancellationRefundAmount; }
			set { _CancellationRefundAmount = value; }
		}
		public string FirstName
		{
			get { return _FirstName; }
			set { _FirstName = value; }
		}
		public string LastName
		{
			get { return _LastName; }
			set { _LastName = value; }
		}
		public string LicensePlate
		{
			get { return _LicensePlate; }
			set { _LicensePlate = value; }
		}
		public string CityName
		{
			get { return _CityName; }
			set { _CityName = value; }
		}
		public string StateAbbreviation
        {
			get { return _StateAbbreviation; }
			set { _StateAbbreviation = value; }
        }
		public string LotName
        {
			get { return _LotName; }
			set { _LotName = value; }
        }
		public int CityId
        {
			get { return _CityId; }
			set { _CityId = value; }
        }
		#endregion
		public string VendorServiceLocationId
        {
			get { return _VendorServiceLocationId; }
			set { _VendorServiceLocationId = value; }
        }
		public string Source
		{
			get { return _Source; }
			set { _Source = value; }
		}
	}
}