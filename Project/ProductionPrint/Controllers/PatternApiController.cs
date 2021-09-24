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
        
        [HttpGet("get_Pattern_data")]
        public DataSet Get_Pattern_data()
        {
            PatternCreate ptn = new PatternCreate(CommonData.ConStr());
            return ptn.Load_PatternDt_data();
        }
        [HttpPost("saveItmsMast")]
        public DataTable SaveItmsMast(Items itms)
        {

            return itms.Save_Itms();
        }
        [HttpPost("savePttnCreate")]
        public DataTable SavePttnCreate(PatternCreate ptn)
        {

            return ptn.Save_Pattern_Create();
        }
        
        [HttpGet("get_Accessories")]
        public DataTable Get_Accessories()
        {
            PatternCreate ptn = new PatternCreate(CommonData.ConStr());
            return ptn.GetItms();
        }

        //-----------SMV----------------------
        [HttpGet("get_Operation")]
        public DataTable Get_Operation()
        {
            smv_operation smv = new smv_operation(CommonData.ConStr());
            return smv.LoadOperation();
        }
    }
}