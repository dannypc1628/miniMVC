using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class ArticleOperate
    {
        public List<ArticleModel> getArticle()
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "select * from Article";
            SqlCommand cmd = new SqlCommand(sqlStr, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ArticleModel> Article_List = new List<ArticleModel>();
            while (reader.Read())
            {
                int aId = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Id")));
                string aTitle = Convert.ToString(reader.GetValue(reader.GetOrdinal("Title")));
                string aContent = Convert.ToString(reader.GetValue(reader.GetOrdinal("Content")));
                string aName = Convert.ToString(reader.GetValue(reader.GetOrdinal("Name")));
                DateTime aTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Time")));

                Article_List.Add(new ArticleModel { Id = aId, Title=aTitle, Content=aContent, Name = aName, Time = aTime});
            }

            con.Close();

            return Article_List;
        }

        public ArticleModel getOneArticle(int Article_id)
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "select * from Article where id=@aID";
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            cmd.Parameters.AddWithValue("@aID", Article_id);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ArticleModel Article = new ArticleModel();
            while (reader.Read())
            {
                Article.Id = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Id")));
                Article.Title = Convert.ToString(reader.GetValue(reader.GetOrdinal("Title")));
                Article.Content = Convert.ToString(reader.GetValue(reader.GetOrdinal("Content")));
                Article.Name = Convert.ToString(reader.GetValue(reader.GetOrdinal("Name")));
                Article.Time = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Time")));
               
            }

            con.Close();

            return Article ;
        }
        public int addArticle(ArticleModel data)
        {
            ConnectionStringSettings dataStr = ConfigurationManager.ConnectionStrings["MyDatabase"];
            string conStr = dataStr.ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string sqlStr = "insert into Article (title,content,name,time) Values(@aTitle,@aContent,@aName,@aTime);select SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(sqlStr, con);

            cmd.Parameters.AddWithValue("@aTitle", data.Title);
            cmd.Parameters.AddWithValue("@aContent", data.Content);
            cmd.Parameters.AddWithValue("@aName", data.Name);
            cmd.Parameters.AddWithValue("@aTime", data.Time);

            con.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            
            return id;
            
        }
    }
}