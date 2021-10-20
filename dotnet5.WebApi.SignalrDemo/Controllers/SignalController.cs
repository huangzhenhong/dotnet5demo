using dotnet5.WebApi.SignalrDemo.Hubs;
using dotnet5.WebApi.SignalrDemo.Models;
using dotnet5.WebApi.SignalrDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet5.WebApi.SignalrDemo.Controllers
{
    [Route("api/v1/signals")]
    [ApiController]
    public class SignalControlller : ControllerBase
    {
        private readonly ISignalService _signalService;
        private readonly IHubContext<SignalHub> _hubContext;

        public SignalControlller(ISignalService signalService, IHubContext<SignalHub> hubContext)
        {
            _signalService = signalService;
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("deliverypoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> SignalArrived(SignalInputModel model)
        {
            var saveResult = await _signalService.SaveSignalAsync(model);

            if (saveResult) {

                SignalViewModel signalViewModel = new SignalViewModel { 
                    Description = model.Description,
                    CustomerName = model.CustomerName,
                    Area = model.Area,
                    Zone = model.Zone,
                    SignalStamp = Guid.NewGuid().ToString()
                };

                await _hubContext.Clients.All.SendAsync("SignalMessageReceived", signalViewModel);
            }

            return StatusCode(200, saveResult);
        }
    }
}
