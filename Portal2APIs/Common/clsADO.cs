using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Net;
using System.Data;

namespace Portal2APIs.Common
{

    public class clsADO
    {
        public string getRemoteConnectionString()
        {
            try
            {
                System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Portal2API");
                System.Configuration.ConnectionStringSettings connString;
                if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
                {
                    connString =
                        rootWebConfig.ConnectionStrings.ConnectionStrings["FrequentParker08MaxConnectionString"];
                    return Convert.ToString(connString);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return "";
            }

        }

        public string getLocalConnectionString()
        {
            try
            {
                System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Portal2API");
                System.Configuration.ConnectionStringSettings connString;
                if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
                {
                    connString =
                        rootWebConfig.ConnectionStrings.ConnectionStrings["FrequentParker08ConnectionString"];
                    return Convert.ToString(connString);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return "";
            }

        }

        public string Park08ConnectionString()
        {
            try
            {
                System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Portal2API");
                System.Configuration.ConnectionStringSettings connString;
                if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
                {
                    connString =
                        rootWebConfig.ConnectionStrings.ConnectionStrings["Park08ConnectionString"];
                    return Convert.ToString(connString);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
                return "";
            }

        }


        public void updateOrInsert(string strSQL, bool Max)
        {

            string conn = "";

            if (Max == true)
            {
                conn = getRemoteConnectionString();
            }
            else
            {
                conn = getLocalConnectionString();
            }

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
          
        }

        public int updateOrInsertWithId(string strSQL, bool Max)
        {
            int ID;

            strSQL = strSQL + ";Select Scope_Identity()";


            string conn = "";

            if (Max == true)
            {
                conn = getRemoteConnectionString();
            }
            else
            {
                conn = getLocalConnectionString();
            }


            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    con.Open();
                    ID = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return ID;

            
        }


        // used for running
        public object selectConvertToString(string strSQL, bool Max, bool isString)
        {
            try
            {
                object thisReturn = null;
                string conn = "";

                if (Max == true)
                {
                    conn = getRemoteConnectionString();
                }
                else
                {
                    conn = getLocalConnectionString();
                }

                using (SqlConnection con = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = strSQL;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (isString)
                                {
                                    thisReturn = sdr.GetInt32(0);
                                }
                                else
                                {
                                    thisReturn = sdr.GetString(0);
                                }
                            }
                        }
                        con.Close();
                    }
                }
                return thisReturn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public void returnSingleValue<T>(string strSQL, bool Max,ref List<T> list)
        {
           try
            {
                string conn = "";

                if (Max == true)
                {
                    conn = getRemoteConnectionString();
                }
                else
                {
                    conn = getLocalConnectionString();
                }

                using (SqlConnection con = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = strSQL;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                            list = new List<T>().FromDataReader(sdr).ToList();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)

            {
                Console.Write(ex.ToString());
            }
            
        }

        public void returnSingleValueMarketing<T>(string strSQL, bool Max, ref List<T> list)
        {
            try
            {
                string conn = "";

                System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Portal2API");
                System.Configuration.ConnectionStringSettings connString;
                if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
                {
                    connString =
                        rootWebConfig.ConnectionStrings.ConnectionStrings["MarketingFlyerMaxConnectionString"];
                    conn = Convert.ToString(connString);
                }

                using (SqlConnection con = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = strSQL;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                            list = new List<T>().FromDataReader(sdr).ToList();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)

            {
                Console.Write(ex.ToString());
            }

        }

        public void returnSingleValueForPark09<T>(string strSQL, ref List<T> list)
        {

            string conn = "";

            conn = Park08ConnectionString();


            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                        list = new List<T>().FromDataReader(sdr).ToList();
                    con.Close();
                }
            }
        }

        public string returnSingleValueForInternalAPIUse(string strSQL, Boolean Max)
        {

            string thisReturn = null;
            string conn = "";

            if (Max == true)
            {
                conn = getRemoteConnectionString();
            }
            else
            {
                conn = getLocalConnectionString();
            }

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            thisReturn = Convert.ToString(sdr[0]);
                        }
                    }
                    con.Close();
                }
            }
            return thisReturn;
        }

        public void UpdateMemberVisitTracking(int MemberId ,Boolean Max)
        {

                clsADO thisADO = new clsADO();

                string conn = "";

                if (Max == true)
                {
                    conn = getRemoteConnectionString();
                }
                else
                {
                    conn = getLocalConnectionString();
                }

                SqlConnection cn = new SqlConnection(conn);

                cn.Open();
                SqlCommand cmd = new SqlCommand("dbo.UpdateMarketingTrackingNewByMember");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                SqlParameter thisMemberId = cmd.Parameters.Add(new SqlParameter("@iMemberId", SqlDbType.BigInt));

                thisMemberId.Value = MemberId;

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        //return Convert.ToString(sdr["ErrorMessage"]);
                    }
                }

                //return "No Activity";

            
        }

        public void returnSearchTransactions<T>(string strStoredProcedure, bool Max, ref List<T> list, string thisParams)
        {
            clsADO thisADO = new clsADO();

            string conn = "";

            if (Max == true)
            {
                conn = getRemoteConnectionString();
            }
            else
            {
                conn = getLocalConnectionString();
            }

            SqlConnection cn = new SqlConnection(conn);

            string[] paramsList = thisParams.Split(',');

            SqlCommand cmd = new SqlCommand();

            cn.Open();
            if (paramsList[6] == "False")
            {
                cmd.CommandText = "[dbo].[SearchTransactions]";
            }
            else
            {
                cmd.CommandText = "[dbo].[SearchTransactionsArchive]";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;

            SqlParameter thisEntryDate = cmd.Parameters.Add(new SqlParameter("@iEntryDate", SqlDbType.DateTime));
            SqlParameter thisExitDate = cmd.Parameters.Add(new SqlParameter("@iExitDate", SqlDbType.DateTime));
            SqlParameter thisReceiptNumber = cmd.Parameters.Add(new SqlParameter("@iReceiptNumber", SqlDbType.NVarChar));
            SqlParameter thisColumnNumber = cmd.Parameters.Add(new SqlParameter("@iColumnNumber", SqlDbType.NVarChar));
            SqlParameter thisShortTermNumber = cmd.Parameters.Add(new SqlParameter("@iShortTermNumber", SqlDbType.NVarChar));
            SqlParameter thisLocationId = cmd.Parameters.Add(new SqlParameter("@iLocationId", SqlDbType.Int));

            

            if (paramsList[0] != "")
            {
                thisEntryDate.Value = paramsList[0];
            }
            //if (paramsList[1] != "")
            //{
            //    thisExitDate.Value = paramsList[1];
            //}
            if (paramsList[2] != "")
            {
                thisReceiptNumber.Value = paramsList[2];
            }
            if (paramsList[3] != "")
            {
                thisColumnNumber.Value = paramsList[3];
            }
            if (paramsList[4] != "")
            {
                thisShortTermNumber.Value = paramsList[4];
            }
            if (paramsList[5] != "")
            {
                thisLocationId.Value = paramsList[5];
            }

            using (SqlDataReader sdr = cmd.ExecuteReader())
                list = new List<T>().FromDataReader(sdr).ToList();
            cn.Close();

        }

        public List<string[]> returnAllValues(string strSQL, bool Max)
        {
            var thisReturn = new List<string[]>();
            string conn = "";


            if (Max == true)
            {
                conn = getRemoteConnectionString();
            }
            else
            {
                conn = getLocalConnectionString();
            }

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            string[] thisLine = new string[sdr.FieldCount];
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                thisLine[i] = sdr[i].ToString();
                            }
                            thisReturn.Add(thisLine);
                            thisLine = null;
                        }
                    }
                    con.Close();
                }
            }
            return thisReturn;
        }

    }
}