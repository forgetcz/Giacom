using Application.Composition;
using GiacomImportData;
using GiacomImportData.Application.Composition;
using Infrastructure.Composition;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
            services.AddInfrastructureServices();
            services.AddApplicationServices();
            services.AddImportDataServices();
            services.AddHostedService<Worker>();

        })
        .Build();

        await host.RunAsync();
    }
}