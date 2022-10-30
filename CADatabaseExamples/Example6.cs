using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CADatabaseExamples
{
    class Example6
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee",con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            foreach (DataRow item in ds.Tables["Employee"].Rows)
            {
                Console.WriteLine($"{item["Eno"]} -> {item["Ename"]}  ->  {item["Job"]}  ->  {item["Salary"]}  ->  {item["Dname"]}");
            }
            Console.Read();
        }
    }
}
