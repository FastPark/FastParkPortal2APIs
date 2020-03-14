using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ManagerRecomendation
    {

        #region Constructors
        public ManagerRecomendation()
        {
        }
        #endregion
        #region Private Fields
        private int _ManagerRecomendationID;
        private string _ManagerRecomendationDesc;
        #endregion
        #region Public Properties
        public int ManagerRecomendationID
        {
            get { return _ManagerRecomendationID; }
            set { _ManagerRecomendationID = value; }
        }
        public string ManagerRecomendationDesc
        {
            get { return _ManagerRecomendationDesc; }
            set { _ManagerRecomendationDesc = value; }
        }
        #endregion
    }
}