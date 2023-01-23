using CompanyApp.Business.Abstract;
using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.WCF.TechWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TechSRV" in both code and config file together.
    public class TechSRV : ITechSRV
    {
        private readonly ITechService _techService;


        public TechSRV(ITechService techService)
        {
            _techService = techService;
        }

        public Tech AddTech(Tech tech)
        {
            return _techService.AddTech(tech);
        }

        public Tech DeleteTech(Tech tech)
        {
            return _techService.DeleteTech(tech);
        }

        public Tech GetTech(Guid id)
        {
            return _techService.GetTech(id);
        }

        public List<Tech> GetTechs()
        {
            return _techService.GetTechs();
        }

        public Tech UpdateTech(Tech tech)
        {
            return _techService.UpdateTech(tech);
        }
    }
}
