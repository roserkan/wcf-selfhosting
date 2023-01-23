using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.Business.Abstract
{
    public interface IProjectService
    {
        List<Project> GetProjects();
        Project GetProject(Guid id);
        Project AddProject(Project project);
        Project DeleteProject(Project project);
        Project UpdateProject(Project project);
    }
}
