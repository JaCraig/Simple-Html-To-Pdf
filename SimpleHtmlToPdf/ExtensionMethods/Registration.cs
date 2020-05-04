﻿using Canister.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.UnmanagedHandler;

namespace SimpleHtmlToPdf.ExtensionMethods
{
    public static class Registration
    {
        /// <summary>
        /// Registers the simple HTML to PDF.
        /// </summary>
        /// <param name="serviceDescriptors">The service descriptors.</param>
        /// <returns></returns>
        public static IServiceCollection? AddSimpleHtmlToPdf(this IServiceCollection? serviceDescriptors)
        {
            return serviceDescriptors?.AddSingleton<IConverter, HtmlConverter>().AddSingleton<BindingWrapper>();
        }

        /// <summary>
        /// Registers the simple HTML to PDF.
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns></returns>
        public static IBootstrapper? RegisterSimpleHtmlToPdf(this IBootstrapper? bootstrapper)
        {
            return bootstrapper?.AddAssembly(typeof(Registration).Assembly);
        }
    }
}