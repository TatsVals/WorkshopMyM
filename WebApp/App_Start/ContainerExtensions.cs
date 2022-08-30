using BD;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;

namespace WebApp
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<ICambioClaveService, CambioClaveService>();
            services.AddScoped<IBitacora_MovimientosService, Bitacora_MovimientosService>();
            services.AddScoped<IOrdenesService, OrdenesService>();
            services.AddScoped<IBitacoraIngresosService, BitacoraIngresosService>();
            services.AddScoped<IRecuperarClaveService, RecuperarClaveService>();



            return services;
        }
    }
}
