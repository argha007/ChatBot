using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace IntermediatorBotSample.Storage
{
    public class DatabaseHelper
    {
        private static string ConnectionString = "Server=DESKTOP-8J1I408;Database=ChatBot;User Id=sa;Password=sap;";// Integrated Security=SSPI;Persist Security Info=False;InitialCatalog=ChatBot;Data Source=DESKTOP-8J1I408";
        private static string UserFirstTime = "JeetFirstTime";
        private static string AgentWatchClicked = "AgentWatchClicked";
        private static string AgentAccepted = "AgentAccepted";
        private static string UserCried = "UserCried";
            private static string StopBot = "StopBot";
        SqlConnection conn;
        SqlCommand comm;
        //SqlDataReader dreader;
        public bool GetStatus(string key)
        {
            var retVal= false;
            DataTable dt = GetTable();
            if (dt != null)
            {
                if(dt.Columns.Count>0)
                {
                    if (key.Equals(UserFirstTime))
                    {
                        retVal = Convert.ToBoolean(Convert.ToString(dt.Rows[0][2]));
                    }
                    else if((key.Equals(AgentWatchClicked)))
                    {
                        retVal = Convert.ToBoolean(Convert.ToString(dt.Rows[1][2]));
                    }
                    else if ((key.Equals(AgentAccepted)))
                    {
                        retVal = Convert.ToBoolean(Convert.ToString(dt.Rows[3][2]));
                    }
                    else if ((key.Equals(UserCried)))
                    {
                        retVal = Convert.ToBoolean(Convert.ToString(dt.Rows[4][2]));
                    }
                    else if ((key.Equals(StopBot)))
                    {
                        retVal = Convert.ToBoolean(Convert.ToString(dt.Rows[5][2]));
                    }
                }
            }
            return retVal;
        }

        public void UpdateStatus(string key,string value)
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            comm = new SqlCommand("update Dumps set Value= '" + value + "' where Name ='"+ key + "';", conn);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
        }

        public string GetUserConversationId()
        {
            var retVal = string.Empty;
            DataTable dt = GetTable();
            if (dt != null)
            {
                if (dt.Columns.Count > 0)
                {
                  retVal = Convert.ToString(dt.Rows[3][2]);
                }
            }
            return retVal;
        }

        public void UpdateUserConversationId(string value)
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            comm = new SqlCommand("update Dumps set Value= '" + value + "' where Name ='JeetConversationId';", conn);  
            try
            {
                comm.ExecuteNonQuery();
            }
            catch 
            {            }
            finally
            {
                conn.Close();
            }
        }

        private DataTable GetTable()
        {
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConnectionString))
            using (var da = new SqlDataAdapter("Select * FROM Dumps", con))
            da.Fill(table);
            return table;
        }
    }
}
