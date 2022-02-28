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
    public class WarehouseFabReqApiController : ControllerBase
    {


         [HttpGet("getDepartment")]
        public DataTable GetDepartment()
        {
            warehouseFabRequest ware = new warehouseFabRequest(CommonData.ConStr());
            return ware.LoadDepartments();
        }

        [HttpGet("load_req_fab_info")]
        public DataSet Load_req_fab_info()
        {
            warehouseFabRequest ware = new warehouseFabRequest(CommonData.ConStr());
            return ware.Load_req_fab_info();
        }

        [HttpPost("getSizes")]
        public DataTable GetSizes(warehouseFabRequest ware)
        {
            return ware.SizesGet();
        }

        [HttpPost("save_warehouse")]
        public DataTable Save_warehouse(warehouseFabRequest ware)
        {
            return ware.Save_warehouse_fab_req();
        }
    }
}