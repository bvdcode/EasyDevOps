using EasyDevOps.Core;

namespace EasyDevOps.Console
{
    internal class ConfigurationProvider : IConfigurationProvider<SchedullerRule>
    {
        private readonly Options options;
        private readonly FileSystemWatcher fileSystemWatcher;
        private const string defaultConfigurationFileName = "easy-dev-ops-configuration.json";
        public event EventHandler? OnRulesUpdated;

        public ConfigurationProvider(Options options)
        {
            this.options = options;
            if (string.IsNullOrWhiteSpace(options.ConfigurationFilePath))
            {
                options.ConfigurationFilePath = Environment.CurrentDirectory + defaultConfigurationFileName;
            }
            fileSystemWatcher = new FileSystemWatcher(options.ConfigurationFilePath);
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            OnRulesUpdated?.Invoke(this, e);
        }

        public IEnumerable<SchedullerRule> GetRules()
        {
            throw new NotImplementedException();
        }

    }
}