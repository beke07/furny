﻿using AutoMapper;
using Furny.Common.Services;
using Furny.Common.ViewModels;
using Furny.Model;
using Furny.PanelCutterFeature.Commands;
using Furny.PanelCutterFeature.ServiceInterfaces;
using Furny.PanelCutterFeature.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.PanelCutterFeature.Services
{
    public class PanelCutterService : BaseService<PanelCutter>, IPanelCutterService
    {
        private const string collectionName = "applicationUsers";
        private readonly IMapper _mapper;

        public PanelCutterService(
            IMapper mapper,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
        }

        public async Task<IList<AdViewModel>> GetAdsByCountry(string country)
        {
            var panelCutters = await _collection
                .OfType<PanelCutter>()
                .Find(e => e.UserAddress.Address.Country == country)
                .ToListAsync();

            var ads = panelCutters.Select(e => e.Ads);

            IList<AdViewModel> result = new List<AdViewModel>();

            panelCutters.ForEach(panelCutter =>
            {
                panelCutter.Ads.ToList().ForEach(ad =>
                {
                    var adViewModel = _mapper.Map<AdViewModel>(ad);
                    adViewModel.PanelCutterId = panelCutter.Id.ToString();
                    adViewModel.PanelCutterImageId = panelCutter.ImageId;
                    adViewModel.PanelCutterUserName = panelCutter.UserName;

                    result.Add(adViewModel);
                });
            });

            return result;
        }

        public async Task<PanelCutterProfileViewModel> GetProfileAsync(string id)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<PanelCutterProfileViewModel>(panelCutter);
        }

        public async Task UpdateProfileAsync(JsonPatchDocument<PanelCutterProfileCommand> jsonPatch, string id)
        {
            var panelCutter = await FindByIdAsync(id);
            var profile = _mapper.Map<PanelCutterProfileCommand>(panelCutter);

            jsonPatch.ApplyTo(profile);
            _mapper.Map(profile, panelCutter);

            await UpdateAsync(panelCutter);
        }

        public override async Task<IList<PanelCutter>> Get()
        {
            return await _collection.OfType<PanelCutter>().Find(e => !e.IsDeleted).ToListAsync();
        }
    }
}