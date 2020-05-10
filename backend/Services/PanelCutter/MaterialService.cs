﻿using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class MaterialService : SingleElementBaseService<PanelCutter, Material, MaterialDto, MaterialTableDto>, IMaterialService
    {
        public MaterialService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        { }
    }
}