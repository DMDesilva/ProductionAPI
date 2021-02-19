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
    public class FabricReportApiController : ControllerBase
    {
        //
        [HttpGet("loadFabDatails")]
        public DataTable LoadFabDatails()
        {
            fabricReport fbric = new fabricReport(CommonData.ConStr());
            return fbric.LoadFabDatails();
        }
        [HttpPost("saveFabric")]
        public DataTable SaveFabric(fabricReport fbric)
        {
            // fabricReport fbric = new fabricReport(CommonData.ConStr()); 
            return fbric.SaveFabricReport();
        }

        //SearchDtByFabDatails
        [HttpPost("searchDt")]
        public DataTable SearchDt(ClsPrm prm)
        {
            fabricReport fbric = new fabricReport(CommonData.ConStr()); 
            return fbric.SearchDtByFabDatails(prm.DtPram1);
        }
    }
}