using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductionPrint.models;

namespace ProductionPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionProductionApiController : ControllerBase
    {
        [HttpPost("getSection")]
        public DataTable GetSection(Sectionproduction prod)
        {
           // Sectionproduction prod = new Sectionproduction(CommonData.ConStr());
            return prod.SaveProduction();
        }

    }
}