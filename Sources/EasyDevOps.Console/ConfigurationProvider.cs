using EasyDevOps.Core;
using System.Text.Json;

namespace EasyDevOps.Console
{
    internal class ConfigurationProvider : IConfigurationProvider<SchedullerRule>
    {
        private readonly FileSystemWatcher fileSystemWatcher;
        private readonly string configurationFilePath;
        private const string defaultConfigurationFileName = "easy-dev-ops-configuration.json";

        public int UpdateInterval { get; }

        public event EventHandler? OnRulesUpdated;

        public ConfigurationProvider(int updateInterval) : this(updateInterval, null) { }
        public ConfigurationProvider(int updateInterval, string? configurationFilePath)
        {
            if (string.IsNullOrWhiteSpace(configurationFilePath))
            {
                configurationFilePath = Environment.CurrentDirectory + defaultConfigurationFileName;
            }
            if (!File.Exists(configurationFilePath))
            {
                var defaultConfiguration = new SchedullerRule[]
                {
                    new SchedullerRule()
                    {
                        //TODO: initialize empty ruleset
                    }
                };
                string json = JsonSerializer.Serialize(defaultConfiguration);
                File.WriteAllText(configurationFilePath, json);
            }
            fileSystemWatcher = new FileSystemWatcher(configurationFilePath);
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            UpdateInterval = updateInterval;
            this.configurationFilePath = configurationFilePath;
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            OnRulesUpdated?.Invoke(this, e);
        }

        public IEnumerable<SchedullerRule> GetRules()
        {
            try
            {
                using var fs = File.OpenRead(configurationFilePath);
                var result = JsonSerializer.Deserialize<SchedullerRule[]>(fs);
                return result ?? throw new NullReferenceException(nameof(configurationFilePath));
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Cannot read configuration file: {filename}", configurationFilePath);
                return Enumerable.Empty<SchedullerRule>();
            }
        }
    }
}