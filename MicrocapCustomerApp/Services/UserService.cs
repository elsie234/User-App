using MicrocapCustomerApp.Context;
using MicrocapCustomerApp.Services.Iservices;
using MicrocapCustomerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrocapCustomerApp.Services
{
    public class UserService : IUserservice
    {
        private readonly MicroCapContext _context;
        public UserService(MicroCapContext context)
        {
            _context = context;
         
        }

        public async Task<object> RegisterCompanyAsync(CompanyViewModel company)
        {
            var _get = _context.Company
                .Where(c => c.CompanyName == company.CompanyName)
                .AsQueryable().ToList();
                
            return _get;
            if (_get != null)
            {
                return "Registration was successful";
            }
          
            
                
        }

        public async Task<object> LoginUsersAsync(LoginViewModel logins)
        {

            var _logins = _context.Customers
            .Where(l => l.UserName == logins.username && l.Password == logins.username)
            .FirstOrDefault();


            if (_logins != null)
            {
                return "Sucessful login";
            }
            else
            {
                return "Check your username or password";
            }
            

          
        }

        public async Task<object> GetCompanyAsync()
        {
            var _company = _context.Company
                .Select(n => n.CompanyName)
                .AsQueryable().ToList();


               return _company;


        }

        public async Task<object> RegisterUsersAsync(UsersViewModel users)
        {
        
            var register = new UsersViewModel();

            //_context.Customers.FirstOrDefault();
            //var _company = _context.Company
            //    .Where(n => n.CompanyName == users.PhoneNumber && n.Location == "Race course")
            //    .FirstOrDefault();

            //if (true)
            //{

            //}



            register.CompanyId = users.CompanyId;
            register.UserName = users.UserName;
            register.Email = users.Email;
            register.Password = users.Password;
            register.PhoneNumber = users.PhoneNumber;


            _context.Customers.Add(register);
            await _context.SaveChangesAsync();




            return "Registration was successful";
        }
        public async Task<ListResult<CemesUsersViewodel>> CemesPortalUsersAsync()
        {

            try
            {
                var userlist = new ListResult<CemesUsersViewodel>();

                //var portalusers = _context.usermaster
                //  .AsQueryable();

                var results = (from violations in _context.usermaster
                         .Where(s => s.Status == 1)
                               select new CemesUsersViewodel
                               {
                                   UserId = violations.UserId,
                                   Name = violations.FirstName + " " + violations.lastName,
                                   Status = violations.Status,
                                   BranchId = violations.BranchId,
                                   UserName = violations.UserName,
                                   MobileNo = violations.MobileNo,
                                   RoleID = violations.RoleID,
                                   EmailId = violations.EmailId


                               });


                var users = await results
                   //.Select(s => s.EmailId)
                   .OrderBy(o => o.UserId)
                  .AsQueryable()
                  .ToListAsync();

                if (users?.Count > 0)
                    userlist.Items = results.Select(s => (CemesUsersViewodel)s).ToList();

                return userlist;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Happened" + ex);
                throw;
            }

        }
    }
}
