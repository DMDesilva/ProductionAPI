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
    public class McinventoryApiController : ControllerBase
    {
        [HttpGet("getDepartments")]
        public DataTable GetDepartments()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetDepartments();
        }

        [HttpGet("getMachine")]
        public DataTable GetMachine()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetMachine();
        }

        [HttpGet("getspareparts")]
        public DataTable Getspareparts()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.Getspareparts();
        }
        [HttpGet("getRepairtyps")]
        public DataTable GetRepairtyps()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetRepairtyps();
        }
        [HttpGet("getmachanic")]
        public DataTable Getmachanic()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.Getmachanic();
        }
        [HttpGet("getSwRepireDt")]
        public DataTable GetSwRepireDt()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetSwRepireDt();
        }
        [HttpGet("getSwRepireDetails")]
        public DataTable GetSwRepireDetails()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetSwRepireDetails();
        }

        [HttpGet("getmcjobReq")]
        public DataTable GetmcjobReq()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetmcjobReq();
        }

        [HttpPost("masterSave")]
        public DataTable MasterSave(mcinventory mc)
        {
            return mc.MasterSave();
        }

        [HttpPost("sWRepairSave")]
        public DataTable SWRepairSave(mcinventory mc)
        {
            return mc.SWRepairSave();
        }

        [HttpPost("genaralJobSave")]
        public DataTable GenaralJobSave(mcinventory mc)
        {
            return mc.GenaralJobSave();
        }
    }
}