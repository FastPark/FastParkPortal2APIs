using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
	public class PCACreditTransaction
	{

		#region Constructors
		public PCACreditTransaction()
		{
		}
		#endregion
		#region Private Fields
		private int _CreditTransactionId;
		private int _CreditPaymentTypeId;
		private string _Web2PayResult;
		private string _Cvv2ResultCode;
		private string _VSResultCode;
		private string _TxId;
		private string _AuthorisationCode;
		private string _RedirectUrl;
		private decimal _AuthoriseAmount;
		private decimal _CaptureAmount;
		private string _Currency;
		private string _MerchantRef;
		private string _MerchantCategory;
		private string _ReturnText;
		private string _TxState;
		private string _TxStateText;
		private string _CardNumberLast4;
		private string _CardType;
		private string _CardTypeName;
		private string _CreditTransactionTypeId;
		private string _MerchantId;
		private string _ReturnCode;
		private string _CardExpiryYYMM;
		private string _TokenNo;
		private string _TokenExpiryYYMM;
		private bool _IsDeleted;
		private bool _IsActive;
		private DateTime _CreateDatetime;
		private int _CreateUserId;
		private DateTime _UpdateDatetime;
		private int _UpdateUserId;
		private string _CreateExternalUserData;
		private string _UpdateExternalUserData;
		private DateTime _LocalCreateDatetime;
		private string _CheckNumber;
		private string _ReceiptNumber;
		private string _InvoiceNumber;
		private string _CCTxtNumber;
		private string _FirstName;
		private string _LastName;
		private string _Company;

		#endregion
		#region Public Properties
		public int CreditTransactionId
		{
			get { return _CreditTransactionId; }
			set { _CreditTransactionId = value; }
		}
		public int CreditPaymentTypeId
		{
			get { return _CreditPaymentTypeId; }
			set { _CreditPaymentTypeId = value; }
		}
		public string Web2PayResult
		{
			get { return _Web2PayResult; }
			set { _Web2PayResult = value; }
		}
		public string Cvv2ResultCode
		{
			get { return _Cvv2ResultCode; }
			set { _Cvv2ResultCode = value; }
		}
		public string VSResultCode
		{
			get { return _VSResultCode; }
			set { _VSResultCode = value; }
		}
		public string TxId
		{
			get { return _TxId; }
			set { _TxId = value; }
		}
		public string AuthorisationCode
		{
			get { return _AuthorisationCode; }
			set { _AuthorisationCode = value; }
		}
		public string RedirectUrl
		{
			get { return _RedirectUrl; }
			set { _RedirectUrl = value; }
		}
		public decimal AuthoriseAmount
		{
			get { return _AuthoriseAmount; }
			set { _AuthoriseAmount = value; }
		}
		public decimal CaptureAmount
		{
			get { return _CaptureAmount; }
			set { _CaptureAmount = value; }
		}
		public string Currency
		{
			get { return _Currency; }
			set { _Currency = value; }
		}
		public string MerchantRef
		{
			get { return _MerchantRef; }
			set { _MerchantRef = value; }
		}
		public string MerchantCategory
		{
			get { return _MerchantCategory; }
			set { _MerchantCategory = value; }
		}
		public string ReturnText
		{
			get { return _ReturnText; }
			set { _ReturnText = value; }
		}
		public string TxState
		{
			get { return _TxState; }
			set { _TxState = value; }
		}
		public string TxStateText
		{
			get { return _TxStateText; }
			set { _TxStateText = value; }
		}
		public string CardNumberLast4
		{
			get { return _CardNumberLast4; }
			set { _CardNumberLast4 = value; }
		}
		public string CardType
		{
			get { return _CardType; }
			set { _CardType = value; }
		}
		public string CardTypeName
		{
			get { return _CardTypeName; }
			set { _CardTypeName = value; }
		}
		public string CreditTransactionTypeId
		{
			get { return _CreditTransactionTypeId; }
			set { _CreditTransactionTypeId = value; }
		}
		public string MerchantId
		{
			get { return _MerchantId; }
			set { _MerchantId = value; }
		}
		public string ReturnCode
		{
			get { return _ReturnCode; }
			set { _ReturnCode = value; }
		}
		public string CardExpiryYYMM
		{
			get { return _CardExpiryYYMM; }
			set { _CardExpiryYYMM = value; }
		}
		public string TokenNo
		{
			get { return _TokenNo; }
			set { _TokenNo = value; }
		}
		public string TokenExpiryYYMM
		{
			get { return _TokenExpiryYYMM; }
			set { _TokenExpiryYYMM = value; }
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
		public string CheckNumber
		{
			get { return _CheckNumber; }
			set { _CheckNumber = value; }
		}
		public string ReceiptNumber
		{
			get { return _ReceiptNumber; }
			set { _ReceiptNumber = value; }
		}
		public string InvoiceNumber
		{
			get { return _InvoiceNumber; }
			set { _InvoiceNumber = value; }
		}
		public string CCTxtNumber
		{
			get { return _CCTxtNumber; }
			set { _CCTxtNumber = value; }
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
		public string Company
		{
			get { return _Company; }
			set { _Company = value; }
		}
		#endregion
	}
}