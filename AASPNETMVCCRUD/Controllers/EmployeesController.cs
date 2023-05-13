﻿using AASPNETMVCCRUD.Data;
using AASPNETMVCCRUD.Data.Domain;
using AASPNETMVCCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
            };

            await mvcDemoDbContext.Employees.AddAsync(employee);

            await mvcDemoDbContext.SaveChangesAsync();

            return RedirectToAction("Add");
        }
    }
}
