using Microsoft.AspNetCore.Mvc;
using TeleportAPI.Application.Dtos.Clients.Teleport.Response;
using TeleportAPI.Application.Dtos.Teleport.Request;
using TeleportAPI.Application.Dtos.Teleport.Response;
using TeleportAPI.Application.Services.Abstraction;
using TeleportAPI.Application.Wrappers;

namespace TeleportAPI.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeleportsController : ControllerBase
    {
        private readonly ITeleportService _teleportService;

        public TeleportsController(ITeleportService teleportService)
        {
            _teleportService = teleportService;
        }

        #region Documentation
        /// <summary>
        /// Returns the difference between two iatas
        /// </summary>
        /// <param name="model"></param>
        #endregion
        [HttpGet("iatas/miles-difference")]
        public async Task<Response<TeleportGetMilesDifferenceResponseDto>> GetMilesDifferenceAsync([FromQuery] TeleportGetMilesDifferenceDto model)
        => await _teleportService.GetMilesDifferenceBetweenIatasAsync(model);
    }
}
