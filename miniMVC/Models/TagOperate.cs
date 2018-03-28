using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class TagOperate
    {
        public List<TagModel> get()
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "select * from Tag";
            SqlCommand cmd = new SqlCommand(sqlStr, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<TagModel> Tag_List = new List<TagModel>();
            while (reader.Read())
            {
                int aId = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Id")));
                string aName = Convert.ToString(reader.GetValue(reader.GetOrdinal("Name")));
               
                Tag_List.Add(new TagModel { Id = aId, Name = aName});
            }

            con.Close();

            return Tag_List;
        }

        public string getIdName(int id)
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "Select Name from Tag Where Id=@aId";
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            cmd.Parameters.AddWithValue("@aId", id);

            string ans = "";
            con.Open();
            object data = cmd.ExecuteScalar();
            if (data == null)
            {
                ans = "null";
            }
            else
            {
                ans =  data.ToString();
            }

            con.Close();

            return ans;
        }
    }
}