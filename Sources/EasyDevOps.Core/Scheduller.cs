using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyDevOps.Core
{
    public class Scheduller
    {
        private readonly IConfigurationProvider<SchedullerRule> configurationProvider;
        private readonly ILogger? logger;
        private CancellationToken cancellationToken;

        public Scheduller(IConfigurationProvider<SchedullerRule> configurationProvider)
        {
            cancellationToken = CancellationToken.None;
            this.configurationProvider = configurationProvider;
        }

        public Scheduller(IConfigurationProvider<SchedullerRule> configurationProvider, ILogger logger) 
            : this(configurationProvider)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}