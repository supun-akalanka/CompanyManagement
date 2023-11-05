using CompanyManagement.Controllers;
using CompanyManagement.Data;
using CompanyManagement.Models;
using CompanyManagement.Repository;
using CompanyManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.Design;

namespace TestCompany
{
    public class UnitTestService
    {
        [Fact]
        public async Task Add_Valid_Company_()
        {
            //Arrange
            var addCompanyViewModel = new AddCompanyViewModel
            {
                Name = "Test",
                Address = "Test Address",
                Contact = "1234567890",
                Email = "test@example.com"
            };
            var companyRepositoyMock = new Mock<ICompanyRepository>();
            var companyService = new CompanyService(companyRepositoyMock.Object);

            //Act
            await companyService.AddCompany(addCompanyViewModel);

            //Assert
            companyRepositoyMock.Verify(repo => repo.AddCompany(It.Is<Company>
                   (c =>
                    c.Name == addCompanyViewModel.Name &&
                    c.Address == addCompanyViewModel.Address &&
                    c.Contact == addCompanyViewModel.Contact &&
                    c.Email == addCompanyViewModel.Email
                )), Times.Once);
        }

        [Fact]
        public async Task GetCompanyId_Return_UpdateCompanyViewModel()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            var company = new Company
            {
                Id = companyId,
                Name = "Test Company",
                Address = "Test Address",
                Contact = "Test Contact",
                Email = "test@example.com"
            };
            var companyRepositoyMock = new Mock<ICompanyRepository>();
            var companyService = new CompanyService(companyRepositoyMock.Object);
            companyRepositoyMock.Setup(repo => repo.GetCompanyById(companyId)).ReturnsAsync(company);

            // Act
            var result = await companyService.GetCompanyById(companyId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(company.Id, result.Id);
            Assert.Equal(company.Name, result.Name);
            Assert.Equal(company.Address, result.Address);
            Assert.Equal(company.Contact, result.Contact);
            Assert.Equal(company.Email, result.Email);
        }
        [Fact]
        public async Task UpdateCompany()
        {
            // Arrange
            var updateCompanyViewModel = new UpdateCompanyViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Updated Company",
                Address = "Updated Address",
                Contact = "Updated Contact",
                Email = "updated@example.com"
            };

            var company = new Company
            {
                Id = updateCompanyViewModel.Id,
                Name = "Old Company",
                Address = "Old Address",
                Contact = "Old Contact",
                Email = "old@example.com"
            };
            var companyRepositoyMock = new Mock<ICompanyRepository>();
            var companyService = new CompanyService(companyRepositoyMock.Object);

            companyRepositoyMock.Setup(repo => repo.GetCompanyById(updateCompanyViewModel.Id)).ReturnsAsync(company);
            // Act
            await companyService.UpdateCompany(updateCompanyViewModel);

            // Assert
            companyRepositoyMock.Verify(repo => repo.UpdateCompany(
                It.Is<Company>(c =>
                    c.Id == updateCompanyViewModel.Id &&
                    c.Name == updateCompanyViewModel.Name &&
                    c.Address == updateCompanyViewModel.Address &&
                    c.Contact == updateCompanyViewModel.Contact &&
                    c.Email == updateCompanyViewModel.Email
                )
            ), Times.Once);
        }
        [Fact]
        public async Task DeleteCompany()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            var company = new Company
            {
                Id = companyId,
                Name = "Test Company",
                Address = "Test Address",
                Contact = "Test Contact",
                Email = "test@example.com"
            };
            var companyRepositoyMock = new Mock<ICompanyRepository>();
            var companyService = new CompanyService(companyRepositoyMock.Object);
            companyRepositoyMock.Setup(repo => repo.GetCompanyById(companyId)).ReturnsAsync(company);
            // Act
            await companyService.DeleteCompany(companyId);

            // Assert
            companyRepositoyMock.Verify(repo => repo.DeleteCompany(
                It.Is<Company>(c =>
                    c.Id == companyId &&
                    c.Name == company.Name &&
                    c.Address == company.Address &&
                    c.Contact == company.Contact &&
                    c.Email == company.Email
                )
            ), Times.Once);
        }
        [Fact]  
        public async Task Get_All_Companies()
        {
            var companyId_1 = Guid.NewGuid();
            var companyId_2 = Guid.NewGuid();
            // Arrange
            var companies = new List<Company>
            {
                new Company { Id = companyId_1, Name = "Company1" },
                new Company { Id = companyId_2, Name = "Company2" },
            };
            var companyRepositoyMock = new Mock<ICompanyRepository>();
            var companyService = new CompanyService(companyRepositoyMock.Object);
            companyRepositoyMock.Setup(repo => repo.GetAllCompanies()).ReturnsAsync(companies);
            // Act
            var result = await companyService.GetAllCompanies();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(companies.Count, result.Count);
        }
    }
}