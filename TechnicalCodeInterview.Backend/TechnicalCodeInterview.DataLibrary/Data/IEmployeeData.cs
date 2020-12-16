using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalCodeInterview.DataLibrary.Models;

namespace TechnicalCodeInterview.DataLibrary.Data
{
    public interface IEmployeeData
    {
        Task<List<EmployeeModel>> GetEmployee();
        Task<EmployeeModel> GetEmployeeById(int employeeId);
        Task<int> InsertEmployee(EmployeeModel employee);
        Task<int> UpdateEmployee(int employeeId, string firstName, string middleName, string lastName);
        Task<int> DeleteEmployee(int employeeId);
    }
}