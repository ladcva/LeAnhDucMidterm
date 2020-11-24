using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LeAnhDucMidterm
{
    class Program
    {
        static public void Main(string[] args)
        {
            string Cnn = ConfigurationManager.ConnectionStrings["MidTermCon"].ConnectionString;
            string Cmd = "";
            if (args.Length > 0)
                Cmd = args[0];

            PostModel newPost = new PostModel();

            switch (Cmd.ToLower())
            {
                case "add":
                    //Code add here
                    if (args.Length != 4)
                    {
                        Console.WriteLine("usage: Add Title Summary Content");
                        return;
                    }
                    newPost.Title = args[1];
                    newPost.Summary = args[2];
                    newPost.Content = args[3];

                    //Write your code to add Title, Sumary, Content into database

                    Console.WriteLine("Title : " + newPost.Title);
                    Console.WriteLine("Summary : " + newPost.Summary);
                    Console.WriteLine("Content : " + newPost.Content);

                    PostController insert = new PostController();
                    insert.AddOnePost(newPost);

                    break;

                case "delete":

                    if (args.Length != 2)
                    {
                        Console.WriteLine("usage: Delete Id");
                        return;
                    }
                    //Get string from the second paramenters
                    string StrId = args[1];
                    //Convert the second parameter into int, stored in Id variable
                    bool isValid = int.TryParse(StrId, out newPost.Id);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid Id " + StrId);
                        return;
                    }
                    /*Code Delete here with the paramenter Id */
                    if (newPost.Id > 0)
                    {
                        /*write your code here */
                        PostController delete = new PostController();
                        delete.DeleteOnePost(newPost.Id);

                    }


                    Console.WriteLine("Delete completed " + StrId);
                    break;

                case "list":

                    string Keyword = args[1];
                    if (Keyword == "all")
                    {
                        //Code search with no keyword
                        PostController search = new PostController();
                        search.ListAllPost();
                    }
                    else
                    {
                        //Code search with keyword
                        PostController search = new PostController();
                        search.ListPost(Keyword);
                    }


                    //Console.WriteLine("Query Completed " + Keyword);
                    break;
                case "Load":

                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }

            return;
        }
    }
}
