using CompanyManagement.Data;
using CompanyManagement.Models;
using CompanyManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Controllers
{
    public class CompanyController:Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try 
            { 
                var companies = await _companyService.GetAllCompanies();
                return View(companies);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Content("An error occurred. Please try again later.");
            }
        }

        [HttpGet]
        public IActionResult Add() 
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Content("An error occurred. Please try again later.");
            }
        }   

        [HttpPost]
        public async Task<IActionResult> Add(AddCompanyViewModel addCompanyViewModel)
        {
            try 
            {
                await _companyService.AddCompany(addCompanyViewModel);
                return RedirectToAction("Index");
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Content("An error occurred. Please try again later.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
            try 
            { 
            var updateviewModel = await _companyService.GetCompanyById(id);


            if (updateviewModel != null)
            {
                return await Task.Run(()=>View("View", updateviewModel));
            }

            return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Content("An error occurred. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateCompanyViewModel updateVM)
        {
            try 
            { 
                await _companyService.UpdateCompany(updateVM);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Content("An error occurred. Please try again later.");
            }
        }

        [HttpPost]  
        public async Task<IActionResult> Delete(UpdateCompanyViewModel updateVM)
        {
            try 
            { 
                await _companyService.DeleteCompany(updateVM.Id);
                return RedirectToAction("Index");
            }
            catch( Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Content("An error occurred. Please try again later.");
            }
        }
    }
}
