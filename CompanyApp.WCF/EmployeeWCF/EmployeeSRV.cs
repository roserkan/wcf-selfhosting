using CompanyApp.Business.Abstract;
using CompanyApp.Core.Aspects;
using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.WCF.EmployeeWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeSRV" in both code and config file together.
    public class EmployeeSRV : IEmployeeSRV
    {
        private readonly IEmployeeService _employeeService;


        public EmployeeSRV(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Employee AddEmployee(Employee employee)
        {
            return _employeeService.AddEmployee(employee);
        }

        public Employee DeleteEmployee(Employee employee)
        {
            return _employeeService.DeleteEmployee(employee);
        }

        public Employee GetEmployee(Guid id)
        {
            return _employeeService.GetEmployee(id);
        }

        [ApiKeyAspect]
        public List<Employee> GetEmployees()
        {
            return _employeeService.GetEmployees();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return _employeeService.UpdateEmployee(employee);
        }
    }
}
