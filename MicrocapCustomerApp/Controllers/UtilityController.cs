using MicrocapCustomerApp.Services.Iservices;
using MicrocapCustomerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrocapCustomerApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UtilityController : Controller
    {
        private readonly IUserservice _customeAppService;


        public UtilityController(IUserservice CustomerApp)
        {
            _customeAppService = CustomerApp;

        }

        [HttpPost, Route("Registration")]
        public async Task<object> RegisterUsersAsync([FromBody] UsersViewModel users)
        {
            try
            {
               // return "";
                //return Ok(await _utilityService.InsuranceUsersAsync());
                return Ok(await _customeAppService.RegisterUsersAsync(users));
            }
            catch (Exception ex)
            {
                return BadRequest("Error finding Users.");
            }
        }


        [HttpPost, Route("Login")]
        public async Task<object> LoginUsersAsync(LoginViewModel logins)
        {
            try
            {
               // return "";
                return Ok(await _customeAppService.LoginUsersAsync(logins));
            }
            catch (Exception ex)
            {
                return BadRequest("Error finding Users.");
            }
        }

        [HttpPost, Route("CompanyRegistration")]
        public async Task<object> RegisterCompanyAsync(CompanyViewModel company)
        {
            try
            {
                //return "";
                return Ok(await _customeAppService.RegisterCompanyAsync(company));
            }
            catch (Exception ex)
            {
                return BadRequest("Error.");
            }
        }
        [HttpPost, Route("GetCompany")]
        public async Task<object> GetCompanyAsync()
        {
            try
            {
                //return "";
                return Ok(await _customeAppService.GetCompanyAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Error finding company.");
            }
        }


        [HttpPost, Route("cemesPortalUsers")]

        public async Task<ActionResult<ListResult<CemesUsersViewodel>>> CemesPortalUsersAsync()
        {
            try
            {

                return Ok(await _customeAppService.CemesPortalUsersAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Error.");
            }
        }

        [HttpPost, Route("customerDetails")]
        public async Task<ActionResult<ListResult<CustomerDetailsViewModel>>> CustomerDetailsAsync(int custId)
        {
            try
            {

                return Ok(await _customeAppService.CustomerDetailsAsync(custId));
            }
            catch (Exception ex)
            {
                return BadRequest("Error finding details");
            }
        }
    }

}
