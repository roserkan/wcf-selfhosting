using CompanyApp.Core.DataAccess.EFCore;
using CompanyApp.DataAccess.Abstract;
using CompanyApp.DataAccess.Concrete.Contexts;
using CompanyApp.Entities;

namespace CompanyApp.DataAccess.Concrete.EFRepositories
{
    public class EFProjectRepository : EFRepository<Project, CompanyAppContext>, IProjectRepository
    {
    }
}
