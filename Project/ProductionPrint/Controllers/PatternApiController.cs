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
    public class PatternApiController : ControllerBase
    {
        
        [HttpPost("saveMaster")]
        public DataTable SaveMaster(PatternCreate ptn)
        {
           
            return ptn.Save_Master();
        }
        
        [HttpGet("get_Mast_data")]
        public DataSet Get_Mast_data()
        {
            PatternCreate ptn = new PatternCreate(CommonData.ConStr());
            return ptn.Load_Mast_data();
        }

        [HttpPost("saveItmsMast")]
        public DataTable SaveItmsMast(Items itms)
        {

            return itms.Save_Itms();
        }

        [HttpGet("get_Accessories")]
        public DataTable Get_Accessories()
        {
            PatternCreate ptn = new PatternCreate(CommonData.ConStr());
            return ptn.GetItms();
        }
    }
}