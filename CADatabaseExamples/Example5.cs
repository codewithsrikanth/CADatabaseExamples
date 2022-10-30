using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CADatabaseExamples
{
    class Example5
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Employee", con);
            con.Open();
            SqlDataReader dr =  cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["Eno"]} -> {dr["Ename"]}  ->  {dr["Job"]}  ->  {dr["Salary"]}  ->  {dr["Dname"]}");
                }
            }
            con.Close();
            Console.Read();
        }
    }
}
