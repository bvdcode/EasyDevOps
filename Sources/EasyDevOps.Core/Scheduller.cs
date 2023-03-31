using System;
using System.Threading.Tasks;

namespace EasyDevOps.Core
{
    public class Scheduller
    {
        private readonly IConfigurationProvider<SchedullerRule> configurationProvider;
        private readonly ILogger? logger;

        public Scheduller(IConfigurationProvider<SchedullerRule> configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        public Scheduller(IConfigurationProvider<SchedullerRule> configurationProvider, ILogger logger) 
            : this(configurationProvider)
        {
            this.logger = logger;
        }

        public Task StartAsync()
        {
            throw new NotImplementedException();
        }
    }
}