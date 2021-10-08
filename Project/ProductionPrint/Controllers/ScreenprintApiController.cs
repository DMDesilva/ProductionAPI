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
    public class ScreenprintApiController : ControllerBase
    {

        [HttpGet("get_spr")]
        public DataSet Get_spr()
        {
            Screenprint spr= new Screenprint();
            return spr.Load_spr_details();
        }
        
        [HttpGet("get_Dashboard")]
        public DataSet Get_Dashboard()
        {
            Screenprint spr = new Screenprint();
            return spr.Load_Dashbord();
        }

        [HttpGet("get_wrkhrD")]
        public DataTable Get_wrkhrDt()
        {
            workassign wrk = new workassign();
            return wrk.GetWrkhour();
        }

        [HttpGet("get_wrk_product")]
        public DataTable Get_wrk_product()
        {
            workassign wrk = new workassign();
            return wrk.GetWrkproductDetais();
        }

        [HttpPost("SaveSpr")]
        public DataTable SaveSpr(Screenprint spr)
        {
            return spr.Save_spr();
        }

        [HttpPost("saveWrkAssign")]
        public DataTable SaveWrkAssign(workassign wrk)
        {
            return wrk.SaveWrkAssign();
        }

        [HttpPost("saveWrk_prod")]
        public DataTable SaveWrk_prod(workassign wrk)
        {
            return wrk.SaveWrkprod_work();
        }

        [HttpPost("saveNewWorkers")]
        public DataTable SaveNewWorkers(workassign wrk)
        {
            return wrk.SaveNewWorker();
        }
       
    }
}