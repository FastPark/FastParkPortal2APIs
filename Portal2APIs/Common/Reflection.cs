using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal2APIs.Common
{
    public class Reflection
    {
        public void FillObjectWithProperty(ref object objectTo, string propertyName, object propertyValue)
        {
            Type tOb2 = objectTo.GetType();
            tOb2.GetProperty(propertyName).SetValue(objectTo, propertyValue);
        }
    }
}