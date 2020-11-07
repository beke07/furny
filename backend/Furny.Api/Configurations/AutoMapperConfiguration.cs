﻿using AutoMapper;
using Furny;
using Furny.DesignerFeature.MappingProfiles;
using Furny.Model.Common.MappingProfiles;
using Furny.PanelCutterFeature.MappingProfiles;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperConfiguration
    {
        public static void AddStartupAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(Startup),
                typeof(CommonMappingProfile),
                typeof(DesignerMappingProfile),
                typeof(PanelCutterMappingProfile));
        }
    }
}