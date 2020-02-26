using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class PCARep
    {
        #region Constructors
        public PCARep()
        {
        }
        #endregion
        #region Private Fields
        private int _PCARepID;
        private string _PCARepFirstName;
        private string _PCARepLastName;
        private string _PCARepName;

        #endregion
        #region Public Properties
        public int PCARepID
        {
            get { return _PCARepID; }
            set { _PCARepID = value; }
        }
        public string PCARepFirstName
        {
            get { return _PCARepFirstName; }
            set { _PCARepFirstName = value; }
        }
        public string PCARepLastName
        {
            get { return _PCARepLastName; }
            set { _PCARepLastName = value; }
        }

        public string PCARepName
        {
            get { return _PCARepName; }
            set { _PCARepName = value; }
        }
        #endregion
    }
}