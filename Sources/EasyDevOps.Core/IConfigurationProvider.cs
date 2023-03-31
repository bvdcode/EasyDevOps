using System;
using System.Collections.Generic;

namespace EasyDevOps.Core
{
    public interface IConfigurationProvider<TConfigurationEntity> where TConfigurationEntity : class
    {
        IEnumerable<TConfigurationEntity> GetRules();
        event EventHandler OnRulesUpdated;
    }
}