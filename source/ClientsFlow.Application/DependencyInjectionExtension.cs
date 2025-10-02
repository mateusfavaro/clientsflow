using ClientsFlow.Application.UseCases.Clients.Delete;
using ClientsFlow.Application.UseCases.Clients.GetAll;
using ClientsFlow.Application.UseCases.Clients.GetById;
using ClientsFlow.Application.UseCases.Clients.Register;
using ClientsFlow.Application.UseCases.Clients.Update;
using Microsoft.Extensions.DependencyInjection;

namespace ClientsFlow.Application
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCase(services);
        }


        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<IRegisterClientUseCase, RegisterClientUseCase>();
            services.AddScoped<IGetClientsUseCase, GetClientsUseCase>();
            services.AddScoped<IGetClientByIdUseCase, GetClientByIdUseCase>();
            services.AddScoped<IDeleteClientUseCase, DeleteClientUseCase>();
            services.AddScoped<IUpdateClientUseCase, UpdateClientUseCase>();
        }

    }
}
