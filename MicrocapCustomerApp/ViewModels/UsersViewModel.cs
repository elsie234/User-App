using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MicrocapCustomerApp.ViewModels
{
    public class UsersViewModel
    { 
      [JsonIgnore]
        public int Id { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class LoginViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
         
        public string username { get; set; }
        public string Password { get; set; }
       
    }
    public class CompanyViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        public string CompanyName { get; set; }
        public string Location { get; set; }
      
    }
    public class CemesUsersViewodel
    {
        [JsonIgnore]
        [Key]
        public Int64 UserId { get; set; }
        [JsonIgnore]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string lastName { get; set; }

        [NotMapped]
        public string Name { get; set; }
        [JsonIgnore]
        public int Status { get; set; }
        [JsonIgnore]
        public int BranchId { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string RoleID { get; set; }


    }
}

