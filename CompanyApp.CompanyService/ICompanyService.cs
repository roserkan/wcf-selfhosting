using CompanyApp.CompanyService.EmployeeService;
using CompanyApp.CompanyService.ProjectService;
using CompanyApp.CompanyService.TechService;
using System.ServiceModel;

namespace CompanyApp.CompanyService
{
    [ServiceContract]
    public interface ICompanyService: IEmployeeService, IProjectService, ITechService
    {
    }

   


}
