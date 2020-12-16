using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalCodeInterview.DataLibrary.Data;
using TechnicalCodeInterview.DataLibrary.Models;
using TechnicalCodeInterview.WebApp.Models;

namespace TechnicalCodeInterview.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeData employeeData;

        public EmployeeController(IEmployeeData employeeData)
        {
            this.employeeData = employeeData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Display()
        {
            var employee = await this.employeeData.GetEmployee();

            return View(employee);
        }

        public async Task<IActionResult> DisplayById(int id)
        {
            EmployeeDisplayModel displayEmployee = new EmployeeDisplayModel();
            displayEmployee.Employee = await this.employeeData.GetEmployeeById(id);

            return View(displayEmployee);
        }

        public async Task<IActionResult> Create()
        {
            var employee = await this.employeeData.GetEmployee();

            EmployeeCreateModel model = new EmployeeCreateModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel employee)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            await this.employeeData.InsertEmployee(employee);

            return RedirectToAction("Display");
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string firstName, string middleName, string lastName)
        {
            await this.employeeData.UpdateEmployee(id, firstName, middleName, lastName);

            return RedirectToAction("DisplayById", new { id });

        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await this.employeeData.GetEmployeeById(id);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeModel employee)
        {
            await this.employeeData.DeleteEmployee(employee.Id);

            return RedirectToAction("Display");
        }
    }
}
