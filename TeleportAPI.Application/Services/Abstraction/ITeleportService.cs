using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleportAPI.Application.Dtos.Clients.Teleport.Response;
using TeleportAPI.Application.Dtos.Teleport.Request;
using TeleportAPI.Application.Dtos.Teleport.Response;
using TeleportAPI.Application.Wrappers;

namespace TeleportAPI.Application.Services.Abstraction
{
    public interface ITeleportService
    {
        Task<Response<TeleportGetMilesDifferenceResponseDto>> GetMilesDifferenceBetweenIatasAsync(TeleportGetMilesDifferenceDto model);
    }
}
