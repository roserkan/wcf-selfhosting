using CompanyApp.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace CompanyApp.WCF.ProjectWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProjectSRV" in both code and config file together.
    [ServiceContract]
    public interface IProjectSRV : IContract
    {
        [OperationContract]
        List<Project> GetProjects();

        [OperationContract]
        Project GetProject(Guid id);

        [OperationContract]
        Project AddProject(Project project);

        [OperationContract]
        Project DeleteProject(Project project);

        [OperationContract]
        Project UpdateProject(Project project);
    }
}
