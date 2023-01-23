using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace CompanyApp.CompanyService.TechService
{


    [ServiceContract]
    public interface ITechService
    {
        [OperationContract]
        Entities.Tech GetTech(Guid id);

        [OperationContract]
        List<Entities.Tech> GetTechs();

        [OperationContract]
        Entities.Tech AddTech(Entities.Tech tech);

        [OperationContract]
        Entities.Tech DeleteTech(Entities.Tech tech);

        [OperationContract]
        Entities.Tech UpdateTech(Entities.Tech tech);

    }
}
