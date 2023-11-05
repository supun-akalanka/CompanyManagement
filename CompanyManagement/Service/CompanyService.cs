using CompanyManagement.Models;
using CompanyManagement.Repository;

namespace CompanyManagement.Service
{
    public class CompanyService: ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetAllCompanies()
        
        {
            try 
            {
            return await _companyRepository.GetAllCompanies();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Company>(); 
            }
        }
        public async Task AddCompany(AddCompanyViewModel addCompanyViewModel)
        {
            try 
            { 
            var company = new Company()
            {
                Id = Guid.NewGuid(),
                Name = addCompanyViewModel.Name,
                Address = addCompanyViewModel.Address,
                Contact = addCompanyViewModel.Contact,
                Email = addCompanyViewModel.Email,
            };
            await _companyRepository.AddCompany(company);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public async Task<UpdateCompanyViewModel> GetCompanyById(Guid id)
        {
            try
            { 
            var company = await _companyRepository.GetCompanyById(id);

            if (company != null)
            {
                var updateviewModel = new UpdateCompanyViewModel()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Address = company.Address,
                    Contact = company.Contact,
                    Email = company.Email
                };

                return updateviewModel;
            }

            return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
            

        public async Task UpdateCompany(UpdateCompanyViewModel updateVM)
        {
            try 
            { 
            var company = await _companyRepository.GetCompanyById(updateVM.Id);

                if (company != null)
                {
                    company.Name = updateVM.Name;
                    company.Address = updateVM.Address;
                    company.Contact = updateVM.Contact;
                    company.Email = updateVM.Email;

                    await _companyRepository.UpdateCompany(company);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public async Task DeleteCompany(Guid id)
        {
            try 
            { 
            var company = await _companyRepository.GetCompanyById(id);
            if (company != null)
            {
                await _companyRepository.DeleteCompany(company);
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

