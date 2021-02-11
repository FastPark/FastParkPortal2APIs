using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
	public class OL
	{
		#region Constructors
		public OL()
		{
		}
		#endregion
		#region Private Fields
		private int _OLID;
		private string _FirstName;
		private string _LastName;
		private string _EmailAddress;
		private string _OLCardNumber;
		private int _OLPoints;
		private int _RFRPoints;
		private int _RFRMemberId;
		private DateTime _RFRTransferDate;
		#endregion
		#region Public Properties
		public int OLID
		{
			get { return _OLID; }
			set { _OLID = value; }
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
		public string OLCardNumber
		{
			get { return _OLCardNumber; }
			set { _OLCardNumber = value; }
		}
		public int OLPoints
		{
			get { return _OLPoints; }
			set { _OLPoints = value; }
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