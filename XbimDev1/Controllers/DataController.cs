using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xbim;
using Xbim.Ifc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using XbimDev1.Services.Implementation;
using XbimDev1.Services;

namespace XbimDev1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {

        private readonly ILogger<DataController> _logger;
        private XbimEditorCredentials editor;
        private readonly IService _dataService;

        public DataController(ILogger<DataController> logger, IService dataService)
        {
            _dataService = dataService;
            _logger = logger;
        }

        [HttpGet]
        public new string Get()
        {
            return _dataService.GetIfcTypes();
        }
    }
}
