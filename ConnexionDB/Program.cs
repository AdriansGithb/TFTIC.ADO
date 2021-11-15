using System;
using System.Data.SqlClient;

namespace ConnexionDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyConnectionString = @"Server=FORMAVDI1613\TFTIC;
                                        Database=Ado;
                                        Trusted_Connection=True;";

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = MyConnectionString;
            Console.WriteLine(myConnection.State);
            myConnection.Open();
            Console.WriteLine(myConnection.State);
            myConnection.Close();
            Console.WriteLine(myConnection.State);

            Console.ReadLine();   
        }
    }
}
