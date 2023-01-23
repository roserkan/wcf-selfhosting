using CompanyApp.Business.Abstract;
using CompanyApp.DataAccess.Abstract;
using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.Business.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

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
            var result = _projectRepository.Get(
                    e => e.Id == id
                );

            return result;
        }

        public List<Project> GetProjects()
        {
            var result = _projectRepository.GetList(
                    null,
                    true
                );
            return result;
        }

        public Project UpdateProject(Project project)
        {
            return _projectRepository.Update(project);
        }
    }
}
