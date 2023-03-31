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
            CancellationTokenSource cancellationTokenSource = new();
            System.Console.CancelKeyPress += (sender, args) => cancellationTokenSource.Cancel();
            ConfigurationProvider configurationProvider = new(options.Interval, options.ConfigurationFilePath);
            Logger logger = string.IsNullOrWhiteSpace(options.LogOutputFilePath) ?
                new() : new(options.LogOutputFilePath);
            Scheduller scheduller = new(configurationProvider);
            await scheduller.StartAsync(cancellationTokenSource.Token);
        }
    }
}