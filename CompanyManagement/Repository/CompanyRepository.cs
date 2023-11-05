using CompanyManagement.Data;
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Repository
{
    public class CompanyRepository:ICompanyRepository
    {
        private readonly CompanyDBContext _companyDBContext;
        public CompanyRepository(CompanyDBContext companyDBContext)
        {
            this._companyDBContext = companyDBContext;
        }
        public async Task<List<Company>> GetAllCompanies()
        {
            try 
            { 
                return await _companyDBContext.Company.ToListAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Company>();
            }
        }
        public async Task AddCompany(Company company)
        {
            try 
            { 
                await _companyDBContext.Company.AddAsync(company);
                await _companyDBContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");
            }
        }
        public async Task<Company> GetCompanyById(Guid id)
        {
            try
            { 
                return await _companyDBContext.Company.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task UpdateCompany(Company company)
        {
            try 
            {
                _companyDBContext.Entry(company).State = EntityState.Modified;
                await _companyDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");
            }
        }
        public async Task DeleteCompany(Company company)
        {
            try 
            { 
                _companyDBContext.Company.Remove(company);
                await _companyDBContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");
            }
        }
    }
}
