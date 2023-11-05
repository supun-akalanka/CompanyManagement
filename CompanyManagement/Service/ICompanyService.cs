using CompanyManagement.Models;

namespace CompanyManagement.Service
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllCompanies();
        Task AddCompany(AddCompanyViewModel addCompanyViewModel);
        Task<UpdateCompanyViewModel> GetCompanyById(Guid id);
        Task UpdateCompany(UpdateCompanyViewModel updateVM);
        Task DeleteCompany(Guid id);
    }
}
