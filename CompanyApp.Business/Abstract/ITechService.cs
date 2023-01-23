using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.Business.Abstract
{
    public interface ITechService
    {
        List<Tech> GetTechs();
        Tech GetTech(Guid id);
        Tech AddTech(Tech tech);
        Tech DeleteTech(Tech tech);
        Tech UpdateTech(Tech tech);
    }
}
