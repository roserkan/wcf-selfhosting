using CompanyApp.Business.Abstract;
using CompanyApp.Core.Aspects;
using CompanyApp.DataAccess.Abstract;
using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.Business.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee AddEmployee(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public Employee DeleteEmployee(Employee employee)
        {
            return _employeeRepository.Delete(employee);
        }

        public Employee GetEmployee(Guid id)
        {
            var result = _employeeRepository.Get(
                    e => e.Id == id,
                    true,
                    p => p.Project, p => p.EmployeeTechs
                );

            result.Project.Employees = null;
            foreach (var emp in result.EmployeeTechs)
            {
                emp.Employee = null;
            }

            return result;
        }

        [ApiKeyAspect]
        public List<Employee> GetEmployees()
        {
            var result = _employeeRepository.GetList(
                    null,
                    true,
                    null,
                    p => p.Project
                );

            foreach (var item in result)
            {
                item.Project.Employees = null;
            }
            return result;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
    }
}
