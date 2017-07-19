using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModelFactory
{
    /// <summary>
    /// The bootstrapper extension methods.
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Uses the view model factory.
        /// </summary>        
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
        /// <typeparam name="TViewModelFactory">The type of the view model factory.</typeparam>
        public static TBootstrapper UseViewModelFactory<TBootstrapper, TViewModelFactory>(
            this TBootstrapper bootstrapper)
            where TBootstrapper : class, IExtensible<TBootstrapper>, IHaveRegistrator
            where TViewModelFactory : class, IViewModelFactory
        {
            return bootstrapper.Use(new RegisterViewModelFactoryMiddleware<TBootstrapper, TViewModelFactory>());
        }
    }

    /// <summary>
    /// Middleware that registers view model factory.
    /// </summary>    
    public class RegisterViewModelFactoryMiddleware<TBootstrapper, TViewModelFactory> :
        IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator
        where TViewModelFactory : class, IViewModelFactory
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public TBootstrapper
            Apply(TBootstrapper @object)
        {
            @object.Registrator.RegisterSingleton<IViewModelFactory, TViewModelFactory>();
            return @object;
        }
    }
}