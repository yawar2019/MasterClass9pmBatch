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
           return  con.Query<EmployeeModel>("sp_getEmployee_Rock", commandType:System.Data.CommandType.StoredProcedure).ToList();
        }

       public int SaveEmployee(EmployeeModel emp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EmpName",emp.EmpName);
            parameter.Add("@EmpSalary",emp.EmpSalary);
            int result = con.Execute("sp_InsertEmployee",param:parameter, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
    }
}