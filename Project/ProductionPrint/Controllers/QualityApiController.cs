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
    public class QualityApiController : ControllerBase
    {

        [HttpGet("getFileNo")]
        public DataTable GetFileNo()
        {
            fileDINumData file = new fileDINumData(CommonData.ConStr());
            return file.LoadFileNo();
        }

        [HttpGet("gettranferDI")]
        public DataTable GettranferDI()
        {
            fileDINumData file = new fileDINumData(CommonData.ConStr());
            return file.LoadFileTransfer();
        }
       

        [HttpPost("saveFileMast")]
        public DataTable SaveFileMast(fileDINumData file)
        {
            // fileDINumData frghtDbt = new fileDINumData(CommonData.ConStr());
            return file.MastFileSave();
        }

        [HttpPost("saveDITranf")]
        public DataTable SaveDITranf(fileDINumData file)
        {
            // fileDINumData frghtDbt = new fileDINumData(CommonData.ConStr());
            return file.SaveTransfile();
        }
    }
}