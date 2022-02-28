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
        public DataSet GetSewingPlan(ClsPrm prm)
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

        [HttpPost("dateSecPlanSaved")]
        public DataTable DateSecPlanSaved(PlanBoard plan)
        {
           //PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.Date_SecPlanSave();
        }

        [HttpPost("planChangeSaved")]
        public DataTable PlanChangeSaved(PlanBoard plan)
        {
            //PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.PlanChangeSave();
        }

        [HttpPost("loadPlannedSec")]
        public DataTable LoadPlannedSec(ClsPrm prm)
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.LoadSectionPlanData( prm.iPram1);
        }
        
        [HttpGet("loadPlanData")]
        public DataTable LoadPlanData()
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.LoadPlanData();
        }
        //
        [HttpGet("loadPlanSec")]
        public DataTable LoadPlanSec()
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.Load_Plan_Section();
        }
        [HttpGet("loadSection")]
        public DataTable LoadSection()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetSections();
        }
        [HttpGet("loadSecforPlan")]
        public DataTable LoadSecforPlan()
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.LoadSectionforPlan();
        }

        [HttpPost("loadAllPlannedSec")]
        public DataTable LoadAllPlannedSec(ClsPrm prm)
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.LoadAllSectionPlanData(prm.stPram1);
        }
         [HttpGet("loadSublcat")]
        public DataTable LoadSublcat()
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.LoadSublimct();
        }

        [HttpPost("loadPlannedProd")]
        public DataTable LoadPlannedProd(ClsPrm prm)
        {
            PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return plan.PlanProdData(prm.iPram1);
        }

        // Section Out Put
        [HttpGet("loadPlanDataAll")]
        public DataSet LoadPlanDataAll()
        {
            SectionProductionOut planAll = new SectionProductionOut(CommonData.ConStr());
            return planAll.GetProduction();
        }

        [HttpPost("saveplanSection")]
        public DataTable saveplanSection(PlanBoard plan)
        {  
            return plan.Date_SectionPlanSave();
        }

    }
}