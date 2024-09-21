using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeleportAPI.Application.Clients.Teleport.Abstraction;
using TeleportAPI.Application.Dtos.Clients.Teleport.Response;
using TeleportAPI.Application.Dtos.Teleport.Request;
using TeleportAPI.Application.Dtos.Teleport.Response;
using TeleportAPI.Application.Exceptions;
using TeleportAPI.Application.Services.Abstraction;
using TeleportAPI.Application.Utilities;
using TeleportAPI.Application.Validators.Teleport;
using TeleportAPI.Application.Wrappers;

namespace TeleportAPI.Application.Services.Implementation
{
    public class TeleportService : ITeleportService
    {
        private readonly ITeleportClient _teleportClient;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="teleportClient"></param>
        public TeleportService(ITeleportClient teleportClient)
        {
            _teleportClient = teleportClient;
        }

        /// <summary>
        /// Service method for miles difference between iatas
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="ValidationException"></exception>
        public async Task<Response<TeleportGetMilesDifferenceResponseDto>> GetMilesDifferenceBetweenIatasAsync(TeleportGetMilesDifferenceDto model)
        {
            var validationResult = await new TeleportGetMilesDifferenceDtoValidator().ValidateAsync(model);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var firstIataResponse = await _teleportClient.GetByIataCodeAsync(model.FirstIata);
            if (firstIataResponse is null)
                throw new ValidationException(ErrorMessages.NotFoundMessage(model.FirstIata));

            var secondIataResponse = await _teleportClient.GetByIataCodeAsync(model.SecondIata);
            if (secondIataResponse is null)
                throw new ValidationException(ErrorMessages.NotFoundMessage(model.SecondIata));

            return new Response<TeleportGetMilesDifferenceResponseDto>
            {
                Data = new TeleportGetMilesDifferenceResponseDto
                {
                    MilesDifference = GetMilesDifference(firstIataResponse.Location.Lat, firstIataResponse.Location.Lon, secondIataResponse.Location.Lat, secondIataResponse.Location.Lon)
                }
            };
        }

        /// <summary>
        /// Method for miles difference between iatas
        /// </summary>
        /// <param name="firstLat"></param>
        /// <param name="firstLon"></param>
        /// <param name="secondLat"></param>
        /// <param name="secondLon"></param>
        private static double GetMilesDifference(double firstLat, double firstLon, double secondLat, double secondLon)
        {
            double rlat1 = Math.PI * firstLat / 180;
            double rlat2 = Math.PI * secondLat / 180;
            double theta = firstLon - secondLon;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist;
        }
    }
}
