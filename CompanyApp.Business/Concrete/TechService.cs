using CompanyApp.Business.Abstract;
using CompanyApp.DataAccess.Abstract;
using CompanyApp.Entities;
using System;
using System.Collections.Generic;

namespace CompanyApp.Business.Concrete
{
    public class TechService : ITechService
    {
        private readonly ITechRepository _techRepository;

        public TechService(ITechRepository techRepository)
        {
            _techRepository = techRepository;
        }

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
            var result = _techRepository.Get(
                    e => e.Id == id,
                    true
                );
            return result;
        }

        public List<Tech> GetTechs()
        {
            var result = _techRepository.GetList(
                    null,
                    true,
                    null
                );

            return result;
        }

        public Tech UpdateTech(Tech tech)
        {
            return _techRepository.Update(tech);
        }
    }
}
