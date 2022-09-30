using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using IContainer = Autofac.IContainer;

namespace Oechsle.Api.CrossCutting.IoC
{
    public class IocAutofacContainer
    {
        private static IContainer container;
        protected static readonly Lazy<IocAutofacContainer> instance = new Lazy<IocAutofacContainer>(() => new IocAutofacContainer(), true);

        public static IocAutofacContainer Current
        {
            get { return instance.Value; }
        }

        public static IContainer InitializeContainer(IServiceCollection serviceCollection)
        {
            ContainerBuilder builder;

            try
            {
                builder = new ContainerBuilder();
                builder.Populate(serviceCollection);

                string[] assemblyScanerPattern = new[]
                {
                    "Oechsle.Api.Application.*.dll",
                    "Oechsle.Api.Infraestructure.*.dll", 
                };

                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

                var assemblies = new List<Assembly>();

                assemblies.AddRange(
                   Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories)
                            .Where(filename => assemblyScanerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
                            .Select(Assembly.LoadFrom)
                   );

                foreach (var assembly in assemblies)
                    builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

                container = builder.Build();

            }
            catch (ArgumentException exception)
            {
                throw new ArgumentException(exception.Message, exception);
            }

            return container;

        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public T Resolve<T>(string name, object value)
        {
            return container.Resolve<T>(new NamedParameter(name, value));
        }
    }
}
