using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace _102190145_NguyenQuyTrieu.DAL
{
    class DBHelper
    {
        private SqlConnection cnn;
        static string connectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        private static DBHelper _Instance;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper(connectionString);
                }
                return _Instance;
            }
            private set { }
        }
        private DBHelper(string ConnectionString)
        {
            cnn = new SqlConnection(ConnectionString);
        }
        /// <summary>
        /// query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetRecord(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        /// <summary>
        /// thay đổi db
        /// </summary>
        /// <param name="query"></param>
        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
