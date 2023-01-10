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

        [HttpGet("getUsedSpartDetails")]
        public DataTable GetUsedSpartDetails()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetUsedSpartDetails();
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

        [HttpPost("sendEmailsJobCreate")]
        public DataTable SendEmailsJobCreate(EmailSend em)
        {
            return em.SendEmailsJobCreate();
        }

        [HttpPost("jobassignSave")]
        public DataTable JobassignSave(mcinventory mc)
        {
            return mc.jobassignSave();
        }

        [HttpGet("getallspare")]
        public DataTable Getallspare()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetAllSparepart();
        }

        [HttpGet("getAllparts")]
        public DataTable GetAllparts()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetAllparts();
        }

        [HttpGet("getMainitmAll")]
        public DataTable GetMainitmAll()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetAllpartsMainitm();
        }
        [HttpGet("getAssinedJob")]
        public DataTable GetAssinedJob()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetAssinedJob();
        }
        [HttpGet("getAssinedMach")]
        public DataTable GetAssinedMach()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetAssinedMach();
        }

        [HttpPost("jobend")]
        public DataTable Jobend(mcinventory mc)
        {
            return mc.JobEnd();
        }

        [HttpPost("getblncStock")]
        public DataTable GetblncStock(ClsPrm prm)
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetblncStock(prm.iPram1,prm.iPram2);
        }

        [HttpPost("jobCreate")]
        public DataTable JobCreate(mcinventory mc)
        {
            return mc.JobCreate();
        }

        [HttpPost("jobReject")]
        public DataTable JobReject(mcinventory mc)
        {
            return mc.JobReject();
        }
        [HttpPost("jobupdate")]
        public DataTable jobupdate(mcinventory mc)
        {
            return mc.jobupdate();
        }

        [HttpGet("getDetailsreq")]
        public DataSet GetDetailsreq()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.GetDetailsreq();
        }

        [HttpGet("updateSycn")]
        public DataTable updateSycn()
        {
            mcinventory mc = new mcinventory(CommonData.ConStr());
            return mc.updateSycn();
        }
    }
}