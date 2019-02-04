using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class Mechanics
    {

        #region Constructors
        public Mechanics()
        {
        }
        #endregion
        #region Private Fields
        private int _MechanicId;
        private string _MechanicName;
        private int _LocationId;
        private bool _Active;
        private object _EnteredByUserId;
        private DateTime _DateTimeEntered;
        #endregion
        #region Public Properties
        public int MechanicId
        {
            get { return _MechanicId; }
            set { _MechanicId = value; }
        }
        public string MechanicName
        {
            get { return _MechanicName; }
            set { _MechanicName = value; }
        }
        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public object EnteredByUserId
        {
            get { return _EnteredByUserId; }
            set { _EnteredByUserId = value; }
        }
        public DateTime DateTimeEntered
        {
            get { return _DateTimeEntered; }
            set { _DateTimeEntered = value; }
        }
        #endregion
    }
}