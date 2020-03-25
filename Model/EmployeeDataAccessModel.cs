using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmplyeeDetail.Models
{
    public class EmployeeDataAccessModel
    {
  
            string connectionString = "Server=DESKTOP-B9B7TGQ\\Sana; Database=EmployeeDB;User Id=sa;Password=123";

        //To View all employees details             
        public IEnumerable<EmployeeDataModel> GetAllEmployees()
        {
            List<EmployeeDataModel> lstemployee = new List<EmployeeDataModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure; con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeDataModel employee = new EmployeeDataModel();
                    //employee.EmployeelD = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.LastName = rdr["LastName"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.HiredDate = rdr["HiredDate"].ToString();
                    employee.Salary = rdr["Salary"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }


        //To Add new employee record             
        public void AddEmployee(EmployeeDataModel employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName ", employee.LastName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@HiredDate ", employee.HiredDate);
                cmd.Parameters.AddWithValue("@Salary ", employee.Salary);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee            
        public void UpdateEmployee(EmployeeDataModel employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeelD", employee.EmployeelD);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName ", employee.LastName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@HiredDate ", employee.HiredDate);
                cmd.Parameters.AddWithValue("@Salary ", employee.Salary);
                con.Open();
                cmd.ExecuteNonQuery(); con.Close();
            }
        }

        //Get the details of a particular employee            
        public EmployeeDataModel GetEmployeeData(int? EmployeelD)
        {
            EmployeeDataModel employee = new EmployeeDataModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Employee WHERE EmployeelD= " + EmployeelD;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.EmployeelD = Convert.ToInt32(rdr["EmployeelD"]);
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.LastName = rdr["LastName"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.HiredDate = rdr["HiredDate"].ToString();
                    employee.Salary = rdr["Salary"].ToString();
                }
            }
    
            return employee;
        }


        //To Delete the record on a particular employee            
        public void DeleteEmployee(int? EmployeelD)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", EmployeelD);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}


