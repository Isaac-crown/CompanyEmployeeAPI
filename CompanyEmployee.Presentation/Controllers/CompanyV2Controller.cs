using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace CompanyEmployee.Presentation.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/{v:apiVersion}/[controller]")]

    public class CompanyV2Controller : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CompanyV2Controller(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _serviceManager.CompanyService
            .GetAllCompaniesAsync(trackChanges: false);
            var companiesV2 = companies.Select(x => $"{x.Name} V2");
            return Ok(companiesV2);
        }

    }
}