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

        [HttpGet("get_SMV_mast")]
        public DataSet Get_SMV_mast()
        {
            smv_operation smv = new smv_operation(CommonData.ConStr());
            return smv.Load_MAST_Type();
        }

        [HttpPost("saveSMV_OP_dt")]
        public DataTable SaveSMV_OP_dt(smv_operation smv)
        {

            return smv.Save_SMV_OP_dt();
        }
        //---------------------------Costing-----------------
        [HttpPost("save_Costing")]
        public DataTable Save_Costing(CostSheet cost)
        {
            return cost.Save_Costing();
        }

        
        [HttpGet("get_load_cost_data")]
        public DataSet Get_load_cost_data()
        {
            CostSheet cost = new CostSheet();
            return cost.LoadCostingDt();
        }

        [HttpGet("get_items")]
        public DataTable Get_items()
        {
            PatternCreate pttn = new PatternCreate(CommonData.ConStr());
            return pttn.Get_Items_Cat();
        }

        [HttpGet("get_items_Cat")]
        public DataTable Get_items_Cat()
        {
            PatternCreate pttn = new PatternCreate(CommonData.ConStr());
            return pttn.GetItmsCater();
        }




    }
}