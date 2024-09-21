using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleportAPI.Application.Dtos.Clients.Teleport.Response;

namespace TeleportAPI.Application.Clients.Teleport.Abstraction
{
    public interface ITeleportClient
    {
        Task<TeleportIataResponseDto> GetByIataCodeAsync(string iata);
    }
}
