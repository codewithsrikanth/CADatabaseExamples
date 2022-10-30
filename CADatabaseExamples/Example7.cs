using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.ComponentModel.Design;

namespace CADatabaseExamples
{
    class Example7
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            da.FillSchema(ds,SchemaType.Source);
            foreach (DataRow item in ds.Tables["Employee"].Rows)
            {
                Console.WriteLine($"{item["Eno"]} -> {item["Ename"]}  ->  {item["Job"]}  ->  {item["Salary"]}  ->  {item["Dname"]}");
            }

            Console.WriteLine("Select your Operation:");
            string op = Console.ReadLine();
            switch (op)
            {
                case "insert":
                    DataRow row = ds.Tables["Employee"].NewRow();
                    Console.WriteLine("Enter Employee Details: ");
                    row["Eno"] = Console.ReadLine();
                    row["Ename"] = Console.ReadLine();
                    row["Job"] = Console.ReadLine();
                    row["Salary"] = Console.ReadLine();
                    row["Dname"] = Console.ReadLine();
                    ds.Tables["Employee"].Rows.Add(row);
                    SqlCommandBuilder bldr = new SqlCommandBuilder(da);
                    if (ds.HasChanges())
                    {
                        da.Update(ds,"Employee");
                        Console.WriteLine("Record Inserted");
                    }
                    break;
                default:
                    break;
            }
            Console.Read();
        }
    }
}
