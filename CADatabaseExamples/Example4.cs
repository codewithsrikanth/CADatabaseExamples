using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CADatabaseExamples
{
    public class Employee
    {
        public int Eno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public string Dname { get; set; }
    }    
    public class DBOperations
    {
        public Employee GetEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Employee Details: ");
            employee.Eno = Convert.ToInt32(Console.ReadLine());
            employee.Ename = Console.ReadLine();
            employee.Job = Console.ReadLine();
            employee.Salary = Convert.ToDouble(Console.ReadLine());
            employee.Dname = Console.ReadLine();
            return employee;
        }
        public void Insert(Employee emp)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ToString());
            string query = $"insert into Employee values({emp.Eno},'{emp.Ename}','{emp.Job}',{emp.Salary},'{emp.Dname}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
                Console.WriteLine("Record Inserted");
            else
                Console.WriteLine("Record Not Inserted");
        }
        public void Update(Employee emp)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ToString());
            SqlCommand cmd = new SqlCommand("sp_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eno",emp.Eno);
            cmd.Parameters.AddWithValue("@ename",emp.Ename);
            cmd.Parameters.AddWithValue("@job",emp.Job);
            cmd.Parameters.AddWithValue("@salary",emp.Salary);
            cmd.Parameters.AddWithValue("@dname",emp.Dname);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
                Console.WriteLine("Record Updated");
            else
                Console.WriteLine("Record Not Updated");


        }
        public void Delete(int id)
        {
            
        }
    }
    class Example4
    {
        static void Main(string[] args)
        {
            DBOperations obj = new DBOperations();
            Console.WriteLine("Enter DB Operation:(Update/Delete/Insert) ");
            string choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "INSERT":
                    Employee emp = obj.GetEmployee();
                    obj.Insert(emp);
                    break;
                case "UPDATE":
                    Employee emp1 = obj.GetEmployee();
                    obj.Update(emp1);
                    break;
                case "DELETE":
                    Console.WriteLine("Enter Eno to delete:");
                    int eno = Convert.ToInt32(Console.ReadLine());
                    obj.Delete(eno);
                    break;
                default:
                    Console.WriteLine("Invalid Operation");
                    break;
            }
            Console.Read();
        }
    }
}
