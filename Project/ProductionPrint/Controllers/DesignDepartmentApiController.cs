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
    public class DesignDepartmentApiController : ControllerBase
    {
        [HttpGet("loadPrintData")]
        public DataTable LoadPrintData()
        {
            DesignDepartment DisgnDprt = new DesignDepartment(CommonData.ConStr());
            return DisgnDprt.LoadDataDesign();
        }
        [HttpGet("loadDesigners")]
        public DataTable LoadDesigners()
        {
            DesignDepartment DisgnDprt = new DesignDepartment(CommonData.ConStr());
            return DisgnDprt.LoadDesigners();
        }
        
        [HttpGet("countDesignData")]
        public DataTable CountDesignData()
        {
            DesignDepartment DisgnDprt = new DesignDepartment(CommonData.ConStr());
            return DisgnDprt.LoadDesignCount();
        }
        [HttpGet("markAsignData")]
        public DataTable MarkAsignData()
        {
            DesignDepartment DisgnDprt = new DesignDepartment(CommonData.ConStr());
            return DisgnDprt.LoadMarkAsignData();
        }
        [HttpPost("saveDesignersData")]
        public DataTable SaveDesignersData(DesignDepartment DisgnDprt)
        {
            
            return DisgnDprt.SaveDesign();
        }

        //---------------------------------------------------
        [HttpPost("saveDesignWork")]
        public DataTable SaveDesignWork(DesignerWrkSheet DesignWrk)
        {

            return DesignWrk.SaveDesignWrkSheet();
        }
    }
}