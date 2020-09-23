using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
	public class WCInvestigationWitness
	{

		#region Constructors
		public WCInvestigationWitness()
		{
		}
		#endregion
		#region Private Fields
		private int _WCInvestigationWitnessID;
		private int _WCInvestigationID;
		private string _WCIWitnessName;
		private string _WCIWitnessAddress;
		private string _WCIWitnessCity;
		private int _WCIWitnessStateID;
		private string _WCIWitnessZip;
		private string _WCIWitnessHomePhone;
		private string _WCIWitnessBusinessPhone;
		private string _StateAbbreviation;
		#endregion
		#region Public Properties
		public int WCInvestigationWitnessID
		{
			get { return _WCInvestigationWitnessID; }
			set { _WCInvestigationWitnessID = value; }
		}
		public int WCInvestigationID
		{
			get { return _WCInvestigationID; }
			set { _WCInvestigationID = value; }
		}
		public string WCIWitnessName
		{
			get { return _WCIWitnessName; }
			set { _WCIWitnessName = value; }
		}
		public string WCIWitnessAddress
		{
			get { return _WCIWitnessAddress; }
			set { _WCIWitnessAddress = value; }
		}
		public string WCIWitnessCity
		{
			get { return _WCIWitnessCity; }
			set { _WCIWitnessCity = value; }
		}
		public int WCIWitnessStateID
		{
			get { return _WCIWitnessStateID; }
			set { _WCIWitnessStateID = value; }
		}
		public string WCIWitnessZip
		{
			get { return _WCIWitnessZip; }
			set { _WCIWitnessZip = value; }
		}
		public string WCIWitnessHomePhone
		{
			get { return _WCIWitnessHomePhone; }
			set { _WCIWitnessHomePhone = value; }
		}
		public string WCIWitnessBusinessPhone
		{
			get { return _WCIWitnessBusinessPhone; }
			set { _WCIWitnessBusinessPhone = value; }
		}
		public string StateAbbreviation
		{
			get { return _StateAbbreviation; }
			set { _StateAbbreviation = value; }
		}
		#endregion
	}
}