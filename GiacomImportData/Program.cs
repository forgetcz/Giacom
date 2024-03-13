using Application.Composition;
using GiacomImportData;
using GiacomImportData.Application.Composition;
using Infrastructure.Composition;

internal class Program
{
    private static async Task Main(string[] args)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddInfrastructureServices();
                services.AddApplicationServices();
                services.AddImportDataServices();
                services.AddHostedService<Worker>();

            })
            .ConfigureLogging(logBuilder => 
            {
                logBuilder.ClearProviders();
                logBuilder.SetMinimumLevel(LogLevel.Trace);
                logBuilder.AddLog4Net("log4net.config");
            })
            .Build();



        await host.RunAsync();
    }
}