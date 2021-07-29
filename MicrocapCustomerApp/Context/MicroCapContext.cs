using MicrocapCustomerApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrocapCustomerApp.Context
{
    public class MicroCapContext : DbContext
    {
        public DbSet<UsersViewModel> Customers{ get; set; }
        public DbSet<CompanyViewModel> Company{ get; set; }
        public DbSet<CemesUsersViewodel> usermaster { get; set; }
        public DbSet<CustomerDetailsViewModel> customers { get; set; }
        



        public MicroCapContext(DbContextOptions<MicroCapContext> options)
: base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}