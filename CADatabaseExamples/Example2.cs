using System;
using System.Data.SqlClient;

namespace CADatabaseExamples
{
    class Example2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Eno: ");
            int eno = Convert.ToInt32(Console.ReadLine());
            //Step-1
            SqlConnection con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");
            //Step-2
            string query = "delete from Employee where Eno="+ eno;
            SqlCommand cmd = new SqlCommand(query, con);
            //Step-3
            con.Open();
            //Step-4
            int i = cmd.ExecuteNonQuery();
            //Step-5
            con.Close();
            if (i != 0)
                Console.WriteLine("Record Deleted");
            else
                Console.WriteLine("Record Not Deleted");

            Console.Read();
        }
    }
}
