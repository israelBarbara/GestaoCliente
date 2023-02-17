using GestaoClientes.Domain.v1.Interfaces.Repositories;
using GestaoClientes.Domain.v1.Interfaces.Services;
using GestaoClientes.Domain.v1.Repositories;
using GestaoClientes.Domain.v1.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Core.DepedencyInjection
{
    public static class DepedencyInjection
    {
        public static void ResolveDepedencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IClienteServices, ClienteServices>();

            services.AddScoped<IClienteRepository, ClienteRepository>();

        }

    }
}
