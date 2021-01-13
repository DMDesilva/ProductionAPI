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
    public class TpPrintDprtApiController : ControllerBase
    {
        [HttpGet("loadOrdData")]
        public DataTable LoadOrdData()
        {
            TpPrintDepartment tpDprt = new TpPrintDepartment(CommonData.ConStr());
            return tpDprt.LoadordrList();
        }
        [HttpGet("loadTestPrintedData")]
        public DataTable LoadTestPrintedData()
        {
            TpPrintDepartment tpDprt = new TpPrintDepartment(CommonData.ConStr());
            return tpDprt.LoadTestPrintData();
        }
        [HttpPost("saveTestPrint")]
        public DataTable SaveTestPrint(TpPrintDepartment tpDprt)
        {
            //TpPrintDepartment tpDprt = new TpPrintDepartment(CommonData.ConStr());
            return tpDprt.SaveTestPrint();
        }
    }
}