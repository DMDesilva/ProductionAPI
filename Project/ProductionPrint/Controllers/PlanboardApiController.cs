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
    public class PlanboardApiController : ControllerBase
    {
        
        [HttpPost("getSewingPlan")]
        public DataTable GetSewingPlan(ClsPrm prm)
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.LoadSewingPlan(prm.DtPram1);
        }
        
        [HttpPost("planDashboard")]
        public DataSet PlanDashboard(ClsPrm prm)
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.PlanDashboard(prm.stPram1, prm.stPram2);
        }
        [HttpPost("planSaved")]
        public DataTable PlanSaved(PlanBoard plan)
        {
           //PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.PlanSave();
        }

        
             [HttpPost("loadPlannedSec")]
        public DataTable LoadPlannedSec(ClsPrm prm)
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.LoadSectionPlanData(prm.DtPram1, prm.iPram1);
        }
        [HttpPost("loadAllPlannedSec")]
        public DataTable LoadAllPlannedSec(ClsPrm prm)
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.LoadAllSectionPlanData(prm.stPram1);
        }

        [HttpGet("loadPlannedProd")]
        public DataTable LoadPlannedProd()
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.PlanProdData();
        }

    }
}