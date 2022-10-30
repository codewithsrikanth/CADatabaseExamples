using System;
using System.Data;
using System.Data.SqlClient;

namespace CADatabaseExamples
{
    class Example1
    {
        static void Main()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("server=.;database=CompanyDB;integrated security=true");
                //con.ConnectionString = "server=.;database=CompanyDB;integrated security=true";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                Console.WriteLine("Connection Opend");                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                Console.Read();
            }
            
        }
    }
}
