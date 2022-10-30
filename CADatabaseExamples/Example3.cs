using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CADatabaseExamples
{
    class Example3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Employee Details: ");
            int eno = Convert.ToInt32(Console.ReadLine());
            string ename = Console.ReadLine();
            string job = Console.ReadLine();
            double salary = Convert.ToDouble(Console.ReadLine());
            string dname = Console.ReadLine();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ToString());
            //string query = "insert into Employee values("+eno+","+ename+","+job+","+salary+","+dname+")";
            string query = $"insert into Employee values({eno},'{ename}','{job}',{salary},'{dname}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
                Console.WriteLine("Record Inserted");
            else
                Console.WriteLine("Record Not Inserted");

            Console.Read();
        }
    }
}
