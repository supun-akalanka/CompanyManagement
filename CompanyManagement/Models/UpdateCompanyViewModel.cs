namespace CompanyManagement.Models
{
    public class UpdateCompanyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }
}
