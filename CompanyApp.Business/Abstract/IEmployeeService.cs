using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(Guid id);
        Employee AddEmployee(Employee employee);
        Employee DeleteEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
    }
}
