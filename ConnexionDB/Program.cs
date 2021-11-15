using System;
using System.Data;
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
            //Exe SqlConnection
            //SqlConnection myConnection = new SqlConnection();
            //myConnection.ConnectionString = MyConnectionString;
            //Console.WriteLine(myConnection.State);
            //myConnection.Open();
            //Console.WriteLine(myConnection.State);
            //myConnection.Close();
            //Console.WriteLine(myConnection.State);

            //Console.ReadLine();   

            //Exe Modes Connexions
            // ID, Nom, Prenom de V_Student en mode connecté
            Console.WriteLine("Afficher l’ID, le Nom, le Prenom de chaque étudiant depuis la vue V_Student en utilisant la méthode connectée");
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString = MyConnectionString;
                using (SqlCommand cmd = myConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, LastName, FirstName " +
                                    "FROM V_Student";
                    myConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Id"]} - {reader["LastName"]} {reader["FirstName"]}");
                        }
                    }
                    myConnection.Close();
                }
            }

            //ID, Nom de chaque section en mode déconnecté
            Console.WriteLine();
            Console.WriteLine("Afficher l’ID, le Nom de chaque section en utilisant la méthode déconnectée");
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString = MyConnectionString;
                using (SqlCommand cmd = myConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * " +
                                    "FROM Section";
                    SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
                    mySqlDataAdapter.SelectCommand = cmd;
                    DataTable myDataTable = new DataTable();
                    mySqlDataAdapter.Fill(myDataTable);

                    foreach(DataRow row in myDataTable.Rows)
                    {
                        Console.WriteLine($"{row["Id"]} - {row["SectionName"]}");
                    }
                }
            }

            //Afficher la moyenne annuelle des étudiants
            Console.WriteLine();
            Console.WriteLine("Afficher la moyenne annuelle des étudiants");
            //en mode connecté
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString = MyConnectionString;
                using (SqlCommand cmd = myConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT AVG(YearResult) " +
                                    "FROM V_Student";
                    myConnection.Open();
                    int avg = (int)cmd.ExecuteScalar();
                    myConnection.Close();
                    Console.WriteLine($"En mode connecté : {avg}");
                }
            }

            //en mode déconnecté
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString = MyConnectionString;
                using (SqlCommand cmd = myConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT AVG(YearResult) " +
                                    "FROM V_Student";
                    SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
                    mySqlDataAdapter.SelectCommand = cmd;
                    DataTable myDataTable = new DataTable();
                    mySqlDataAdapter.Fill(myDataTable);

                    foreach (DataRow row in myDataTable.Rows)
                    {
                        Console.WriteLine($"En mode déconnecté : {row[0]}");
                    }
                }
            }



        }
    }
}
