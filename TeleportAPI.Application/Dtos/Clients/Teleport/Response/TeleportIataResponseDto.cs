using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleportAPI.Application.Dtos.Clients.Teleport.Response
{
    public class TeleportIataResponseDto
    {
        public string Iata { get; set; }
        public TeleportIataLocationDto Location { get; set; }
    }

    public class TeleportIataLocationDto
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}
