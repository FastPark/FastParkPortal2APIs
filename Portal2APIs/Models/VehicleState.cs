using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class VehicleState
    {


        #region Constructors
        public VehicleState()
        {
        }
        #endregion
        #region Private Fields
        private int _StateId;
        private string _State;
        private string _StandardAbrev;
        private string _PostalAbrev;
        private string _Capital;
        #endregion
        #region Public Properties
        public int StateId
        {
            get { return _StateId; }
            set { _StateId = value; }
        }
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        public string StandardAbrev
        {
            get { return _StandardAbrev; }
            set { _StandardAbrev = value; }
        }
        public string PostalAbrev
        {
            get { return _PostalAbrev; }
            set { _PostalAbrev = value; }
        }
        public string Capital
        {
            get { return _Capital; }
            set { _Capital = value; }
        }
        #endregion
    }
}