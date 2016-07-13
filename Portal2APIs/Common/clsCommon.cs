using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Common
{
    public class clsCommon
    {
        public object checknull(object thisData, bool thisString)
        {
            if (DBNull.Value.Equals(thisData))
            {
                if (thisString == true)
                {
                    return "";
                }
                else
                {
                    return 0;
                }
            }
            return thisData;
        }
    }
}