using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Fipe.Infrastructure.Adapter.AutoMapper
{
    public class AutoMapperTypeAdapterFactory : ITypeAdapterFactory
    {
        public AutoMapperTypeAdapterFactory()
        {
            Mapper.Initialize(x => GetAutoMapperConfiguration(Mapper.Configuration));
        }

        private static void GetAutoMapperConfiguration(IConfiguration configuration)
        {
            var profiles = GetProfiles();
            foreach (var profile in profiles)
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
        }

        private static IEnumerable<Type> GetProfiles()
        {
            return typeof(AutoMapperTypeAdapterFactory).Assembly.GetTypes()
                .Where(type => !type.IsAbstract && typeof(Profile).IsAssignableFrom(type));
        }

        public ITypeAdapter Build()
        {
            return new AutoMapperTypeAdapter();
        }
    }
}
