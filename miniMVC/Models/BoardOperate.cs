using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class BoardOperate
    {
        public List<BoardModel> getData()
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "select * from Board";
            SqlCommand cmd = new SqlCommand(sqlStr, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<BoardModel> board_List = new List<BoardModel>();
            while (reader.Read())
            {
                int aId = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Id")));
                string aName = Convert.ToString(reader.GetValue(reader.GetOrdinal("Name")));
                string aMessage = Convert.ToString(reader.GetValue(reader.GetOrdinal("Message")));
                DateTime aTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Time")));

                board_List.Add(new BoardModel { Id = aId, name = aName, message = aMessage, time = aTime });
            }

            con.Close();

            return board_List;
            
        }

        public void addData(BoardModel data)
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "insert into Board (name,message,time) Values(@aName,@aMessage,@aTime)";
            SqlCommand cmd = new SqlCommand(sqlStr, con);

            cmd.Parameters.AddWithValue("@aName",data.name);
            cmd.Parameters.AddWithValue("@aMessage", data.message);
            cmd.Parameters.AddWithValue("@aTime", data.time);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}