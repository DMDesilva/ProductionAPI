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
    public class FreeCostApiController : ControllerBase
    {


        [HttpGet("load_Cttn_Fab")]
        public DataTable Load_Cttn_Fab()
        {
            FreeCostSheet cst = new FreeCostSheet(CommonData.ConStr());
            return cst.Get_Cttn_Fab();
        }

        [HttpGet("load_fb_anti")]
        public DataTable Load_fb_anti()
        {
            FreeCostSheet cst = new FreeCostSheet(CommonData.ConStr());
            return cst.Get_Cttn_Fab_Anti();
        }
    }
}