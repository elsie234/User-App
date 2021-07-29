using MicrocapCustomerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrocapCustomerApp.Services.Iservices
{
   public interface IUserservice
    {
        Task<object> RegisterUsersAsync( UsersViewModel users);
        Task<object> LoginUsersAsync( LoginViewModel logins);
        Task<object> RegisterCompanyAsync(CompanyViewModel company);
        Task<object> GetCompanyAsync();
        Task<ActionResult<ListResult<CemesUsersViewodel>>> CemesPortalUsersAsync();
        Task<ListResult<CustomerDetailsViewModel>> CustomerDetailsAsync(int custId);

    }
}
