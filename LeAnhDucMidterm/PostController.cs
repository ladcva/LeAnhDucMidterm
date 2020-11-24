using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace LeAnhDucMidterm
{
    public class PostController
    {
        public void AddOnePost(PostModel newPost)
        {
            Console.WriteLine(newPost.Summary);
            using (SqlConnection openCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MidTermCon"].ConnectionString))
            {
                string connString = "INSERT into Post (Title,PostSummary,PostContent) VALUES (@Title,@Summary,@Content)";

                using (SqlCommand command = new SqlCommand(connString))
                {
                    command.Connection = openCon;
                    command.Parameters.Add("@Title", SqlDbType.VarChar, 300).Value = newPost.Title;
                    command.Parameters.Add("@Summary", SqlDbType.VarChar, 2000).Value = newPost.Summary;
                    command.Parameters.Add("@Content", SqlDbType.VarChar, 3000).Value = newPost.Content;
                    openCon.Open();

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " rows affected !");
                }
            }
        }

        public void DeleteOnePost(int Id)
        {
            Console.WriteLine(Id);
            using (SqlConnection openCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MidTermCon"].ConnectionString))
            {
                string connString = "DELETE FROM Post WHERE (ID) = (@ID)";

                using (SqlCommand command = new SqlCommand(connString))
                {
                    command.Connection = openCon;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    openCon.Open();

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " rows affected !");
                }
            }
        }


        public void ListPost(string Keyword)
        {
            Console.WriteLine("Searching for : \n" + Keyword);
            using (SqlConnection openCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MidTermCon"].ConnectionString))
            {
                string queryString = "SELECT * FROM Post WHERE PostContent LIKE '" + Keyword + "%'";

                using (SqlCommand command = new SqlCommand(queryString))
                {
                    command.Connection = openCon;
                    openCon.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" + reader[3] + "\t" + reader[4]);
                }
            }
        }

        public void ListAllPost()
        {
            Console.WriteLine("Listing all records found : \n");
            using (SqlConnection openCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MidTermCon"].ConnectionString))
            {
                string queryString = "SELECT * FROM Post;";

                using (SqlCommand command = new SqlCommand(queryString))
                {
                    command.Connection = openCon;
                    openCon.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" + reader[3] + "\t" + reader[4]);
                }
            }
        }
    }
}
