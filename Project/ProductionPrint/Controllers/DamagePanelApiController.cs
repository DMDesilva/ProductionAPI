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
    public class DamagePanelApiController : ControllerBase
    {
        [HttpGet("loadDamageDetails")]
        public DataTable LoadDamageDetails()
        {
            DamagePanel damge = new DamagePanel(CommonData.ConStr());
            return damge.LoaddamageDetails();
        }

        [HttpGet("loadSizesAll")]
        public DataTable LoadSizesAll()
        {
            DamagePanel damge = new DamagePanel(CommonData.ConStr());
            return damge.LoadSizes();
        }

        [HttpPost("damageSave")]
        public DataTable DamageSave(DamagePanel damge)
        {
            //PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return damge.DamagePanelSave();
        }
        [HttpPost("approvalDamage")]
        public DataTable ApprovalDamage(DamagePanel damge)
        {
            //PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return damge.ApproveDamage();
        }
    }
}