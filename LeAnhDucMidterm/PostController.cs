using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace LeAnhDucMidterm
{
    public class PostController
    {
        public void AddOnePost(PostModel OnePost)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MidTermCon"].ConnectionString))
            {
                return;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT into Post (Title, Summary, Content) VALUES (@Title, @Summary, @Content)";
                    command.Parameters.AddWithValue("@Title", OnePost.Title);
                    command.Parameters.AddWithValue("@Summary", OnePost.Summary);
                    command.Parameters.AddWithValue("@Content", OnePost.Content);

                    try
                    {
                        connection.Open();
                        //int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Error Connecting DB !");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
