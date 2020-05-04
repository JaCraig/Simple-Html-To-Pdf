using Canister.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.UnmanagedHandler;

namespace SimpleHtmlToPdf.CanisterModules
{
    /// <summary>
    /// Canister module
    /// </summary>
    /// <seealso cref="Canister.Interfaces.IModule"/>
    public class CanisterModule : IModule
    {
        /// <summary>
        /// Order to run this in
        /// </summary>
        public int Order { get; }

        /// <summary>
        /// Loads the module using the bootstrapper
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper.</param>
        public void Load(IBootstrapper bootstrapper)
        {
            bootstrapper?.Register<IConverter, HtmlConverter>(ServiceLifetime.Singleton)
                .Register<BindingWrapper>(ServiceLifetime.Singleton);
        }
    }
}