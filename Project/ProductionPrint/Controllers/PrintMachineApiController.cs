﻿using System;
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

        //-----------------------------
        [HttpGet("getbrakedwn")]
        public DataTable Getbrakedwn()
        {
            BrakeDown brake= new BrakeDown(CommonData.ConStr());
            return brake.LoadBrakeDown();
        }
        
        [HttpPost("saveBrake")]
        public DataTable SaveBrake(BrakeDown brake)
        {
            //  PrintMachineRepair printmach = new PrintMachineRepair(CommonData.ConStr());
            return brake.Save_Brakedwn();
        }
    }
}