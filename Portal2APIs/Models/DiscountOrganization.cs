using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
	public class DiscountOrganization
	{

		#region Constructors
		public DiscountOrganization()
		{
		}
		#endregion
		#region Private Fields
		private int _DiscountOrganizationId;
		private string _DiscountOrganizationName;
		private DateTime _CreateDatetime;
		private int _CreateUserId;
		private DateTime _UpdateDatetime;
		private int _UpdateUserId;
		private bool _IsDeleted;
		private string _CreateExternalUserData;
		private string _UpdateExternalUserData;
		private bool _IsExpireDateRequired;
		private int _RateCode;
		private DateTime _ExpiresDatetime;
		private DateTime _EffectiveDatetime;
		private string _MembershipNumber;
		private int _MemberDiscountOrganizationId;
		private string _MemberName;
		private string _MemberEmail;
		private string _MemberCard;

		#endregion
		#region Public Properties
		public int DiscountOrganizationId
		{
			get { return _DiscountOrganizationId; }
			set { _DiscountOrganizationId = value; }
		}
		public string DiscountOrganizationName
		{
			get { return _DiscountOrganizationName; }
			set { _DiscountOrganizationName = value; }
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
		public bool IsExpireDateRequired
		{
			get { return _IsExpireDateRequired; }
			set { _IsExpireDateRequired = value; }
		}
		public int RateCode
		{
			get { return _RateCode; }
			set { _RateCode = value; }
		}
		public DateTime ExpiresDatetime
		{
			get { return _ExpiresDatetime; }
			set { _ExpiresDatetime = value; }
		}
		public DateTime EffectiveDatetime
		{
			get { return _EffectiveDatetime; }
			set { _EffectiveDatetime = value; }
		}
		public string MembershipNumber
		{
			get { return _MembershipNumber; }
			set { _MembershipNumber = value; }
		}
		public int MemberDiscountOrganizationId
		{
			get { return _MemberDiscountOrganizationId; }
			set { _MemberDiscountOrganizationId = value; }
		}
		public string MemberName
		{
			get { return _MemberName; }
			set { _MemberName = value; }
		}
		public string MemberEmail
		{
			get { return _MemberEmail; }
			set { _MemberEmail = value; }
		}
		public string MemberCard
		{
			get { return _MemberCard; }
			set { _MemberCard = value; }
		}

		#endregion
	}
}