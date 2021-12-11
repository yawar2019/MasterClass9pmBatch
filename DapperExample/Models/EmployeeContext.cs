using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
namespace DapperExample.Models
{

    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection(@"Data Source=AZAM-PC\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");

        public List<EmployeeModel> GetEmployees()
        {
            return con.Query<EmployeeModel>("sp_getEmployee_Rock", commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        public int SaveEmployee(EmployeeModel emp)
        {
            int result = 0;
            var parameter = new DynamicParameters();
            parameter.Add("@EmpName", emp.EmpName);
            parameter.Add("@EmpSalary", emp.EmpSalary);

            if (emp.EmpId > 0)
            {
                parameter.Add("@EmpId", emp.EmpId);
                result = con.Execute("sp_RajaUpdateEmployee", param: parameter, commandType: System.Data.CommandType.StoredProcedure);
            }

            else
            {
                result = con.Execute("sp_InsertEmployee", param: parameter, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }
        public EmployeeModel GetEmployeeById(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EmpId", id);

            EmployeeModel emp = con.QuerySingleOrDefault<EmployeeModel>("sp_RajagetEmployeeById", param: parameter, commandType: System.Data.CommandType.StoredProcedure);

            return emp;
        }


        public int DeleteEmployeeById(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EmpId", id);

            int i = con.Execute("usp_DeleteEmployeeById", param: parameter, commandType: System.Data.CommandType.StoredProcedure);

            return i;
        }


    }
}