using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Zyfro.Pro.Server.Application.Infrastructure.AutoMapper
{
    public class MapperProfileLocator : Profile
    {
        public MapperProfileLocator()
        {
            ApplyCustomMappings();
        }

        private void ApplyCustomMappings()
        {
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(p => typeof(IProfile).IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);

            foreach (var type in types)
            {
                var instance = (IProfile)Activator.CreateInstance(type);
                instance.CreateMappings(this);
            }
        }
    }
}
