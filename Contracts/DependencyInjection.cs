using Contracts.Contact;
using Contracts.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public static class DependencyInjection
    {
        public static void RegisterContractDependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<DB_Context>(options => options.UseInMemoryDatabase("Contact"));
            services.AddScoped<IContact, RContact>();
        }
    }
}
