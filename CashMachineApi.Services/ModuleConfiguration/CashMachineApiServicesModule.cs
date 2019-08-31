using CashMachineApi.Services.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CashMachineApi.Services.ModuleConfiguration
{
    public static class CashMachineApiServicesModule
    {
        public static void ConfigureCashMachineApiServices(this IServiceCollection services)
        {
            services.AddScoped<IDetermineNotesQuantityPipeFactory, DetermineNotesQuantityPipeFactory>();
            services.AddScoped<INotesInfoService, NotesInfoService>();
        }
    }
}
