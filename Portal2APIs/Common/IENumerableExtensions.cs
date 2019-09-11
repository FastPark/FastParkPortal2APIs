using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Portal2APIs.Common
{
    public static class IENumerableExtensions
    {
        public static IEnumerable<T> FromDataReader<T>(this IEnumerable<T> list, DbDataReader dr)
        {
            

            //Instance reflec object from Reflection class coded above
            Reflection reflec = new Reflection();
            //Declare one "instance" object of Object type and an object list
            Object instance;
            List<Object> lstObj = new List<Object>();

            //dataReader loop
            while (dr.Read())
            {
                //Create an instance of the object needed.
                //The instance is created by obtaining the object type T of the object
                //list, which is the object that calls the extension method
                //Type T is inferred and is instantiated
                instance = Activator.CreateInstance(list.GetType().GetGenericArguments()[0]);

                // Loop all the fields of each row of dataReader, and through the object
                // reflector (first step method) fill the object instance with the datareader values
                try
                {
                    foreach (DataRow drow in dr.GetSchemaTable().Rows)
                    {


                        if (dr[drow.ItemArray[0].ToString()].GetType().Name == "Int32")
                        {
                            reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), Convert.ToInt32(dr[drow.ItemArray[0].ToString()]));
                        }
                        if (dr[drow.ItemArray[0].ToString()].GetType().Name == "Int64")
                        {
                            reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), dr[drow.ItemArray[0].ToString()]);
                        }
                        else if (dr[drow.ItemArray[0].ToString()].GetType().Name == "String")
                        {
                            reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), dr[drow.ItemArray[0].ToString()]);
                        }
                        else if (dr[drow.ItemArray[0].ToString()].GetType().Name == "DateTime")
                        {
                            reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), Convert.ToDateTime(dr[drow.ItemArray[0].ToString()]));
                        }
                        else if (dr[drow.ItemArray[0].ToString()].GetType().Name == "Decimal")
                        {
                            reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), Convert.ToDecimal(dr[drow.ItemArray[0].ToString()]));
                        }
                        else if (dr[drow.ItemArray[0].ToString()].GetType().Name == "Double")
                        {
                            reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), Convert.ToDecimal(dr[drow.ItemArray[0].ToString()]));
                        }
                        else if (dr[drow.ItemArray[0].ToString()].GetType().Name == "Guid")
                        {
                            reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), Convert.ToString(dr[drow.ItemArray[0].ToString()]));
                        }
                        else if (dr[drow.ItemArray[0].ToString()].GetType().Name == "Boolean")
                        {
                            reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), Convert.ToByte(dr[drow.ItemArray[0].ToString()]));
                        }
                        else if (dr[drow.ItemArray[0].ToString()].GetType().Name == "DBNull")
                        {
                            //Don't do anything
                        }

                    }

                    //Add object instance to list
                    lstObj.Add(instance);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }

            List<T> lstResult = new List<T>();
            foreach (Object item in lstObj)
            {
                lstResult.Add((T)Convert.ChangeType(item, typeof(T)));
            }

            return lstResult;
        }
    }
}