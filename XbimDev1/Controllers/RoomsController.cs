using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xbim;
using Xbim.Ifc;
using Xbim.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xbim.Ifc4.ProductExtension;
using XbimDev1.Services;
using XbimDev1.Services.Implementation;

namespace XbimDev1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : Controller
    {
        private readonly ILogger<RoomsController> _logger;
        private XbimEditorCredentials editor;
        private readonly IService _roomsService;

        public RoomsController(ILogger<RoomsController> logger, IService roomsService)
        {
            _roomsService = roomsService;
            _logger = logger;
        }

        [HttpGet]
        public new string Get()
        {
            return _roomsService.GetRooms();
        }
    }
}
