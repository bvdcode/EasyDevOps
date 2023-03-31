using CommandLine;

namespace EasyDevOps.Console
{
    public class Options
    {
        [Option('c', "configuration", Required = false, HelpText = "Path to configuration file.")]
        public string? ConfigurationFilePath { get; set; }

        [Option('a', "add", Required = false, HelpText = "Add new rule.")]
        public string? NewRule { get; set; }

        [Option('i', "interval", Required = false, Min = 1, Default = 60, HelpText = "Update interval, in seconds.")]
        public int Interval { get; set; }

        [Option('l', "logfile", Required = false, HelpText = "Log file path.")]
        public string? LogOutputFilePath { get; set; }
    }
}