using CompanyManagement.Models;

namespace CompanyManagement.Repository
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompanies();
        Task AddCompany(Company company);
        Task<Company> GetCompanyById(Guid id);
        Task UpdateCompany(Company company);
        Task DeleteCompany(Company company);
    }
}
