﻿using Furny.DesignerFeature.Commands;
using Furny.DesignerFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerController : MediatorControllerBase
    {
        public DesignerController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}")]
        public async Task<DesignerHomeViewModel> Get(string id)
            => await SendAsync(DesignerGetCommand.Create(id));

        [HttpPost("{id}/favorites/{pid}")]
        public async Task AddFavoritePanelCutter(string id, string pid)
            => await SendAsync(DesignerAddFavoritePanelCutterCommand.Create(id, pid));

        [HttpDelete("{id}/favorites/{pid}")]
        public async Task RemoveFavoritePanelCutter(string id, string pid)
            => await SendAsync(DesignerRemoveFavoritePanelCutterCommand.Create(id, pid));

        [HttpGet("{id}/favorites")]
        public async Task<IList<DesignerFavoriteViewModel>> GetFavoritePanelCutters(string id)
            => await SendAsync(DesignerGetFavoritePanelCutterCommand.Create(id));
    }
}
