﻿using CompanyEmployee.Presentation.ActionFilters;
using CompanyEmployee.Presentation.ModelBinders;
using Entities.Exceptions;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployee.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    // [ResponseCache(CacheProfileName = "120SecondsDuration")]

    public class CompanyController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompanyController(IServiceManager service) => _service = service;

        [HttpGet(Name = "GetCompanies")]

        public async Task<IActionResult> GetCompanies()
        {
            //throw new Exception("Exception");
            var companies = await _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);

            return Ok(companies);
        }
        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
        [HttpGet("{id:guid}", Name = "CompanyById")]
        // [ResponseCache(Duration = 60)]  
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]

        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);
            if (company is null)
                throw new CompanyNotFoundException(id);
            return Ok(company);
        }

        [HttpPost(Name = "CreateCompany")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {

            var newCompany = await _service.CompanyService.CreateCompanyAsync(company);
            return CreatedAtRoute("CompanyById", new { id = newCompany.Id }, newCompany);
        }

        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = await _service.CompanyService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(companies);
        }
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _service.CompanyService.DeleteCompanyAsync(id, trackChanges: false);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {

            await _service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);
            return NoContent();
        }



    }
}
