using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class LocationHasFeature
    {
        public int LocationHasFeatureId
        {
            get { return m_LocationHasFeatureId; }
            set { m_LocationHasFeatureId = value; }
        }
        private int m_LocationHasFeatureId;

        public string OptionalExtrasName
        {
            get { return m_OptionalExtrasName; }
            set { m_OptionalExtrasName = value; }
        }
        private string m_OptionalExtrasName;
    }
}