using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AdoDotNet.Models
{
    public class EmployeeContext
    {
        //ConnectionString
        SqlConnection con = new SqlConnection(@"Data Source=AZAM-PC\SQLEXPRESS;Initial Catalog=YashDB;Integrated Security=true");

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> listemp = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("usp_getEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)//3
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
                listemp.Add(emp);
            }

            return listemp;
        }

        public int Save(EmployeeModel emp)
        {
            SqlCommand cmd = null;
            if (emp.EmpId > 0)
            {
                cmd = new SqlCommand("usp_UpdateEmployeeInfo", con);


                cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                cmd.CommandType = CommandType.StoredProcedure;

            }
            else
            {
                cmd = new SqlCommand("usp_saveEmployee", con);
            }


            cmd.Parameters.AddWithValue("@EmpSalary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
            cmd.CommandType = CommandType.StoredProcedure;

           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }



        public EmployeeModel GetEmployeeById(int? id)
        {
             EmployeeModel  emp = new  EmployeeModel();
            SqlCommand cmd = new SqlCommand("[usp_getEmployeeById]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue("EmpId",id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)//3
            {
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
            }

            return emp;
        }
    }
}