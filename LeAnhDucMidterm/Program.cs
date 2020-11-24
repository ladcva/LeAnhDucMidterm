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
        static void Main(string[] args)
        {
            string Cnn = ConfigurationManager.ConnectionStrings["MidTermCon"].ConnectionString;
            string Cmd = "";
            if (args.Length > 0)
                Cmd = args[0];

            PostModel OnePost = new PostModel();

            switch (Cmd.ToLower())
            {
                case "add":
                    //Code add here
                    if (args.Length != 4)
                    {
                        Console.WriteLine("usage: Add Title Summary Content");
                        return;
                    }
                    OnePost.Title = args[1];
                    OnePost.Summary = args[2];
                    OnePost.Content = args[3];

                    //Write your code to add Title, Sumary, Content into database

                    Console.WriteLine("Title : " + OnePost.Title);
                    Console.WriteLine("Summary : " + OnePost.Summary);
                    Console.WriteLine("Content : " + OnePost.Content);

                    PostController insert = new PostController();
                    insert.AddOnePost(OnePost);

                    break;
                case "delete":

                    if (args.Length != 2)
                    {
                        Console.WriteLine("usage: Delete Id");
                        return;
                    }
                    //Get string from the second paramenters
                    string StrId = args[1];
                    //Convert the second parameter into in, stored in Id variable
                    bool isValid = int.TryParse(StrId, out OnePost.Id);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid Id " + StrId);
                        return;
                    }
                    /*Code Delete here with the paramenter Id */
                    if (OnePost.Id > 0)
                    {
                        /*write your code here */
                    }


                    Console.WriteLine("Delete completed " + StrId);
                    break;
                case "list":
                    if (args.Length != 2)
                    {
                        Console.WriteLine("usage: List Keyword");
                        return;
                    }
                    string Keyword = args[1];
                    if (string.IsNullOrEmpty(Keyword))
                    {
                        //Code search with no keyword
                    }
                    else
                    {
                        //Code search with keyword
                    }


                    Console.WriteLine("Query Completed " + Keyword);
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
