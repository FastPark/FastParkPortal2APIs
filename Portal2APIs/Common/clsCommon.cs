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

            if (thisData == null)
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

        public int RandNumber(int Low, int High)
        {
            Random rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

            int rnd = rndNum.Next(Low, High);

            return rnd;
        }
    }


}