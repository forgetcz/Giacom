using Application.Composition;
using Application.Interfaces;
using Application.Services;
using GiacomImportData;
using GiacomImportData.Application.Composition;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
            services.AddApplicationServices();
            services.AddImportDataServices();
            services.AddHostedService<Worker>();

        })
        .Build();

        await host.RunAsync();
    }
}