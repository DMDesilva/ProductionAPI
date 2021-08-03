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
        //--------------------------------------
        //
        [HttpGet("getSpareSerial")]
        public DataTable GetetSpareSerial()
        {
            SparepartAssign spare = new SparepartAssign(CommonData.ConStr());
            return spare.LoadSpartSerial();
        }

        [HttpPost("saveSerialNo")]
        public DataTable SaveSerialNo(SparepartAssign spare)
        {
           
            return spare.Save_SpareprtsSerial();
        }
        //-----------------------------------Sparepart Assign-----------------------------------------\\
        [HttpGet("getsparepart")]
        public DataTable Getsparepart()
        {
            SparepartAssign spare = new SparepartAssign(CommonData.ConStr());
            return spare.LoadSparepart();
        }
        [HttpGet("getColor")]
        public DataTable GetColor()
        {
            SparepartAssign spare = new SparepartAssign(CommonData.ConStr());
            return spare.LoadColor();
        }
        //
        [HttpGet("getUnit")]
        public DataTable GetUnit()
        {
            SparepartAssign spare = new SparepartAssign(CommonData.ConStr());
            return spare.LoadUnit();
        }

        [HttpGet("getSpareprtmchn")]
        public DataTable GetSpareprtmchn()
        {
            SparepartAssign spare = new SparepartAssign(CommonData.ConStr());
            return spare.LoadAssignSparemachn();
        }

        [HttpGet("getSpartAssignData")]
        public DataTable GetSpartAssignData()
        {
            SparepartAssign spare = new SparepartAssign(CommonData.ConStr());
            return spare.LoadSpartAssignData();
        }

        [HttpPost("saveSparepart")]
        public DataTable SaveSparepart(SparepartAssign spare)
        {
            
            return spare.Save_Spareprts();
        }

        //----------------------------------- Brake Down-----------------------------------------------\\
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