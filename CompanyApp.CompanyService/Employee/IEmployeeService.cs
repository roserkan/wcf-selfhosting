using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace CompanyApp.CompanyService.EmployeeService
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Entities.Employee GetEmployee(Guid id);

        [OperationContract]
        List<Entities.Employee> GetEmployees();

        [OperationContract]
        Entities.Employee AddEmployee(Entities.Employee employee);

        [OperationContract]
        Entities.Employee DeleteEmployee(Entities.Employee employee);

        [OperationContract]
        Entities.Employee UpdateEmployee(Entities.Employee employee);

    }
}
