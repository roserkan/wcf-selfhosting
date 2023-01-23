using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace CompanyApp.CompanyService.ProjectService
{


    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        Entities.Project GetProject(Guid id);

        [OperationContract]
        List<Entities.Project> GetProjects();

        [OperationContract]
        Entities.Project AddProject(Entities.Project project);

        [OperationContract]
        Entities.Project DeleteProject(Entities.Project project);

        [OperationContract]
        Entities.Project UpdateProject(Entities.Project project);

    }
}
