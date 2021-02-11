using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
	public class SignUpNoMatch
	{

		#region Constructors
		public SignUpNoMatch()
		{
		}
		#endregion
		#region Private Fields
		private int _SignUpNoMatchID;
		private string _EmailAddress;
		private DateTime _MatchCheckDate;
		private string _MailerCodeUsed;
		private int _RFRMemberId;
		private int _Finished;
		private string _FirstName;
		private string _LastName;
		private string _FPNumber;
		#endregion
		#region Public Properties
		public int SignUpNoMatchID
		{
			get { return _SignUpNoMatchID; }
			set { _SignUpNoMatchID = value; }
		}
		public string EmailAddress
		{
			get { return _EmailAddress; }
			set { _EmailAddress = value; }
		}
		public DateTime MatchCheckDate
		{
			get { return _MatchCheckDate; }
			set { _MatchCheckDate = value; }
		}
		public string MailerCodeUsed
		{
			get { return _MailerCodeUsed; }
			set { _MailerCodeUsed = value; }
		}
		public int RFRMemberId
		{
			get { return _RFRMemberId; }
			set { _RFRMemberId = value; }
		}
		public int Finished
		{
			get { return _Finished; }
			set { _Finished = value; }
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
		public string FPNumber
		{
			get { return _FPNumber; }
			set { _FPNumber = value; }
		}
		#endregion
	}
}