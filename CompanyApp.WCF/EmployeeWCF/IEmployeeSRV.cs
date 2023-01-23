using CompanyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CompanyApp.WCF.EmployeeWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeSRV" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeSRV : IContract
    {
        [OperationContract]
        List<Employee> GetEmployees();

        [OperationContract]
        Employee GetEmployee(Guid id);

        [OperationContract]
        Employee AddEmployee(Employee employee);

        [OperationContract]
        Employee DeleteEmployee(Employee employee);

        [OperationContract]
        Employee UpdateEmployee(Employee employee);
    }
}
