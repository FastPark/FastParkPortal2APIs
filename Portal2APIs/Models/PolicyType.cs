using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class PolicyType
    {

        #region Constructors
        public PolicyType()
        {
        }
        #endregion
        #region Private Fields
        private int _PolicyTypeID;
        private string _PolicyTypeDesc;
        #endregion
        #region Public Properties
        public int PolicyTypeID
        {
            get { return _PolicyTypeID; }
            set { _PolicyTypeID = value; }
        }
        public string PolicyTypeDesc
        {
            get { return _PolicyTypeDesc; }
            set { _PolicyTypeDesc = value; }
        }
        #endregion
    }
}