using CommandLine;
using EasyDevOps.Core;

namespace EasyDevOps.Console
{
    internal class Program
    {
        static async Task Main(params string[] args)
        {
            await Parser.Default
                .ParseArguments<Options>(args)
                .WithParsedAsync(StartApplicationAsync);
        }

        private static async Task StartApplicationAsync(Options options)
        {
            ConfigurationProvider configurationProvider = new(options);
            Scheduller scheduller = new(configurationProvider);
            await scheduller.StartAsync();
        }
    }
}