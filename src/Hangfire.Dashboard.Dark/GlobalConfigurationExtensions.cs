﻿using Hangfire.Dashboard.Extensions;
using System;
using System.Reflection;

namespace Hangfire.Dashboard.Dark
{
    /// <summary>
    /// Provides extension methods to setup Hangfire.Dashboard.Dark
    /// </summary>
    public static class GlobalConfigurationExtensions
    {
        /// <summary>
        /// Configures Hangfire to use the dark dashboard theme
        /// </summary>
        /// <param name="configuration">Global configuration</param>
        public static IGlobalConfiguration UseDarkDashboard(this IGlobalConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            // register dispatchers for CSS
            var assembly = typeof(GlobalConfigurationExtensions).GetTypeInfo().Assembly;
            DashboardRoutes.Routes.Append("/css[0-9]{3}", new EmbeddedResourceDispatcher(assembly, "Hangfire.Dashboard.Dark.Resources.style.css"));

            return configuration;
        }
    }
}
