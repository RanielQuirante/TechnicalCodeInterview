using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalCodeInterview.DataLibrary.Db;
using TechnicalCodeInterview.DataLibrary.Models;

namespace TechnicalCodeInterview.DataLibrary.Data
{
    public class EmployeeData : IEmployeeData
    {
        private readonly IDataAccess dataAccess;
        private readonly ConnectionStringData connectionString;

        public EmployeeData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            this.dataAccess = dataAccess;
            this.connectionString = connectionString;
        }

        public Task<List<EmployeeModel>> GetEmployee()
        {
            return this.dataAccess.LoadData<EmployeeModel, dynamic>("dbo.spEmployee_All",
                                                                    new { },
                                                                    this.connectionString.SqlConnectionName);
        }

        public async Task<EmployeeModel> GetEmployeeById(int employeeId)
        {
            var recs = await this.dataAccess.LoadData<EmployeeModel, dynamic>("dbo.spEmployee_GetById",
                                                                           new
                                                                           {
                                                                               Id = employeeId
                                                                           },
                                                                           this.connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }

        public async Task<int> InsertEmployee(EmployeeModel employee)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("FirstName", employee.FirstName);
            p.Add("MiddleName", employee.MiddleName);
            p.Add("LastName", employee.LastName);

            return await this.dataAccess.SaveData("dbo.spEmployee_Insert",
                                           p,
                                           this.connectionString.SqlConnectionName);

        }

        public Task<int> UpdateEmployee(int employeeId, string firstName, string middleName, string lastName)
        {
            return this.dataAccess.SaveData("dbo.spEmployee_Update",
                                            new
                                            {
                                                Id = employeeId,
                                                FirstName = firstName,
                                                MiddleName = middleName,
                                                LastName = lastName
                                            },
                                            this.connectionString.SqlConnectionName);
        }

        public Task<int> DeleteEmployee(int employeeId)
        {
            return this.dataAccess.SaveData("dbo.spEmployee_Delete",
                                            new
                                            {
                                                Id = employeeId
                                            },
                                            this.connectionString.SqlConnectionName);
        }
    }
}
