using CompanyApp.Business.Abstract;
using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.WCF.ProjectWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProjectSRV" in both code and config file together.
    public class ProjectSRV : IProjectSRV
    {
        private readonly IProjectService _projectService;

        public ProjectSRV(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public Project AddProject(Project project)
        {
            return _projectService.AddProject(project);
        }

        public Project DeleteProject(Project project)
        {
            return _projectService.DeleteProject(project);
        }

        public Project GetProject(Guid id)
        {
            return _projectService.GetProject(id);
        }

        public List<Project> GetProjects()
        {
            return _projectService.GetProjects();
        }

        public Project UpdateProject(Project project)
        {
            return _projectService.UpdateProject(project);
        }
    }
}
