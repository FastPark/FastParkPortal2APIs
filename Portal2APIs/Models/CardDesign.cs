using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class CardDesign
    {

        #region Constructors
        public CardDesign()
        {
        }
        #endregion
        #region Private Fields
        private int _CardDesignId;
        private string _CardDesignDesc;
        #endregion
        #region Public Properties
        public int CardDesignId
        {
            get { return _CardDesignId; }
            set { _CardDesignId = value; }
        }
        public string CardDesignDesc
        {
            get { return _CardDesignDesc; }
            set { _CardDesignDesc = value; }
        }
        #endregion
    }
}