using CompanyApp.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace CompanyApp.WCF.TechWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITechSRV" in both code and config file together.
    [ServiceContract]
    public interface ITechSRV : IContract
    {
        [OperationContract]
        List<Tech> GetTechs();

        [OperationContract]
        Tech GetTech(Guid id);

        [OperationContract]
        Tech AddTech(Tech tech);

        [OperationContract]
        Tech DeleteTech(Tech tech);

        [OperationContract]
        Tech UpdateTech(Tech tech);
    }
}
