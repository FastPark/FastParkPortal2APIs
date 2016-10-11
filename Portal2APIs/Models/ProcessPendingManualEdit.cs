using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Models
{
    public class ProcessPendingManualEdit
    {
        public string ProcessList
        {
            get { return m_ProcessList; }
            set { m_ProcessList = value; }
        }
        private string m_ProcessList;
    }
}