using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
	public class FP
	{
		#region Constructors
		public FP()
		{
		}
		#endregion
		#region Private Fields
		private int _FPID;
		private string _FirstName;
		private string _LastName;
		private string _EmailAddress;
		private string _WPFPNumber;
		private int _WPPoints;
		private int _RFRPoints;
		private int _RFRMemberId;
		private DateTime _RFRTransferDate;
		#endregion
		#region Public Properties
		public int FPID
		{
			get { return _FPID; }
			set { _FPID = value; }
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
		public string EmailAddress
		{
			get { return _EmailAddress; }
			set { _EmailAddress = value; }
		}
		public string WPFPNumber
		{
			get { return _WPFPNumber; }
			set { _WPFPNumber = value; }
		}
		public int WPPoints
		{
			get { return _WPPoints; }
			set { _WPPoints = value; }
		}
		public int RFRPoints
		{
			get { return _RFRPoints; }
			set { _RFRPoints = value; }
		}
		public int RFRMemberId
		{
			get { return _RFRMemberId; }
			set { _RFRMemberId = value; }
		}
		public DateTime RFRTransferDate
		{
			get { return _RFRTransferDate; }
			set { _RFRTransferDate = value; }
		}
		#endregion
	}
}