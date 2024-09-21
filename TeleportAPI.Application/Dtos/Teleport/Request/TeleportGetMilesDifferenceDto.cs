using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleportAPI.Application.Dtos.Teleport.Request
{
    public class TeleportGetMilesDifferenceDto
    {
        public string FirstIata { get; set; }
        public string SecondIata { get; set; }
    }
}
