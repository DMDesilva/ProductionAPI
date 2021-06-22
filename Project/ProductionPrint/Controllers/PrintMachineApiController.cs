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
    public class PrintMachineApiController : ControllerBase
    {
        
        [HttpGet("getPrintMachineRepair")]
        public DataTable GetPrintMachineRepair()
        {
            PrintMachineRepair printmach = new PrintMachineRepair(CommonData.ConStr());
            return printmach.LoadPrintmachinRep();
        }
        [HttpPost("savePrintMachin")]
        public DataTable SavePrintMachin(PrintMachineRepair printmach)
        {
          //  PrintMachineRepair printmach = new PrintMachineRepair(CommonData.ConStr());
            return printmach.Save_machine();
        }
    }
}