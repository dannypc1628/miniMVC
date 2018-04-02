using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace miniMVC.Models
{
    public class MessageOperate
    {
        public List<MessageCommitModel> getMessageList(int Article_ID)
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "select Message.Content,Message.Time,Member.Name from Message where Article_ID =@aID join Member on Message.Member_ID = Member.Id";
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            cmd.Parameters.AddWithValue("@aID", Article_ID);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<MessageCommitModel> List = new List<MessageCommitModel>();
            while (reader.Read())
            {
                MessageCommitModel aMessage = new MessageCommitModel();

                aMessage.Content = Convert.ToString(reader.GetValue(reader.GetOrdinal("Content")));
                aMessage.Name = Convert.ToString(reader.GetValue(reader.GetOrdinal("Name")));
                aMessage.Time = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Time")));

                List.Add(aMessage);
            }

            con.Close();

            return List;

        }
        public void InstertMessage(MessageModel data)
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "insert into Message (Member_ID,Artlic_ID,Content,Time) Values(@aM_ID,@aA_ID,@aContent,@aTime)";
            SqlCommand cmd = new SqlCommand(sqlStr, con);

            cmd.Parameters.AddWithValue("@aM_ID", data.Member_ID);
            cmd.Parameters.AddWithValue("@aA_ID", data.Artlic_Id);
            cmd.Parameters.AddWithValue("@aContent", data.Content);
            cmd.Parameters.AddWithValue("@aTime", data.Time);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}