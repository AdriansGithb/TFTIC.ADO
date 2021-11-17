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
            #region ExeSqlConnection
            //Exe SqlConnection
            //SqlConnection myConnection = new SqlConnection();
            //myConnection.ConnectionString = MyConnectionString;
            //Console.WriteLine(myConnection.State);
            //myConnection.Open();
            //Console.WriteLine(myConnection.State);
            //myConnection.Close();
            //Console.WriteLine(myConnection.State);

            //Console.ReadLine();   
            #endregion

            #region Exe Modes Connexions
            //// ID, Nom, Prenom de V_Student en mode connecté
            //Console.WriteLine("Afficher l’ID, le Nom, le Prenom de chaque étudiant depuis la vue V_Student en utilisant la méthode connectée");
            //using (SqlConnection myConnection = new SqlConnection())
            //{
            //    myConnection.ConnectionString = MyConnectionString;
            //    using (SqlCommand cmd = myConnection.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT Id, LastName, FirstName " +
            //                        "FROM V_Student";
            //        myConnection.Open();
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                Console.WriteLine($"{reader["Id"]} - {reader["LastName"]} {reader["FirstName"]}");
            //            }
            //        }
            //        myConnection.Close();
            //    }
            //}

            ////ID, Nom de chaque section en mode déconnecté
            //Console.WriteLine();
            //Console.WriteLine("Afficher l’ID, le Nom de chaque section en utilisant la méthode déconnectée");
            //using (SqlConnection myConnection = new SqlConnection())
            //{
            //    myConnection.ConnectionString = MyConnectionString;
            //    using (SqlCommand cmd = myConnection.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT * " +
            //                        "FROM Section";
            //        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            //        mySqlDataAdapter.SelectCommand = cmd;
            //        DataTable myDataTable = new DataTable();
            //        mySqlDataAdapter.Fill(myDataTable);

            //        foreach(DataRow row in myDataTable.Rows)
            //        {
            //            Console.WriteLine($"{row["Id"]} - {row["SectionName"]}");
            //        }
            //    }
            //}

            ////Afficher la moyenne annuelle des étudiants
            //Console.WriteLine();
            //Console.WriteLine("Afficher la moyenne annuelle des étudiants");
            ////en mode connecté
            //using (SqlConnection myConnection = new SqlConnection())
            //{
            //    myConnection.ConnectionString = MyConnectionString;
            //    using (SqlCommand cmd = myConnection.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT AVG(YearResult) " +
            //                        "FROM V_Student";
            //        myConnection.Open();
            //        int avg = (int)cmd.ExecuteScalar();
            //        myConnection.Close();
            //        Console.WriteLine($"En mode connecté : {avg}");
            //    }
            //}

            ////en mode déconnecté
            //using (SqlConnection myConnection = new SqlConnection())
            //{
            //    myConnection.ConnectionString = MyConnectionString;
            //    using (SqlCommand cmd = myConnection.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT AVG(YearResult) " +
            //                        "FROM V_Student";
            //        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            //        mySqlDataAdapter.SelectCommand = cmd;
            //        DataTable myDataTable = new DataTable();
            //        mySqlDataAdapter.Fill(myDataTable);

            //        foreach (DataRow row in myDataTable.Rows)
            //        {
            //            Console.WriteLine($"En mode déconnecté : {row[0]}");
            //        }
            //    }
            //}

            #endregion

            #region Exe Insertion/modif/suppression des donnees
            ////classe Student ajoutée
            //Student newStudent = new Student() { FirstName = "Adrian", LastName = "Vanhoeke", SectionId = 1010, BirthDate = new DateTime(1985,10,21), YearResult = 14 };
            //using(SqlConnection myConnection = new SqlConnection())
            //{
            //    myConnection.ConnectionString = MyConnectionString;
            //    using (SqlCommand cmd = myConnection.CreateCommand())
            //    {
            //        cmd.CommandText = "insert into Student (FirstName, LastName,BirthDate,  SectionId, YearResult) output inserted.ID values (" +
            //            $"'{ newStudent.FirstName} '," +
            //            $"'{newStudent.LastName}'," +
            //            $"'{newStudent.BirthDate.ToString("s")}'," + // le "s" est pour le format de la date vu que sqlServer attend le format yyyy-mm-dd
            //            $"{newStudent.SectionId}," +
            //            $"{newStudent.YearResult});";
            //        myConnection.Open();
            //        newStudent.Id = (int)cmd.ExecuteScalar();
            //        myConnection.Close();
            //        Console.WriteLine($"L'id de {newStudent.FirstName} {newStudent.LastName} est {newStudent.Id}");
            //    }
            //}


            #endregion

            #region Exe Requetes parametrees
            Student newStudent = new Student() { FirstName = "Steve", LastName = "Lorent", SectionId = 1010, BirthDate = new DateTime(1983, 06, 28), YearResult = 16 };
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString = MyConnectionString;
                using (SqlCommand cmd = myConnection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Student (FirstName, LastName,BirthDate,  SectionId, YearResult) OUTPUT inserted.ID VALUES (@FirstName, @LastName, @BirthDate, @SectionId, @YearResult); ";
                    cmd.Parameters.AddWithValue("FirstName", newStudent.FirstName);
                    cmd.Parameters.AddWithValue("LastName", newStudent.LastName);
                    cmd.Parameters.AddWithValue("BirthDate", newStudent.BirthDate);
                    cmd.Parameters.AddWithValue("SectionId", newStudent.SectionId);
                    cmd.Parameters.AddWithValue("YearResult", newStudent.YearResult);
                    //ou en créant des SqlParameters
                    //SqlParameter Pfn = new SqlParameter
                    //{
                    //    ParameterName = "FirstName",
                    //    Value = newStudent.FirstName
                    //};
                    //cmd.Parameters.Add(Pfn);

                    myConnection.Open();
                    object o = cmd.ExecuteScalar();
                    myConnection.Close();
                    newStudent.Id = (o is DBNull) ? -1 : (int)o;
                    Console.WriteLine($"L'id de {newStudent.FirstName} {newStudent.LastName} est {newStudent.Id}");
                }
            }

            #endregion


        }
    }
}
