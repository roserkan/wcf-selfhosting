using CompanyApp.DataAccess.Abstract;
using CompanyApp.DataAccess.Concrete.EFRepositories;
using CompanyApp.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CompanyApp.CompanyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompanyService" in both code and config file together.
    public class CompanyService : ICompanyService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITechRepository _techRepository;

        public CompanyService(IEmployeeRepository employeeRepository, IProjectRepository projectRepository, ITechRepository techRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _techRepository = techRepository;
        }

        //public CompanyService():this(new EFEmployeeRepository(), new EFProjectRepository(), new EFTechRepository())
        //{
            
        //}

        #region EmployeeService

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

            return result;
        }

        public List<Employee> GetEmployees()
        {
            OperationContext operationContext = OperationContext.Current;
            RequestContext requestContext = operationContext.RequestContext;
            MessageHeaders headers = requestContext.RequestMessage.Headers;
            int headerValue = headers.FindHeader("Username", string.Empty);
            int headerValue2 = headers.FindHeader("Email", string.Empty);

            string userName = (headerValue < 0) ? "Bulunamadı" : headers.GetHeader<string>(headerValue);
            string email = (headerValue < 0) ? "Bulunamadı" : headers.GetHeader<string>(headerValue2);

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

        #endregion EmployeeService


        #region ProjectService

        public Project AddProject(Project project)
        {
            return _projectRepository.Add(project);
        }

        public Project DeleteProject(Project project)
        {
            return _projectRepository.Delete(project);
        }

        public Project GetProject(Guid id)
        {
            return _projectRepository.Get(
                    e => e.Id == id,
                    true,
                    p => p.Employees
                );
        }

        public List<Project> GetProjects()
        {
            var result = _projectRepository.GetList(
                    null,
                    true,
                    null
                );

            //foreach (var item in result)
            //{
            //    item.Employees = null;
            //}
            return result;
        }

        public Project UpdateProject(Project project)
        {
            return _projectRepository.Update(project);
        }
        #endregion ProjectService


        #region TechService

        public Tech AddTech(Tech tech)
        {
            return _techRepository.Add(tech);
        }

        public Tech DeleteTech(Tech tech)
        {
            return _techRepository.Delete(tech);
        }

        public Tech GetTech(Guid id)
        {
            return _techRepository.Get(
                    e => e.Id == id,
                    true
                );
        }

        public List<Tech> GetTechs()
        {
            var result = _techRepository.GetList(
                    null,
                    true,
                    null
                );

            //foreach (var item in result)
            //{
            //    item.Project.Techs = null;
            //}
            return result;
        }

        public Tech UpdateTech(Tech tech)
        {
            return _techRepository.Update(tech);
        }
        #endregion TechService

    }
}
