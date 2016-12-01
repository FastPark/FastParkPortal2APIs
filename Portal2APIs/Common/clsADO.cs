using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Net;

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

    }
}